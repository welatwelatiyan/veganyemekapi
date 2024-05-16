using VY.Core.Layer.DataAcess.EFCore;
using VY.Entity.Layer.Table.authTable;

namespace VY.DataAccess.Layer.Auth.Abstract
{
    public interface IAuthMAnager : 
        IBaseRepository<VyUserTable>
    {
    }
}
