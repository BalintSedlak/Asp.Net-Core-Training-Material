using static Monad.ExampleClasses.Phase3.Monad.DomainErrorList;

namespace Monad.ExampleClasses.Phase3.Monad;

public static class DomainErrorList
{
    public static class Movie
    {
        public static DomainError MovieNotFound(int movieId)
        {
            return new DomainError("Movie.NotFound", 422, $"Movie with ID {movieId} not found.", $"Movie.NotFound: Movie with ID {movieId} not found.");
        }

        public static DomainError InvalidMovieYear(int maxYear)
        {
            return new DomainError("Movie.Validation.InvalidYear", 422, $"Invalid movie year. Year should be between {1888} and {maxYear}", $"Invalid movie year. Year should be between {1888} and {maxYear}");
        }

        public static readonly DomainError MovieTitleEmpty = new DomainError("Movie.Validation.TitleEmpty", 422, "Movie title cannot be empty.", "Movie title cannot be empty.");
        public static readonly DomainError MovieCategoryEmpty = new DomainError("Movie.Validation.CategoryEmpty", 422, "Movie category cannot be empty.", "Movie category cannot be empty.");
    }
}