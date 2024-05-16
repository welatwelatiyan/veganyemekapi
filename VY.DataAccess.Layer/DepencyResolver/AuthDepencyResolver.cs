using Autofac;
using VY.DataAccess.Layer.Auth.Abstract;
using VY.DataAccess.Layer.Auth.Concreate;
using VY.Entity.Layer.Table.Product;

namespace VY.DataAccess.Layer.DepencyResolver
{
    public static class AuthDepencyResolver
    {
        public static void AddAuthMAnagerDepency(this ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthMAnager>();
            builder.RegisterType<StoreManager>().As<IStoreManager>();
            builder.RegisterType<StoreAdressManager>().As<IStoreAdressManager>();
            builder.RegisterType<UserAdressManager>().As<IUserAdressManager>();
            builder.RegisterType<UserStoreAdressManager>().As<IUserStoreAdressManager>();   
            builder.RegisterType<ProductManager>().As<IProductManager>();
            builder.RegisterType<MenuManager>().As<IMenuManager>();
            builder.RegisterType<MenuProductManager>().As<IMenuProductManager>();
            builder.RegisterType<MenuKategoriManager>().As<IMenuKategoriManager>();
            builder.RegisterType<DeliveryManager>().As<IDeliveryManager>();
        }
    }
}
