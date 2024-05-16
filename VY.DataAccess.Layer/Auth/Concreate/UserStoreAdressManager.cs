using VY.Core.Layer.DataAcess.EFCore;
using VY.DataAccess.Layer.Auth.Abstract;
using VY.DataAccess.Layer.DbContexts;
using VY.Entity.Layer.Table.AddressTables;

namespace VY.DataAccess.Layer.Auth.Concreate
{
    public class UserStoreAdressManager : 
        BaseRepository<VyUserStoreAdressTable, AuthContext>, IUserStoreAdressManager
    {
        public UserStoreAdressManager(AuthContext context) : base(context)
        {
        }
    }
}
