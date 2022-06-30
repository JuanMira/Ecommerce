using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

[ApiController]
[Route("/cart")]
[Authorize]
public class CartControler : ControllerBase
{
    public CartControler()
    {
    }

    [HttpPost]
    [Route("/createProduct")]
    public IActionResult CreateProduct()
    {
        return Ok();
    }
}