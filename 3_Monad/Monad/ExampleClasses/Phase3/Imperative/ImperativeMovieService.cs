namespace Monad.ExampleClasses.Phase3.Imperative;

internal class ImperativeMovieService
{
    private Dictionary<int, Movie> _movies;
    private readonly IDateTimeProvider _dateTimeProvider;

    public ImperativeMovieService(IDateTimeProvider dateTimeProvider)
    {
        _movies = new Dictionary<int, Movie>
        {
            { 0, new Movie { Id = 0, Title = "Interstellar", Year = 2014, Category = "Adventure, Drama, Sci-Fi"} },
            { 1, new Movie { Id = 1, Title = "Blade Runner", Year = 1982, Category = "Action, Drama, Sci-Fi"} },
            { 2, new Movie { Id = 2, Title = "2001: A Space Odyssey", Year = 1968, Category = "Adventure, Sci-Fi" } }
        };

        _dateTimeProvider = dateTimeProvider;
    }

    private void ValidateAndThrow(Movie movie)
    {
        //Is this a real exceptional case or just a domain validation error?
        if (string.IsNullOrWhiteSpace(movie.Title))
        {
            throw new ModelValidationException("Movie title cannot be empty.");
        }

        if (movie.Year < 1888 || movie.Year > _dateTimeProvider.UtcNow.Year)
        {
            throw new ModelValidationException($"Invalid movie year. Year should be between {1888} and {_dateTimeProvider.UtcNow.Year}.");
        }

        if (string.IsNullOrWhiteSpace(movie.Category))
        {
            throw new ModelValidationException("Movie category cannot be empty.");
        }
    }

    public Movie? Update(Movie movie)
    {
        ValidateAndThrow(movie);
        bool isMovieExisits = _movies.ContainsKey(movie.Id);

        if (!isMovieExisits)
        {
            return null;
        }

        _movies[movie.Id] = movie;

        Movie result = _movies[movie.Id];
        return result;
    }

    public Movie? GetById(int id)
    {
        bool isMovieExisits = _movies.ContainsKey(id);

        if (!isMovieExisits)
        {
            return null;
        }

        return _movies[id];
    }
}
