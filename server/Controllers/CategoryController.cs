using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Helpers;
using server.Models.Category;
using server.Services;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _service;
        public CategoryController(ICategoryService service )
        {
            _service = service;
        }
        [AllowAnonymous]
        [HttpGet("all")]
        public async Task<ActionResult<ICollection<Category>>> GetCategories()
        {
            try
            {
                var categories = await _service.GetAll();
                return Ok(categories);
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetOne(long id)
        {
            try
            {
                var category = await _service.GetCategoryById(id);
                return Ok(category);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}