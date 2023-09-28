using Monad.ExampleClasses.Phase1;
using Monad.ExampleClasses.Phase2;

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

Console.WriteLine("Phase1:");
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

Console.WriteLine("Phase2:");
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

Console.WriteLine("Phase3:");
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

Console.WriteLine("Phase4:");
Console.WriteLine(RunWithLogs(WrapWithLogsV3(2), SquareV2));
Console.WriteLine();


//Phase 2: Nullable vs Maybe Monad
ImperativeBook dune = ImperativeBook.Create("Dune", ImperativePerson.Create("Frank", "Herbert"));
ImperativeBook iliad = ImperativeBook.Create("Iliad", ImperativePerson.Create("Homer"));
ImperativeBook gilgamesh = ImperativeBook.Create("The Epic of Gilgamesh");

Console.WriteLine(dune.GetLabel());
Console.WriteLine(iliad.GetLabel());
Console.WriteLine(gilgamesh.GetLabel());

MonadBook foundation = MonadBook.Create("Foundation", MonadPerson.Create("Isaac", "Asimov"));
MonadBook odyssey = MonadBook.Create("Odyssey", MonadPerson.Create("Homer"));
MonadBook oneThousandAndOneNights = MonadBook.Create("One Thousand and One Nights");

Console.WriteLine(foundation.GetLabel());
Console.WriteLine(odyssey.GetLabel());
Console.WriteLine(oneThousandAndOneNights.GetLabel());