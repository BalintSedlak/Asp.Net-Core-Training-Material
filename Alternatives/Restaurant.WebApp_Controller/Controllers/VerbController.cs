using Microsoft.AspNetCore.Mvc;
using Restaurant.WebApp_Controller.Models.ViewModels;

namespace Restaurant.WebApp_Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class VerbController : Controller
{
    /*HTTP defines a set of request methods to indicate the desired action to be performed for a given resource.
    *A request method can be safe, idempotent, or cacheable.
    *
    *Safe:
    *An HTTP method is safe if it doesn't alter the state of the server. In other words, a method is safe if it leads to a read-only operation.
    *Several common HTTP methods are safe: GET, HEAD, or OPTIONS.
    *
    *All safe methods are also idempotent, but not all idempotent methods are safe. 
    *For example, PUT and DELETE are both idempotent but unsafe.
    *
    *Idempotent:
    *An HTTP method is idempotent if the intended effect on the server of making a single request is the same as the effect of making several identical requests.
    *
    *All safe methods are idempotent, as well as PUT and DELETE. The POST method is not idempotent.
    *
    *To be idempotent, only the state of the server is considered. The response returned by each request may differ: 
    *for example, the first call of a DELETE will likely return a 200, while successive ones will likely return a 404. 
    *Another implication of DELETE being idempotent is that developers should not implement RESTful APIs with a delete last entry functionality using the DELETE method.
    *
    *Cacheable:
    *A cacheable response is an HTTP response that can be cached, that is stored to be retrieved and used later, 
    *saving a new request to the server. Not all HTTP responses can be cached, these are the following constraints for an HTTP response to be cached:
    *
    *The method used in the request is itself cacheable, that is either a GET or a HEAD method. 
    *A response to a POST or PATCH request can also be cached if freshness is indicated and the Content-Location header is set, but this is rarely implemented. 
    *For example, Firefox does not support it (Firefox bug 109553). 
    *Other methods, like PUT or DELETE are not cacheable and their result cannot be cached.
    *
    *The status code of the response is known by the application caching, and it is considered cacheable. 
    *The following status code are cacheable: 200, 203, 204, 206, 300, 301, 404, 405, 410, 414, and 501.
    *
    *There are specific headers in the response, like Cache-Control, that prevents caching.
    */

    
    private static List<DrinkViewModel> _drinks = new() { new DrinkViewModel(0, "Margarita", 10), new DrinkViewModel(1, "Mojito", 12), new DrinkViewModel(2, "Martini", 7), new DrinkViewModel(3, "Whiskey", 11) };

    [HttpGet("[action]")]
    public IEnumerable<DrinkViewModel> GetAllDrink()
    {
        return _drinks;
    }

    [HttpPost("[action]")]
    public IEnumerable<DrinkViewModel> PostNewDrink([FromForm] DrinkViewModel viewModel)
    {
        _drinks.Add(viewModel);

        return _drinks;
    }

    //                  | PUT | PATCH |
    //                  |     |       |
    //Partial Updates   |  X  |   O   |
    //                  |     |       |
    //Creates a resource|  O  |   X   |
    //                  |     |       |
    //Idempotent        |  O  |   X   |
    //                  |     |       |
    //Safe              |  X  |   X   |
    //                  |     |       |

    [HttpPut("[action]")]
    public IEnumerable<DrinkViewModel> PutDrink([FromForm] DrinkViewModel viewModel)
    {
        _drinks[viewModel.Id] = viewModel;

        return _drinks;
    }

    [HttpPatch("[action]")]
    public IEnumerable<DrinkViewModel> PatchDrinkItemPrice([FromQuery] int id, [FromQuery] int drinkPrice)
    {
        _drinks[id].Price = drinkPrice;

        return _drinks;
    }

    [HttpDelete("[action]/{id}")]
    public IEnumerable<DrinkViewModel> DeleteDrink(int id)
    {
        _drinks.RemoveAt(id);

        return _drinks;
    }
}
