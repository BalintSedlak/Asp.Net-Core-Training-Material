using Monad.Monads;

namespace Monad.ExampleClasses.Phase2;

public class MonadBook
{
    public string Title { get; init; }
    public Maybe<MonadPerson> Author { get; init; }

    private MonadBook(string title, Maybe<MonadPerson> author) => (Title, Author) = (title, author);

    public static MonadBook Create(string title, MonadPerson author) => new(title, Maybe<MonadPerson>.Some(author));
    public static MonadBook Create(string title) => new(title, Maybe<MonadPerson>.None());

    public string GetLabel()
    {
        return Author.Match(
                      onAuthorExists => onAuthorExists.LastName
                                                      .Map(lastName => $"{Title} by {onAuthorExists.FirstName} {lastName}")
                                                      .Reduce($"{Title} by {onAuthorExists.FirstName}"),
                      () => Title
        );
    }
}
