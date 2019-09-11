using Ninject.Modules;
using StoreLayerApp.BLL.Interfaces;
using StoreLayerApp.BLL.Services;

namespace StoreLayer.WEB.Util
{
    public class CartModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICartService>().To<CartService>();
        }
    }
}