
using DTOModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repo.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoleBase.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<Product>))]
        public async Task<IActionResult> getUserList()
        {
            IEnumerable<Product> products = await _productService.GetAllProduct();
            return Ok(products);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Produces(typeof(Product))]
        public IActionResult AddProduct(ProductAddDTO addDTO)
        {
            var isAdded = _productService.AddProduct(addDTO);
            return Ok(_productService.AddProduct(addDTO)); 
        }

        [Authorize(Policy = "Admin")]
        [HttpPut]
        [Route("{id}")]
        [Produces(typeof(User))]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDTO productDTO)
        {
            return Ok(await _productService.UpdateProduct(productDTO));
        }
        [Authorize(Policy = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        [Produces(typeof(bool))]
        public async Task<bool> DeleteProduct(int id)
        {
            return await _productService.DeleteProduct(id);
        }
    }
}
