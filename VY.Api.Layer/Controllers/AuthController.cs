using Microsoft.AspNetCore.Mvc;
using VY.Business.Layer.Auth.Abstarct;
using VY.Business.Layer.Auth.DTO;

namespace VY.Api.Layer.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [Route("register") ,HttpPost]
        public IActionResult register(RegisterDTO register)
        {
            return Ok(authService.Register(register));            
        }

        [Route("login"), HttpPost]
        public IActionResult login(LoginDTO login)
        {
            return Ok(authService.Login(login));
        }
        [Route("verify/{verify}"), HttpGet]
        public IActionResult verifymail(Guid verify)
        {
            return Ok(authService.verifyEmail(verify));
        }
        [Route("rverify/{mail}"), HttpGet]
        public async Task<IActionResult> Rverifymail(string mail)
        {
            return Ok( await authService.sendVerify(mail));
        }
        [Route("getupdatepasslink/{mail}"), HttpGet]
        public IActionResult getPasswordLink(string mail)
        {
            return Ok(authService.getPasswordUpdateLink(mail));
        }
        [Route("updatepass/{verifyid}"), HttpPost]
        public IActionResult passwordUpdate(Guid verifyid,string password)
        {
            return Ok(authService.passwordUpdate(password,verifyid));
        }
    }
}
