namespace ShoppingCartEnhancement.Model
{

    public class CartItem
    {
        public string ItemName { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Quantity { get; set; }

    }

    public class ShoppingCart
    {
        public string CartId { get; set; } = string.Empty;
        public List<CartItem> Items { get; set; } = new();
        public double Total => Items.Sum(i => i.Price * i.Quantity);
    }

}
