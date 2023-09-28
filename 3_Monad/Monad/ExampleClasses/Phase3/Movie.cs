namespace Monad.ExampleClasses.Phase3;
public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public string Category { get; set; }

    public override string ToString()
    {
        return $"Movie Id: {Id}, Title: {Title}, Year: {Year}, Category: {Category}";
    }
}
