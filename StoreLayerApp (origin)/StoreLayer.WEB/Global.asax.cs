using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using StoreLayer.WEB.App_Start;
using StoreLayer.WEB.Binders;
using StoreLayer.WEB.Util;
using StoreLayerApp.BLL.DTO;
using StoreLayerApp.BLL.Infrastructure;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace StoreLayer.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule productModule = new ProductModule();
            NinjectModule cartModule = new CartModule();
            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            var kernel = new StandardKernel(productModule, cartModule, serviceModule);
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            ModelBinders.Binders.Add(typeof(CartDTO), new CartModelBinder());
        }
    }
}
