using VY.Core.Layer.DataAcess.EFCore;
using VY.DataAccess.Layer.Auth.Abstract;
using VY.DataAccess.Layer.DbContexts;
using VY.Entity.Layer.Table.AddressTables;

namespace VY.DataAccess.Layer.Auth.Concreate
{
    public class StoreAdressManager : 
        BaseRepository<VyStoreAdressTable, AuthContext>, IStoreAdressManager
    {
        public StoreAdressManager(AuthContext context) : base(context)
        {
        }
    }
}
