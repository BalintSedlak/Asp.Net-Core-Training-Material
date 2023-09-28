namespace Monad.ExampleClasses.Phase2;

public class ImperativePerson
{
    public string FirstName { get; init; }
    public string? LastName { get; init; }

    private ImperativePerson(string firstName, string? lastName) => (FirstName, LastName) = (firstName, lastName);

    public static ImperativePerson Create(string firstName, string lastName) => new(firstName, lastName);
    public static ImperativePerson Create(string name) => new(name, null);
}
