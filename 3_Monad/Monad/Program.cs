using Monad.ExampleClasses.Phase1;
using Monad.ExampleClasses.Phase2;
using Monad.ExampleClasses.Phase3;
using Monad.ExampleClasses.Phase3.Imperative;
using Monad.ExampleClasses.Phase3.Monad;
using Monad.Monads;
using System.Reflection;
using System.Threading.Channels;

//Monads are a design pattern that allows a user to chain operations while the monad manages secret work behind the scenes

//What is a monad in C#?
//async/await/Task is a monad => await to unpack the value
//.SelectMany is monad (flatten) => List<T>.SelectMany(Func<T, List<T>> f).SelectMany(Func<T, List<T>> f)
//Nullable => T?


//Phase 1: Road to Monads
//P1V1:
static int SquareV1(int x)
{
    return x * x;
}

static int AddOneV1(int x)
{
    return x + 1;
}

Console.WriteLine("P1V1:");
Console.WriteLine(AddOneV1(SquareV1(2))); 
Console.WriteLine(SquareV1(AddOneV1(2))); 
Console.WriteLine(SquareV1(SquareV1(2))); 
Console.WriteLine(AddOneV1(AddOneV1(2)));
Console.WriteLine();

//P1V2:
//Issues:
// - Square: NumberWithLogs is not assignable to int
// - AddOne: Int is not assignable to NumberWithLogs

static NumberWithLogs SquareV2(int x)
{
    return new NumberWithLogs
    (
        result: x * x,
        logHistory: new List<string> { $"Squared {x} to get {x * x}" }
    );
}

static NumberWithLogs AddOneV2(NumberWithLogs x)
{
    return new NumberWithLogs
    (
        result: x.Result + 1,
        logHistory: x.Log,
        newLog: $"Added 1 to {x.Result} to get {x.Result + 1}"
    );
}

Console.WriteLine("P1V2:");
Console.WriteLine(AddOneV2(SquareV2(2)).Result); //Option1
Console.WriteLine(AddOneV2(SquareV2(2)).WriteLog()); //Option2
//Console.WriteLine(SquareV2(AddOneV2(2)));
//Console.WriteLine(SquareV2(SquareV2(2)));
//Console.WriteLine(AddOneV2(AddOneV2(2)));
Console.WriteLine();

//P1V3:
static NumberWithLogs SquareV3(NumberWithLogs x)
{
    return new NumberWithLogs
    (
        result: x.Result * x.Result,
        logHistory: x.Log,
        newLog: $"Squared {x.Result} to get {x.Result * x.Result}"
    );
}

static NumberWithLogs WrapWithLogsV3(int number)
{
    return new NumberWithLogs
    (
        result: number,
        logHistory: new List<string>()
    );
}

Console.WriteLine("P1V3:");
Console.WriteLine(AddOneV2(SquareV3(WrapWithLogsV3(2))));
Console.WriteLine(SquareV3(AddOneV2(WrapWithLogsV3(2))));
Console.WriteLine(SquareV3(SquareV3(WrapWithLogsV3(2))));
Console.WriteLine(AddOneV2(AddOneV2(WrapWithLogsV3(2))));
Console.WriteLine();

//P1V4:

static NumberWithLogs RunWithLogs(NumberWithLogs input, Func<int, NumberWithLogs> transform)
{
    NumberWithLogs transformedInput = transform(input.Result);

    return new NumberWithLogs
    (
        result: transformedInput.Result,
        logHistory: transformedInput.Log
    );
}

Console.WriteLine("P1V4:");
Console.WriteLine(RunWithLogs(WrapWithLogsV3(2), SquareV2));
Console.WriteLine();


//Phase 2: Nullable vs Maybe Monad
ImperativeBook dune = ImperativeBook.Create("Dune", ImperativePerson.Create("Frank", "Herbert"));
ImperativeBook iliad = ImperativeBook.Create("Iliad", ImperativePerson.Create("Homer"));
ImperativeBook gilgamesh = ImperativeBook.Create("The Epic of Gilgamesh");

Console.WriteLine("P2_ImperativeBook:");
Console.WriteLine(dune.GetLabel());
Console.WriteLine(iliad.GetLabel());
Console.WriteLine(gilgamesh.GetLabel());
Console.WriteLine();

MonadBook foundation = MonadBook.Create("Foundation", MonadPerson.Create("Isaac", "Asimov"));
MonadBook odyssey = MonadBook.Create("Odyssey", MonadPerson.Create("Homer"));
MonadBook oneThousandAndOneNights = MonadBook.Create("One Thousand and One Nights");

Console.WriteLine("P2_MonadBook:");
Console.WriteLine(foundation.GetLabel());
Console.WriteLine(odyssey.GetLabel());
Console.WriteLine(oneThousandAndOneNights.GetLabel());
Console.WriteLine();

//Phase 3: Design by Contract

DateTimeProvider dateTimeProvider = new();
ImperativeMovieService imperativeMovieService = new(dateTimeProvider);

Movie invalidId = new Movie { Id = 5, Title = "Interstellar", Year = 2014, Category = "Adventure, Drama, Sci-Fi" };
Movie invalidYear = new Movie { Id = 0, Title = "Interstellar", Year = 2035, Category = "Adventure, Drama, Sci-Fi" };
Movie validMovie = new Movie { Id = 2, Title = "Star Wars: Episode IV - A New Hope", Year = 1977, Category = "Action, Adventure, Fantasy" };

Console.WriteLine("P3_ImperativeMovieService:");
Console.WriteLine(imperativeMovieService.Update(validMovie)); 
Console.WriteLine(imperativeMovieService.Update(invalidId)); 
//Console.WriteLine(imperativeMovieService.Update(invalidYear)); 
Console.WriteLine();

MonadMovieService monadMovieService = new MonadMovieService(dateTimeProvider);

Console.WriteLine("P3_MonadMovieService:");
Console.WriteLine(monadMovieService.Update(validMovie));
Console.WriteLine(monadMovieService.Update(invalidId));
Console.WriteLine(monadMovieService.Update(invalidYear));
Console.WriteLine();

var result = monadMovieService.Update(validMovie);

if (result)
{
    Console.WriteLine("Success: " + result);
}
else
{
    Console.WriteLine("Failure: " + result);
}

var result2 = result.Match(
                onSuccess => "Success: " + onSuccess,
                onFailure => "Failure: " + onFailure
              );

Console.WriteLine(result2);

Movie validMovie2 = new Movie { Id = 2, Title = "The Terminator", Year = 1984, Category = "Action, Sci-Fi" };

var result3 = monadMovieService.GetById(2).Bind(GetMovie =>
              monadMovieService.Update(validMovie2).Bind(UpdatedMovie =>
              Result<Movie, DomainError>.Success(UpdatedMovie)
));

Console.WriteLine(result3);