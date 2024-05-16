using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VY.Business.Layer.Auth.Abstarct;
using VY.Business.Layer.Auth.Concreate;
using VY.Business.Layer.Auth.DTO.Store;

namespace VY.Api.Layer.Controllers
{
    [Authorize(Roles = "seller")]
    [Route("api/storeadress")]
    [ApiController]
    public class StoreAdressController : ControllerBase
    {
        private IStoreAdressService storeAdressService;

        public StoreAdressController(IStoreAdressService storeAdressService)
        {
            this.storeAdressService = storeAdressService;
        }

        [HttpGet]
        public IActionResult getStoreAdress()
        {
            return Ok(storeAdressService.get(
                 new Guid(HttpContext.User.
                 FindFirst(ClaimTypes.NameIdentifier).Value)));
        }
        [HttpPost]
        public IActionResult setAdress(StoreAdressDTO adressDTO)
        {
            return Ok(storeAdressService.set(adressDTO,
                 new Guid(HttpContext.User.
                 FindFirst(ClaimTypes.NameIdentifier).Value)));
        }
        [HttpPut]
        public IActionResult updateAdress(StoreAdressDTO adressDTO)
        {
            return Ok(storeAdressService.update(adressDTO,
                 new Guid(HttpContext.User.
                 FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

    }
}
