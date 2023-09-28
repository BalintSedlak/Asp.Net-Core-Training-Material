using Monad.Monads;

namespace Monad.ExampleClasses.Phase2;

public class MonadPerson
{
    public string FirstName { get; init; }
    public Maybe<string> LastName { get; init; }

    private MonadPerson(string firstName, Maybe<string> lastName) => (FirstName, LastName) = (firstName, lastName);

    public static MonadPerson Create(string firstName, string lastName) => new(firstName, Maybe<string>.Some(lastName));
    public static MonadPerson Create(string name) => new(name, Maybe<string>.None());
}
