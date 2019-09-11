using StoreLayerApp.DAL.Entities;

namespace StoreLayerApp.BLL.DTO
{
    public class CartLineDTO
    {
        public int Id { get; set; }
        public int? Product_Id { get; set; }
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
    }
}
