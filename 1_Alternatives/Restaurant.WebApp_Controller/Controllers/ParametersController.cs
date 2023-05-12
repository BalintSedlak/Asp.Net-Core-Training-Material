using Azure;
using Microsoft.AspNetCore.Mvc;
using Restaurant.WebApp_Controller.Models.DTOs;
using Restaurant.WebApp_Controller.Models.ViewModels;
using System.Collections.Generic;

namespace Restaurant.WebApp_Controller.Controllers;

[ApiController]
[Route("[controller]")]
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

    //Order with simple type from body
    [HttpGet("Order/DrinkWithIce/{id}")]
    public string GetFromBody(int id, [FromBody] bool isItWithIce)
    {
        string response = _drinks[id];

        response += isItWithIce ? " with ice" : string.Empty;

        return response;
    }

    //Order with complex type
    [HttpGet("Order/Complex")]
    public ComplexOrderResponse GetComplexOrder([FromForm] ComplexOrderCommand viewModel)
    {
        if (viewModel is null)
        {
            throw new ArgumentNullException(nameof(viewModel));
        }

        ComplexOrderResponse complexOrderDTO = new();

        foreach (var id in viewModel.Drinks)
        {
            complexOrderDTO.Orders.Add(_drinks[id]);
        }

        foreach (var id in viewModel.Foods)
        {
            complexOrderDTO.Orders.Add(_foods[id]);
        }

        foreach (var id in viewModel.Desserts)
        {
            complexOrderDTO.Orders.Add(_desserts[id]);
        }

        return complexOrderDTO;
    }

    //Order with complex type in uri (It's not FromUri!!!)
    [HttpGet("Order/Food/Delivery/{id}/")]
    public string GetFromBody(int id, [FromQuery] FoodDeliveryCommand viewModel)
    {
        string response = $"{_foods[id]} deliverd to {viewModel.ZipCode}, {viewModel.Street}";

        return response;
    }
}
