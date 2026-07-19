using ecommerceAPI.Application.Common.Pagination;
using ecommerceAPI.Application.Common.Specification;
using ecommerceAPI.Application.DTOs.Category;
using ecommerceAPI.Application.DTOs.Products;
using ecommerceAPI.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
//using System.Web.Http;

namespace ecommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService productService)
        {
            this._service = productService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<ProductDTO>>> ShowAllProducts([FromQuery] ProductSpecParams specParams)
        {
            var products =await _service.GetAllProductsAsync(specParams);
            return Ok(products);
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> AddNewProductAsync(CreateProductDTO productDTO)
        {
            if (productDTO == null) 
                return NotFound();

            var res = await _service.AddAsync(productDTO);
            return Ok(res);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var res = await _service.DeleteAsync(id);
            if (res==0)
                return NotFound();
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(int id, UpdateProductDTO productDTO)
        {
            var res = await _service.UpdateAsync(id, productDTO);
            if (res==null)
                return NotFound();
            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var objet = await _service.GetByIdAsync(id);
            if (objet==null)
                return NotFound();
            return Ok(objet);
        }
        
    }
}
