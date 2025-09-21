using ShoppingCartEnhancement.Model;
using ShoppingCartEnhancement.Repo;

namespace ShoppingCartEnhancement.Services
{
    //business logic 
    public class ShoppingCartService : IShoppingCartService
    {
        public readonly IShoppingCartRepository _repo;
        //one-liner assignment by using => as means of return
        public ShoppingCartService(IShoppingCartRepository repo) => _repo = repo;

        public ShoppingCart AddItem(string cartId, string name, double price, int qty)
         => _repo.AddItem(cartId, name, price, qty);

        public double GetTotal(string cartId)
            => _repo.GetTotal(cartId);
    }
}
