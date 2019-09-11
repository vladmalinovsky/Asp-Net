using StoreLayerApp.BLL.DTO;

namespace StoreLayerApp.BLL.Interfaces
{
    public interface ICartService
    {
        void Checkout(CartDTO cartDTO);
      
    }
}
