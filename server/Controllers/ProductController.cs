using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Helpers;
using server.Models;
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
        public async Task<ActionResult<Result>> GetAll([FromQuery]SieveModel sieveModel)
        {
            try
            {
                var products = await _service.GetAllAsync(sieveModel);
                var result = new Result()
                {
                    Count = products.Count(),
                    Data = products
                };
                return Ok(result);
            }catch(AppException ex)
            {
                var result = new Result()
                {
                    Message = ex.Message
                };
                return BadRequest(result);
            }
        }
        [HttpGet("category/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Result>> GetByCategory(long id)
        {
            try
            {
                var product = await _service.GetByCategoryId(id);
                var result = new Result()
                {
                    Count = product.Count(),
                    Data = product
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
        [HttpGet("one/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Result>> GetOne(long id) 
        {
             try
            {
                var product = await _service.GetByIdAsync(id);
                var result = new Result()
                {
                    Count = 1,
                    Data = product
                };
                return Ok(result);
            }catch(AppException ex)
            {
                var result = new Result()
                {
                    Message = ex.Message
                };
                return BadRequest(result);
            }
        }
        [HttpGet("properties/{id}")]
        public async Task<ActionResult<Result>> GetProductProperties(long id)
        {
            try
            {
                var properties = await _service.GetProductPropertiesAsync(id);
                var result = new Result()
                {
                    Count = properties.Count(),
                    Data = properties
                };
                return Ok(result);
            }catch(AppException ex)
            {
                var result = new Result()
                {
                    Message = ex.Message
                };
                return BadRequest(result);
            }
        }
        [HttpGet("{id}/image")]
        public async Task<ActionResult<Result>> GetOneProductImage(long id)
        {
            try
            {
                var image = await _service.GetOneProductImage(id);
                var result = new Result()
                {
                    Count = 1,
                    Data = image
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
        [HttpGet("{id}/price")]
        public async Task<ActionResult<Result>> GetProductPrice(long id)
        {
            try
            {
                var price = await _service.GetProductPrice(id);
                var result = new Result()
                {
                    Count = 1,
                    Data = price
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
        [HttpGet("property/image/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Result>> GetPropertyImage(long id)
        {
            try
            {
                var images = await _service.GetPropertyImageByPropertyIdAsync(id);
                var result = new Result()
                {
                    Count = images.Count(),
                    Data = images
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