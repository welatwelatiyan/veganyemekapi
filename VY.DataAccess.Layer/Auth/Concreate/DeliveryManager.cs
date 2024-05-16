using VY.Core.Layer.DataAcess.EFCore;
using VY.DataAccess.Layer.Auth.Abstract;
using VY.DataAccess.Layer.DbContexts;
using VY.Entity.Layer.Table.Delivery;

namespace VY.DataAccess.Layer.Auth.Concreate
{
    public class DeliveryManager : 
        BaseRepository<VyDeliveryTable, AuthContext>, IDeliveryManager
    {
        public DeliveryManager(AuthContext context) : base(context)
        {
        }
    }
}
