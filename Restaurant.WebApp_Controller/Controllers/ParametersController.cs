using Microsoft.AspNetCore.Mvc;

namespace Restaurant.WebApp_Controller.Controllers;

[ApiController]
[Route("Parameters")]
public class ParametersController : Controller
{
    private readonly List<string> _foods = new(){"Yakiniku", "Tortilla", "Croissant", "Tofu", "Noodles", "Tacos", "Ramen", "Burger", "Sushi", "Pizza"};
    private readonly List<string> _desserts = new(){"Tiramisu", "Chocolate mousse", "Creme brulee", "Ice-cream", "Cheesecake", "Apple berry crumble", "Puddings", "Cherry strudel", "Banana split", "Almond strawberry roulade" };
    private readonly List<string> _drinks = new(){"Margarita", "Cosmopolitan", "Negroni", "Moscow Mule", "Martini", "Mojito", "Whiskey Sour", "French 75", "Manhattan", "Vesper" };

    //just a slug
    [HttpGet("Foodlist")]
    public IEnumerable<string> GetFoodlist()
    {
        return _foods;
    }

    //Required id parameter
    [HttpGet("Foodlist/{id}")]
    public string GetFoodlist(int id)
    {
        return _foods[id];
    }

    //Optional id parameter
    [HttpGet("DrinkList/{id?}")]
    public IEnumerable<string> GetDrinklist(int? id)
    {
        if (id == null)
        {
            return _drinks;
        }

        return new List<string> { _drinks[id.GetValueOrDefault()] };
    }

    //Optional id parameter with constraints
    [HttpGet("Dessertist/{id:int:max(10)?}")]
    public IEnumerable<string> GetDessertist(int? id)
    {
        if (id == null)
        {
            return _desserts;
        }

        return new List<string> { _desserts[id.GetValueOrDefault()] };
    }

    //Two optional int parameter, one with deafult value
    [HttpGet("Order/{category}/{id?}/{count=1}")]
    public IEnumerable<string> GetDessertist(string category, int? id, int? count)
    {
        IEnumerable<string> list;
        List<string> response = new();

        if (category.ToLower() == "food")
        {
            list = _foods;
        }
        else if (category.ToLower() == "drink")
        {
            list = _drinks;
        }
        else if (category.ToLower() == "dessert")
        {
            list = _desserts;
        }

        for (int i = 0; i < count; i++)
        {
            response.Add(_desserts[id.GetValueOrDefault()]);
        }

        return response;
    }

    /*
     * By default, Web API uses the following rules to bind parameters:
     * 
     * If the parameter is a "simple" type, Web API tries to get the value from the URI. Simple types include the .NET
     * primitive types (int, bool, double, and so forth), plus TimeSpan, DateTime, Guid, decimal, and string, plus any
     * type with a type converter that can convert from a string. (More about type converters later.)
     * 
     * For complex types, Web API tries to read the value from the message body, using a media-type formatter.
     */
}
