using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VY.Business.Layer.Auth.Abstarct;
using VY.Business.Layer.Auth.DTO;

namespace VY.Api.Layer.Controllers
{
    [Authorize(Roles = "user")]
    [Route("api/useradress")]
    [ApiController]
    public class UserAdressController : ControllerBase
    {
        private IUserAdressService userAdress;

        public UserAdressController(IUserAdressService userAdress)
        {
            this.userAdress = userAdress;
        }

        [HttpGet]
        public IActionResult getAdress()
        {
            return Ok(userAdress.getUserAdresses(
                new Guid(HttpContext.User.
                FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

        [HttpPost]
        public IActionResult setAdress(UserAdressDTO Adress)
        {
            return Ok(userAdress.setAddress(Adress,
                new Guid(HttpContext.User.
                FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

        [Route("{adressid}"),HttpPut]
        public IActionResult updateAdress(UserAddresUpdateDTO Adress,Guid adressid)
        {
            return Ok(userAdress.updateAddress(Adress, adressid,
                new Guid(HttpContext.User.
                FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

    }
}
