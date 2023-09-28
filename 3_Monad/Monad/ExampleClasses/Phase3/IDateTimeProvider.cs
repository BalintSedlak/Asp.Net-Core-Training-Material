namespace Monad.ExampleClasses.Phase3;

public interface IDateTimeProvider
{
    DateTime Now { get; }
    DateTime UtcNow { get; }
}