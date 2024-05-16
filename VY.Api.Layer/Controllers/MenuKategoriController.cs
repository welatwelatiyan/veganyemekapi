using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VY.Business.Layer.Auth.Abstarct;
using VY.Business.Layer.Auth.DTO.MenuKategori;

namespace VY.Api.Layer.Controllers
{
    [Route("api/menucat")]
    [ApiController]
    public class MenuKategoriController : ControllerBase
    {
        private IMenuKategoriService menuKategoriService;

        public MenuKategoriController(IMenuKategoriService menuKategoriService)
        {
            this.menuKategoriService = menuKategoriService;
        }

        [HttpGet]
        [Authorize(Roles = "seller")]
        public IActionResult get()
        {
            return Ok(menuKategoriService.get(new Guid(HttpContext.User.
                FindFirst(ClaimTypes.UserData).Value)));
        }
        [Route("{storeid}"), HttpGet]
        [Authorize(Roles = "user")]
        public IActionResult getuser(Guid storeid)
        {
            return Ok(menuKategoriService.get(storeid));
        }
        [HttpPost]
        [Authorize(Roles = "seller")]
        public IActionResult set(MenuKategoriDTO menuKategori)
        {
            return Ok(menuKategoriService.set(menuKategori,new Guid(HttpContext.User.
                FindFirst(ClaimTypes.UserData).Value)));
        }
        [Route("{menukategoriid}") ,HttpPut]
        [Authorize(Roles = "seller")]
        public IActionResult update(Guid menukategoriid,MenuKategoriDTO menuKategori)
        {
            return Ok(menuKategoriService.update(menuKategori,menukategoriid ,new Guid(HttpContext.User.
                FindFirst(ClaimTypes.UserData).Value)));
        }

    }
}
