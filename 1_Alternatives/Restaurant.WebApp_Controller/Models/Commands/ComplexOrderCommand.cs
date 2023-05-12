namespace Restaurant.WebApp_Controller.Models.ViewModels;

public class ComplexOrderCommand
{
    public IEnumerable<int> Foods { get; set; }
    public IEnumerable<int> Drinks { get; set; }
    public IEnumerable<int> Desserts { get; set; }
}