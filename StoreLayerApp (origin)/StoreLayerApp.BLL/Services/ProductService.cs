using AutoMapper;
using StoreLayerApp.BLL.DTO;
using StoreLayerApp.BLL.Interfaces;
using StoreLayerApp.DAL.Entities;
using StoreLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLayerApp.BLL.Services
{
    public class ProductService : IProductService
    {
        IUnitOfWork Database { get; set; }

        public ProductService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void createProduct(ProductDTO productDTO)
        {
            Product product = new Product
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price
            };
            Database.Products.Create(product);
            Database.Save();
        }

        public void editProduct(ProductDTO productDTO)
        {
            Product product = new Product
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price
            };
            Database.Products.Update(product);
            Database.Save();
        }

        public void deleteProduct (int id)
        {
            Database.Products.Delete(id);
            Database.Save();
        }

        public IEnumerable<ProductDTO> getProducts()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll());
        }

        public ProductDTO getProduct(int id)
        {
            
            var product = Database.Products.Get(id);
            return new ProductDTO { Name = product.Name, Id = product.Id, Description = product.Description, Price = product.Price };
        }

    }
}
