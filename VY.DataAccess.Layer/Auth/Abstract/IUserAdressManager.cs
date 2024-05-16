using VY.Core.Layer.DataAcess.EFCore;
using VY.Entity.Layer.Table.AddressTables;

namespace VY.DataAccess.Layer.Auth.Abstract
{
    public interface IUserAdressManager:
        IBaseRepository<VyUserAdressTable>
    {
    }
}
