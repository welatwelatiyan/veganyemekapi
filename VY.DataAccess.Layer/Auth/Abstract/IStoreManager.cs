using VY.Core.Layer.DataAcess.EFCore;
using VY.Entity.Layer.Table.StoreTable;

namespace VY.DataAccess.Layer.Auth.Abstract
{
    public interface IStoreManager:
        IBaseRepository<VyStoreTable>
    {
    }
}
