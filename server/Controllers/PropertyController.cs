using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Helpers;
using server.Models;
using server.Services;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private IProductPropertyService _service;
        public PropertyController(IProductPropertyService service)
        {
            _service = service;

        }
        [HttpGet("color/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Result>> GetColor(long id)
        {
            try
            {
                var data = await _service.GetColorAsync(id);
                var result = new Result()
                {
                    Count = 1,
                    Data = data
                };
                return Ok(result);
            }
            catch (AppException ex)
            {
                var result = new Result()
                {
                    Message = ex.Message
                };
                return BadRequest(result);
            }

        }
        [HttpGet("size/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Result>> GetSize(long id)
        {
            try
            {
                var data = await _service.GetSizeAsync(id);
                var result = new Result()
                {
                    Count = 1,
                    Data = data
                };
                return Ok(result);
            }
            catch (AppException ex)
            {
                var result = new Result()
                {
                    Message = ex.Message
                };
                return BadRequest(result);
            }

        }
    }
}