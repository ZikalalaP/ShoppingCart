using Microsoft.AspNetCore.Mvc;

namespace ShoppingCartEnhancement.Controllers
{
  
    public class ShoppingCartController(IShoppingCartService shoppingCart) : ControllerBase
    {
        //DI of the service
        private readonly IShoppingCartService _shoppingCartService = shoppingCart;


        [HttpGet("shoppingCart")]
        public async Task<IActionResult> GetShoppingCart(string cartId, string itemName, double price, int quantity)
        {
            var response = await _shoppingCartService.GetShoppingCart(cartId);
            return 
        }

    }
}
