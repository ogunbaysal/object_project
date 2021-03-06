﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Helpers;
using server.Models.Order;
using server.Services;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : Controller
    {
        public IBasketService _basketService;
        public int loggedUserId;
        public BasketController(IBasketService service)
        {
            _basketService = service;
            var id = HttpContext.User.Claims.First(x => x.Type == "Id");
            loggedUserId = Convert.ToInt32(id);
        }
        [HttpGet("all")]
        public async Task<IActionResult> Index()
        {
            var list = await _basketService.GetUserBasketAsync(this.loggedUserId);
            return Ok(list);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddItem([FromBody] BasketModel model)
        {
            await _basketService.AddItemAsync(loggedUserId, model.ProductPropertId, model.Count);
            return Ok();
        }
        [HttpPost("remove")]
        public IActionResult RemoveItem([FromBody] BasketModel model)
        {
            try
            {
                _basketService.RemoveItem(loggedUserId, model.ProductPropertId, model.Count);
            }catch(AppException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpGet("clear")]
        public async Task<IActionResult> Clear()
        {
            await _basketService.ClearAsync(loggedUserId);
            return Ok();
        }

    }
}