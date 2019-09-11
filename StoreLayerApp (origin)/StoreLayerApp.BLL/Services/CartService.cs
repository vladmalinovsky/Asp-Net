using StoreLayerApp.BLL.DTO;
using StoreLayerApp.BLL.Interfaces;
using StoreLayerApp.DAL.Entities;
using StoreLayerApp.DAL.Interfaces;
using System.Web;
using System;

namespace StoreLayerApp.BLL.Services
{
    public class CartService : ICartService
    {
        IUnitOfWork Database { get; set; }

        public CartService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Checkout(CartDTO cartDTO)
        {

            Cart cart = new Cart
            {
                Id = cartDTO.Id,
                TotalPrice = cartDTO.ComputeTotalValue(),
                UserName = cartDTO.UserName
            };
            
            foreach (var item in cartDTO.lineCollection)
            {
                cart.lineCollection.Add(new CartLine { Id = item.Id, Product_Id = item.Product_Id, Quantity = item.Quantity,
                    Product = 
                    new Product { Id = item.Product.Id, Description = item.Product.Description, Name = item.Product.Name, Price = item.Product.Price}
                });
            }
           foreach (var line in cart.Lines)
            {
                Database.Products.Attach(line.Product);
            }
            Database.Carts.Create(cart);
            Database.Save();
        }
    }
}

