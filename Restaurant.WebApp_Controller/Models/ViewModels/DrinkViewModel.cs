namespace Restaurant.WebApp_Controller.Models.ViewModels;

public class DrinkViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }

    public DrinkViewModel()
    {

    }

    public DrinkViewModel(int id, string name, int price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}
