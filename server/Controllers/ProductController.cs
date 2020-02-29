﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Filter;
using server.Helpers;
using server.Models.Product;
using server.Services;
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
        public ActionResult<ICollection<Product>> GetAll(PaginationSearchModel pagination)
        {
            try
            {
                var products = _service.GetAll(pagination);
                return Ok(products);
            }catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}