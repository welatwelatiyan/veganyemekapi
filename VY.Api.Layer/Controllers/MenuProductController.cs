using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VY.Business.Layer.Auth.Abstarct;
using VY.Business.Layer.Auth.DTO.MenuProduct;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VY.Api.Layer.Controllers
{
    [Route("api/menuproductkategori")]
    [ApiController]
    public class MenuProductController : ControllerBase
    {
        private IMenuProductService menuProductService;

        public MenuProductController(IMenuProductService menuProductService)
        {
            this.menuProductService = menuProductService;
        }
        /// <summary>
        /// asfdcskjfdc
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "seller")]
        public IActionResult Get()
        {
            return Ok(menuProductService.get(new Guid(HttpContext.User.
                FindFirst(ClaimTypes.UserData).Value)));
        }

        [Route("{storeid}"),HttpGet]
        [Authorize(Roles = "seller")]
        public IActionResult Getuser(Guid storeid)
        {
            return Ok(menuProductService.get(storeid));
        }

        [HttpPost]
        [Authorize(Roles = "seller")]
        public IActionResult Set(MenuProductDTO menuProduct)
        {
            return Ok(menuProductService.set(menuProduct,new Guid(HttpContext.User.
                FindFirst(ClaimTypes.UserData).Value)));
        }

        [Route("{id}"), HttpPut]
        [Authorize(Roles = "seller")]
        public IActionResult Set(MenuProductDTO menuProduct, Guid id)
        {
            return Ok(menuProductService.update(menuProduct, id,
                new Guid(HttpContext.User.FindFirst(ClaimTypes.UserData).Value)));
        }

    }
}
