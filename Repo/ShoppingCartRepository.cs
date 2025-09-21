using ShoppingCartEnhancement.Model;

namespace ShoppingCartEnhancement.Repo
{
    //Data storage
    public class ShoppingCartRepository: IShoppingCartRepository
    {
        //usage of in-memory dictionary to store carts
        private readonly Dictionary<string, ShoppingCart> _carts = new();

        public ShoppingCart GetCart(string cartId)
        {
            //get cart or create cart if doesn't exist
            if (!_carts.ContainsKey(cartId))
                _carts[cartId] = new ShoppingCart { CartId = cartId };

            return _carts[cartId];
        }

        //Adding items in the cart
        public ShoppingCart AddItem(string cartId, string name, double price, int qty)
        {
            var cart = GetCart(cartId);
            var existingItem = cart.Items.FirstOrDefault(i => i.ItemName == name && i.Price == price);
            
            //updating Item qty if it exists
            if (existingItem != null)
                existingItem.Quantity += qty;
            else
                cart.Items.Add(new CartItem { ItemName = name, Price = price, Quantity = qty });

            return cart;
        }

        //Getting the cart Total
        public double GetTotal(string cartId)
        {
            var cart = GetCart(cartId);
            return cart.Total;
        }
    }
}
