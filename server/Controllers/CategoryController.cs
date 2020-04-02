using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Helpers;
using server.Models;
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
        public async Task<ActionResult<ICollection<object>>> GetCategories()
        {
            try
            {
                var categories = await _service.GetCategoriesAsync();
                var result = categories.Select(x => new
                {
                    Id = x.CategoryId,
                    Title = x.Title,
                    Slug = x.Slug
                }).ToList();
                var response = new Result()
                {
                    Data = result,
                    Count = result.Count
                };
                return Ok(response);
            }
            catch(AppException ex)
            {
                var response = new Result()
                {
                    Message = ex.Message
                };
                return BadRequest(response);
            }
        }
        [AllowAnonymous]
        [HttpGet("subs/{id}")]
        public async Task<ActionResult<ICollection<object>>> GetSubCategories(long id)
        {
            try
            {
                var categories = await _service.GetSubCategoriesAsync(id);
                var result = categories.Select(x => new
                {
                    Id = x.SubCategoryId,
                    Title = x.Title,
                    Slug = x.Slug,
                    ParentCategoryId = x.ParentCategoryId,
                }).ToList();
                var response = new Result()
                {
                    Data = result,
                    Count =result.Count
                };
                return Ok(response);
            }
            catch (AppException ex)
            {
                var response = new Result()
                {
                    Message = ex.Message
                };
                return BadRequest(response);
            }
        }
        [AllowAnonymous]
        [HttpGet("childs/{id}")]
        public async Task<ActionResult<ICollection<object>>> GetChildCategories(long id)
        {
            try
            {
                var categories = await _service.GetChildCategoriesAsync(id);
                var result = categories.Select(x => new
                {
                    Id = x.ChildCategoryId,
                    Title = x.Title,
                    Slug = x.Slug,
                    ParentCategoryId = x.SubCategoryId,
                }).ToList();
                var response = new Result()
                {
                    Data = result,
                    Count = result.Count
                };
                return Ok(response);
            }
            catch (AppException ex)
            {
                var response = new Result()
                {
                    Message = ex.Message
                };
                return BadRequest(response);
            }
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetOne(long id)
        {
            try
            {
                var category = await _service.GetCategoryByIdAsync(id);
                var result = new Result()
                {
                    Data = category,
                    Count = 1
                };
                return Ok(result);
            }
            catch (AppException ex)
            {
                var response = new Result()
                {
                    Message = ex.Message
                };
                return BadRequest(response);
            }
        }
    }
}