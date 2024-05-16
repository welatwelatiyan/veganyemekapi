using Autofac;
using VY.Business.Layer.Auth.Abstarct;
using VY.Business.Layer.Auth.Concreate;

namespace VY.Business.Layer.DepencyResolver
{
    public static class AuthResolver
    {
        public static void AddAuthServiceDepency(this ContainerBuilder builder)
        {
            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<MailService>().As<IMailService>();

            builder.RegisterType<StoreService>().As<IStoreService>();

            builder.RegisterType<UserAdressService>().As<IUserAdressService>();
            builder.RegisterType<StoreAdressService>().As<IStoreAdressService>();
            builder.RegisterType<UserStoreAdressService>().As<IUserStoreAdressService>().SingleInstance();

            builder.RegisterType<HttpService>().As<IHttpService>(); 
            builder.RegisterType<DistanceService>().As<IDistanceService>().SingleInstance(); 

            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<MenuService>().As<IMenuService>();
            builder.RegisterType<MenuProductService>().As<IMenuProductService>();
            builder.RegisterType<MenuKategoriService>().As<IMenuKategoriService>();


            builder.RegisterType<DeliveryService>().As<IDeliveryService>();
        }
    }
}
