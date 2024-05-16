using VY.Core.Layer.DataAcess.EFCore;
using VY.DataAccess.Layer.Auth.Abstract;
using VY.DataAccess.Layer.DbContexts;
using VY.Entity.Layer.Table.authTable;

namespace VY.DataAccess.Layer.Auth.Concreate
{
    public class AuthManager : 
        BaseRepository<VyUserTable, AuthContext>, IAuthMAnager
    {
        public AuthManager(AuthContext context) : base(context)
        {

        }
    }
}
