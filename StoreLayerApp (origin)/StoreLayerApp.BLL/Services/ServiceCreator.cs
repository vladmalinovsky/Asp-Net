using StoreLayerApp.BLL.Interfaces;
using StoreLayerApp.DAL.Repositories;

namespace StoreLayerApp.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityUnitOfWork(connection));
        }
    }
}
