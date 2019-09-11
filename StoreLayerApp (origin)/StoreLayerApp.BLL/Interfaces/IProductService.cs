using StoreLayerApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLayerApp.BLL.Interfaces
{
    public interface IProductService
    {
        void createProduct(ProductDTO product);
        void editProduct(ProductDTO product);
        void deleteProduct(int id);

        ProductDTO getProduct(int id);
        IEnumerable<ProductDTO> getProducts();
    }
}
