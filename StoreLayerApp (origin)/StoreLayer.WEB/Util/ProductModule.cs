using Ninject.Modules;
using StoreLayerApp.BLL.Interfaces;
using StoreLayerApp.BLL.Services;

namespace StoreLayer.WEB.Util
{
    public class ProductModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductService>();
        }
    }
}