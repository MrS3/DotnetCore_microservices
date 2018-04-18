using System.Threading.Tasks;

namespace ShoppingCart.ShoppingCart
{
    public interface IShoppingCartStore
    {
        ShoppingCart Get(int userid);
        void Save(ShoppingCart item);
    }
}