using ShoppingCartEnhancement.Model;

namespace ShoppingCartEnhancement.Services
{
    public interface IShoppingCartService
    {
        ShoppingCart AddItem(string cartId, string name, double price, int qty);
        double GetTotal(string cartId);
    }
}
