using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VY.Business.Layer.Auth.Abstarct;
using VY.Business.Layer.Auth.DTO.Store;

namespace VY.Api.Layer.Controllers
{
    [Route("api/store")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private IStoreService storeService;
    
        public StoreController(IStoreService storeService )
        {
            this.storeService = storeService;
        }
        [HttpPost]
        [Authorize(Roles ="user")]
        public IActionResult addStore (StoreDTO store)
        {

            return Ok(storeService.addStore(store,
                new Guid(HttpContext.User.
                FindFirst(ClaimTypes.NameIdentifier).Value)));
        }
        [HttpPut]
        [Authorize(Roles = "seller")]
        public IActionResult updateStore(StoreUpdateDTO store)
        {

            return Ok(storeService.updateStore(store,
                new Guid(HttpContext.User.
                FindFirst(ClaimTypes.NameIdentifier).Value)));
        }
        [HttpGet]
        [Authorize(Roles = "seller")]
        public IActionResult getStoreInfo()
        {

            return Ok(storeService.getStore(
                new Guid(HttpContext.User.
                FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

    }
}
