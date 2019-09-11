using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace StoreCar.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
            
        public List<CartLine> lineCollection = new List<CartLine>();

        public string UserName { get; set; }

        public double TotalPrice { get; set; }

        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
            .Where(p => p.Product.Id == product.Id)
            .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
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
        public void RemoveLine(Product product)
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
        public ICollection<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int? Product_Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

}
