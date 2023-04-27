namespace Restaurant.WebApp_Controller.Models.ViewModels;

public class ComplexOrderViewModel
{
    public IEnumerable<int> Foods { get; set; }
    public IEnumerable<int> Drinks { get; set; }
    public IEnumerable<int> Desserts { get; set; }
}