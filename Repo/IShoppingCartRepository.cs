using ShoppingCartEnhancement.Model;

namespace ShoppingCartEnhancement.Repo
{
    public interface IShoppingCartRepository
    {
        ShoppingCart GetCart(string cartId);
        ShoppingCart AddItem(string cartId, string name, double price, int qty);
        double GetTotal(string cartId);
    }
}
