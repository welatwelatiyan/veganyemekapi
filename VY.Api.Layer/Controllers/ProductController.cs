using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VY.Business.Layer.Auth.Abstarct;
using VY.Business.Layer.Auth.DTO.Product;

namespace VY.Api.Layer.Controllers
{
    [Authorize(Roles = "seller")]
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult get()
        {
            return Ok(productService.get(
                new Guid(HttpContext.User.
                 FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

        [HttpPost]
        public IActionResult set(ProductDTO product)
        {
            return Ok(productService.set(product,
                new Guid(HttpContext.User.
                 FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

        [Route("{id}"),HttpPut]
        public IActionResult update(Guid id,ProductDTO product)
        {
            return Ok(productService.update(product,id,
                new Guid(HttpContext.User.
                 FindFirst(ClaimTypes.NameIdentifier).Value)));
        }
    }
}
