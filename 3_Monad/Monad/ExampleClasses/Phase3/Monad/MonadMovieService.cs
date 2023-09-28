using Monad.Monads;
using OneOf.Types;

namespace Monad.ExampleClasses.Phase3.Monad;

internal class MonadMovieService
{
    private Dictionary<int, Movie> _movies;
    private readonly IDateTimeProvider _dateTimeProvider;

    public MonadMovieService(IDateTimeProvider dateTimeProvider)
    {
        _movies = new Dictionary<int, Movie>
        {
            { 0, new Movie { Id = 0, Title = "Interstellar", Year = 2014, Category = "Adventure, Drama, Sci-Fi"} },
            { 1, new Movie { Id = 1, Title = "Blade Runner", Year = 1982, Category = "Action, Drama, Sci-Fi"} },
            { 2, new Movie { Id = 2, Title = "2001: A Space Odyssey", Year = 1968, Category = "Adventure, Sci-Fi" } }
        };

        _dateTimeProvider = dateTimeProvider;
    }

    private DomainError Validate(Movie movie)
    {
        if (string.IsNullOrWhiteSpace(movie.Title))
        {
            return DomainErrorList.Movie.MovieTitleEmpty;
        }

        if (movie.Year < 1888 || movie.Year > _dateTimeProvider.UtcNow.Year)
        {
            return DomainErrorList.Movie.InvalidMovieYear(_dateTimeProvider.UtcNow.Year);
        }

        if (string.IsNullOrWhiteSpace(movie.Category))
        {
            return DomainErrorList.Movie.MovieCategoryEmpty;
        }

        return null;
    }

    public Result<Movie, DomainError> Update(Movie movie)
    {
        var error = Validate(movie);

        if (error != null) 
        {
            return error;
        }

        bool isMovieExisits = _movies.ContainsKey(movie.Id);

        if (!isMovieExisits)
        {
            return DomainErrorList.Movie.MovieNotFound(movie.Id);
        }

        _movies[movie.Id] = movie;

        Movie result = _movies[movie.Id];
        return result;
    }

    public Result<Movie, DomainError> GetById(int id)
    {
        bool isMovieExisits = _movies.ContainsKey(id);

        if (!isMovieExisits)
        {
            return DomainErrorList.Movie.MovieNotFound(id);
        }

        return _movies[id];
    }
}
