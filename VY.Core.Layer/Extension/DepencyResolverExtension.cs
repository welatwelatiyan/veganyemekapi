using Autofac;
using VY.Core.Layer.Utilities.Security.JWT;

namespace VY.Core.Layer.Extension
{
    public static class DepencyResolverExtension
    {
        public static void AddCoreDepency(this ContainerBuilder builder)
        {
            builder.RegisterType<JWTHelper>().As<ITokenHelper>();
        }
    }
}
