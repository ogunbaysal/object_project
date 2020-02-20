using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fop;
using Fop.FopExpression;
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
        public ActionResult<Category> GetCategories([FromQuery] FopQuery request)
        {
            var fopRequest = FopExpressionBuilder<Category>.Build(request.Filter, request.Order, request.PageNumber, request.PageSize);
            try
            {
                var categories = _service.GetAll(fopRequest);
                return Ok(categories);
            }catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}