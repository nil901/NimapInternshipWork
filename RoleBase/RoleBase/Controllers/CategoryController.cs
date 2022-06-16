
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
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("Categories" ) ]
        [Produces(typeof(IEnumerable<Category>))]
        public async Task<IActionResult> GetCategoryList()
        {
            IEnumerable<Category> category = await _categoryService.GetAllCategory();
            return Ok(category);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Route("Add" )]
        [Produces(typeof(Category))]
        public async Task< IActionResult> AddProduct(CategoryAddDTO addDTO)
        {
            return Ok( await _categoryService.AddCategory(addDTO));
        }

        [Authorize(Policy = "Admin")]
        [HttpPut]
       // [Route("{id}")]
        [Produces(typeof(User))]
        public async Task<IActionResult> UpdateProduct(CategoryUpdateDTO updateDTO)
        {
            return Ok(await _categoryService.UpdateCategory(updateDTO));
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        [Produces(typeof(bool))]
        public async Task<bool> DeleteProduct(int id)
        {
            return await _categoryService.DeleteCategory(id);
        }
    }
}
