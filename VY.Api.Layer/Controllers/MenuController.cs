using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VY.Business.Layer.Auth.Abstarct;
using VY.Business.Layer.Auth.DTO.Menu;

namespace VY.Api.Layer.Controllers
{
    [Route("api/menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private IMenuService menuService;
        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }
        [HttpGet]
        [Authorize(Roles ="seller")]
        public IActionResult get()
        {
            return Ok(menuService.get(new Guid(HttpContext.User.
                FindFirst(ClaimTypes.UserData).Value)));
        }
        [Route("{storeid}"),HttpGet]
        [Authorize(Roles = "user")]
        public IActionResult getuser(Guid storeid)
        {
            return Ok(menuService.get(storeid));
        }

        
        [Authorize(Roles = "seller")]
        [HttpPost]
        public IActionResult set(MenuDTO menu)
        {
            return Ok(menuService.setMenu(menu,new Guid(HttpContext.User.
                FindFirst(ClaimTypes.UserData).Value)));
        }
        
        [Authorize(Roles = "seller")]
        [Route("{menuid}") ,HttpPut]
        public IActionResult update(MenuDTO menu,Guid menuid)
        {
            return Ok(menuService.updateMenu(menu,menuid ,new Guid(HttpContext.User.
                FindFirst(ClaimTypes.UserData).Value)));
        }
    }
}
