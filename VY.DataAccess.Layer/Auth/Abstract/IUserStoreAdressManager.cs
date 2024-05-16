using VY.Core.Layer.DataAcess.EFCore;
using VY.DataAccess.Layer.DbContexts;
using VY.Entity.Layer.Table.AddressTables;

namespace VY.DataAccess.Layer.Auth.Abstract
{
    public interface IUserStoreAdressManager :
        IBaseRepository<VyUserStoreAdressTable>
    {
    }
}
