using Microsoft.AspNetCore.Mvc;
using Restaurant.Infrasturcture.Entities;
using Restaurant.WebApp_Controller.DAL;

namespace Restaurant.WebApp_Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : Controller
{
    private readonly ControllerAppContext _controllerAppContext;

    public ProductController(ControllerAppContext controllerAppContext)
    {
        _controllerAppContext = controllerAppContext;
    }

    [HttpGet("Get")]
    public ProductEntity GetProduct()
    {
        ProductEntity product = _controllerAppContext.Products.First();

        return product;
    }
}
