namespace Monad.ExampleClasses.Phase2;

public class ImperativeBook
{
    public string Title { get; init; }
    public ImperativePerson? Author { get; init; }

    private ImperativeBook(string title, ImperativePerson? author) => (Title, Author) = (title, author);

    public static ImperativeBook Create(string title, ImperativePerson author) => new(title, author);
    public static ImperativeBook Create(string title) => new(title, null);

    public string GetLabel()
    {
        string? author = GetAuthorLabel();

        return author is string ? $"{Title} by {author}" : Title;
    }

    public string? GetAuthorLabel()
    {
        if (Author is null)
        {
            return null;
        }

        return Author!.LastName is null ? Author.FirstName : $"{Author.FirstName} {Author.LastName}";
    }
}
