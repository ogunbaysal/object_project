using System;
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
            loggedUserId = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == "Id"));
        }
        [HttpGet("all")]
        public IActionResult Index()
        {
            var list = _basketService.GetUserBasket(this.loggedUserId);
            return Ok(list);
        }
        [HttpPost("add")]
        public IActionResult AddItem([FromBody] BasketModel model)
        {
            _basketService.AddItem(loggedUserId, model.ProductPropertId, model.Count);
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
        public IActionResult Clear()
        {
            _basketService.Clear(loggedUserId);
            return Ok();
        }

    }
}