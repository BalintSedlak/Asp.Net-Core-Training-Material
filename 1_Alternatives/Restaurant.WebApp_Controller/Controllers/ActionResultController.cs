using Microsoft.AspNetCore.Mvc;

namespace Restaurant.WebApp_Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class ActionResultController : Controller
{
    /* IActionResult
     In the strictest sense, Action Results are any class which implements the IActionResult interface from ASP.NET Core MVC. 
     
     In short, Action Results are classes which represent things the client is supposed to do as a result of the controller action. 
    They may need to get a file, or redirect, or any of a myriad things. Some Action Results merely return an HTTP status code. 
    In short, the most common things the client might want to do after calling a controller action are represented as Action Results.
     
     */

    //The OkResult (short method: Ok()) return the 200 OK status code.
    [HttpGet("Ok")]
    public IActionResult OkResult()
    {
        return Ok();
    }

    //The CreatedResult (short method: Created()) returns 201 Created with a URL to the created resource.
    [HttpGet("Created")]
    public IActionResult CreatedResult()
    {
        return Created("http://example.org/myitem", new { name = "testitem" });
    }

    //The NoContentResult (short method: NoContent()) returns a 204 No Content status code,
    //indicating that the server successfully processed the request,
    //but that there is nothing to return.
    [HttpGet("NoContent")]
    public IActionResult NoContentResult()
    {
        return NoContent();
    }

    //The BadRequestResult (short method: BadRequest()) return 400 Bad Request,
    //which indicates that the server cannot process the request due to an error in said request.
    //This is often used in APIs when validation of the request fails (and there isn't a more specific code that would fit better).
    [HttpGet("BadRequest")]
    public IActionResult BadRequestResult()
    {
        return BadRequest();
    }

    //The UnauthorizedResult (short method: Unauthorized()) returns 401 Unauthorized,
    //indicating that the request cannot be processed because the user making the request doesn't have the appropriate authentication to do so
    //(meaning this status code should really have been called 401 Unauthenticated).
    [HttpGet("Unauthorized")]
    public IActionResult UnauthorizedResult()
    {
        return Unauthorized();
    }

    //The NotFoundResult (short method: NotFound()) returns the 404 Not Found status code,
    //indicating that the requested resource, for whatever reason, was not found on the server.
    [HttpGet("NotFound")]
    public IActionResult NotFoundResult()
    {
        return NotFound();
    }

    //The UnsupportedMediaTypeResult, which doesn't have a short method at the time of writing,
    //returns 415 Unsupported Media Type, indicating that the media type (e.g. the Content-Type header on the request) is not supported by this server.
    //For example, a server might return this status code if the user attempts to upload an image in the .bmp format, but the server only accepts .jpeg.
    [HttpGet("UnsupportedMediaTypeResult")]
    public IActionResult UnsupportedMediaTypeResult()
    {
        return new UnsupportedMediaTypeResult();
    }

    //The above status code results do not cover all the possible HTTP status codes (of which there are many).
    //For situations in which you need to return a status code which isn't given a dedicated action result,
    //we can use the generic StatusCodeResult (short method: StatusCode()).
    [HttpGet("StatusCode")]
    public IActionResult StatusCodeResult()
    {
        int statusCode = StatusCodes.Status418ImATeapot;

        return StatusCode(statusCode);
    }

    //The basic RedirectResult class (short method: Redirect()) redirects to a specified URL.
    [HttpGet("Redirect")]
    public IActionResult RedirectResult()
    {
        return Redirect("https://random.dog");
    }
}
