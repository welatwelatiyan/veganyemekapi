using VY.Business.Layer.Auth.DTO;
using VY.Core.Layer.Utilities.Results.DataResult;
using VY.Core.Layer.Utilities.Results.Result;
using VY.Core.Layer.Utilities.Security.JWT;

namespace VY.Business.Layer.Auth.Abstarct
{
    public interface IAuthService
    {
        IResult Register(RegisterDTO register);
        IDataResult<AccessToken> Login(LoginDTO login);
        IResult verifyEmail(Guid id);
        Task<IResult> sendVerify(string email);
        IResult getPasswordUpdateLink(string email);
        IResult passwordUpdate(string password, Guid verifyId);
    }
}
