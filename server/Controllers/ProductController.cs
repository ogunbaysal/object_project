using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Filter;
using server.Helpers;
using server.Models.Product;
using server.Services;
using Sieve.Models;
using Sieve.Services;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _service;
        public ProductController(IProductService service )
        {
            _service = service;

        }
        [HttpGet("all")]
        [AllowAnonymous]
        public ActionResult<ICollection<object>> GetAll(SieveModel sieveModel)
        {
            try
            {
                var products = _service.GetAll(sieveModel);
                return Ok(products);
            }catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("properties/{id}")]
        public async Task<ActionResult<ICollection<object>>> GetProductProperties(long id)
        {
            try
            {
                var properties = await _service.GetProductProperties(id);
                return Ok(properties);
            }catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}