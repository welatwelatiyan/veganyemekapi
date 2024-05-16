using VY.Core.Layer.DataAcess.EFCore;
using VY.DataAccess.Layer.Auth.Abstract;
using VY.DataAccess.Layer.DbContexts;
using VY.Entity.Layer.Table.StoreTable;

namespace VY.DataAccess.Layer.Auth.Concreate
{
    public class StoreManager : 
        BaseRepository<VyStoreTable, AuthContext>, IStoreManager
    {
        public StoreManager(AuthContext context) : base(context)
        {
        }
    }
}
