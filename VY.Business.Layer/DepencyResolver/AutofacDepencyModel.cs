using Autofac;
using VY.Core.Layer.Extension;
using VY.DataAccess.Layer.DepencyResolver;

namespace VY.Business.Layer.DepencyResolver
{
    public class AutofacDepencyModel:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.AddCoreDepency();
            builder.AddAuthMAnagerDepency();
            builder.AddAuthServiceDepency();
        }
    }
}
