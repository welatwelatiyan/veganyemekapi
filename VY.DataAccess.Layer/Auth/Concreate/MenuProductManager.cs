using VY.Core.Layer.DataAcess.EFCore;
using VY.DataAccess.Layer.Auth.Abstract;
using VY.DataAccess.Layer.DbContexts;
using VY.Entity.Layer.Table.Product;

namespace VY.DataAccess.Layer.Auth.Concreate
{
    public class MenuProductManager : BaseRepository<VyMenuProductTable, AuthContext>, IMenuProductManager
    {
        public MenuProductManager(AuthContext context) : base(context)
        {
        }
    }
}
