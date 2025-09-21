using Microsoft.AspNetCore.Mvc;
using ShoppingCartEnhancement.Services;

namespace ShoppingCartEnhancement.Controllers
{
    [ApiController]
    [Route("shop")]
    public class ShoppingCartController : ControllerBase
    {
        //constructor injection in Dependency Injection (DI).
        private readonly IShoppingCartService _service;
        public ShoppingCartController(IShoppingCartService service) => _service = service;

        [HttpPost("addItem")]
        public IActionResult AddItem(string cartId, string itemName, double price, int quantity)
        {
            var cart = _service.AddItem(cartId, itemName, price, quantity);
            return Ok(new { message = "Item added", total = cart.Total });
        }

        [HttpGet("getTotal")]
        public IActionResult GetTotal(string cartId)
        {
            var total = _service.GetTotal(cartId);
            return Ok(new { cartId, total });
        }
    }
   
}
