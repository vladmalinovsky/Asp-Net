using StoreLayerApp.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace StoreLayerApp.BLL.DTO
{
    public class CartDTO
    {
        public int Id { get; set; }

        public List<CartLineDTO> lineCollection = new List<CartLineDTO>();

        public string UserName { get; set; }

        public double TotalPrice { get; set; }

        public void AddItem(ProductDTO product, int quantity)
        {
            CartLineDTO line = lineCollection
            .Where(p => p.Product.Id == product.Id)
            .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLineDTO
                {
                    Product = product,
                    Quantity = quantity
                });

            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(ProductDTO product)
        {
            lineCollection.RemoveAll(l => l.Product.Id == product.Id);
        }
        public double ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
        public ICollection<CartLineDTO> Lines
        {
            get { return lineCollection; }
        }
    }
}
