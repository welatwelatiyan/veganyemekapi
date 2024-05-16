using VY.Core.Layer.DataAcess.EFCore;
using VY.DataAccess.Layer.Auth.Abstract;
using VY.DataAccess.Layer.DbContexts;
using VY.Entity.Layer.Table.Product;

namespace VY.DataAccess.Layer.Auth.Concreate
{
    public class ProductManager : BaseRepository<VyProductTable, AuthContext>, IProductManager
    {
        public ProductManager(AuthContext context) : base(context)
        {
        }
    }
}
