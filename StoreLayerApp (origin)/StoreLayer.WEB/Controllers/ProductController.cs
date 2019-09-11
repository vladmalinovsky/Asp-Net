using AutoMapper;
using StoreLayer.WEB.Models;
using StoreLayerApp.BLL.DTO;
using StoreLayerApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreLayer.WEB.Controllers
{
    public class ProductController : Controller
    {
        IProductService productService;

        public ProductController(IProductService serv)
        {
            productService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<ProductDTO> productDtos = productService.getProducts();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>()).CreateMapper();
            var products = mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(productDtos);
            return View(products);
        }

        public ActionResult CreateProduct()
        {
            return View(new ProductViewModel());
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductViewModel product)
        {

            var productDto = new ProductDTO { Id = product.Id, Name = product.Name, Description = product.Description, Price = product.Price };
            productService.createProduct(productDto);
            return Redirect("/Product/Index");
        }

        public ActionResult EditProduct(int id)
        {
            
          ProductDTO productDTO = productService.getProduct(id);
            var product = new ProductViewModel
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price
            };
          return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(ProductViewModel product)
        {
            var productDTO = new ProductDTO { Id = product.Id, Name = product.Name, Description = product.Description, Price = product.Price };
            productService.editProduct(productDTO);
            return Redirect("/Product/Index");
        }

        public ActionResult DeleteProduct(int id)
        {
           productService.deleteProduct(id);
           return Redirect("/Product/Index");
        }
    }
}