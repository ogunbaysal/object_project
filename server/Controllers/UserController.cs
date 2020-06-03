using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using server.Helpers;
using server.Models;
using server.Models.User;
using server.Services;

namespace server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        public UserController(IUserService service, IMapper mapper , IOptions<AppSettings> appSettings)
        {
            _userService = service;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _userService.GetById(id);
            var model = _mapper.Map<User>(user);
            model.Password = null;
            model.Token = null;
            var result = new Result
            {
                Data = model,
                Count = 1
            };
            return Ok(result);
        }
        [HttpGet("profile")]
        public async Task<ActionResult<User>> GetProfile()
        {
            var user = await _userService.GetById(Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == "Id").Value));
            var model = _mapper.Map<User>(user);
            var result = new Result
            {
                Data = model,
                Count = 1
            };
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);
            if (user == null)
            {
                return BadRequest(new Result() { Message = "Username or password is incorrect" });
            }
            var result = new Result()
            {
                Count = 1,
                Data = new
                {
                    Token = user.Token
                },
                Message = "Successful"
            };
            // return basic user info and authentication token
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = _mapper.Map<User>(model);
            try
            {
                var response = await _userService.Create(user, model.Password);
                var result = new Result
                { 
                    Message = "Successfuly Registered. Please Log in."
                };
                return Ok(result);
            }catch(AppException ex)
            {
                var result = new Result
                {
                    Message = ex.Message
                };
                return BadRequest(result);
            }
        }
        [HttpPut("profile")]
        public IActionResult UpdateProfile([FromBody] UpdateModel model)
        {
            var user = _mapper.Map<User>(model);
            user.UserId = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == "Id").Value);
            try
            {
                _userService.Update(user, model.Password);
                var result = new Result
                {
                    Message = string.Format("Successfuly Updated user {0}", model.Username)
                };
                return Ok(result);
            }
            catch (AppException ex)
            {
                var result = new Result
                {
                    Message = ex.Message
                };
                return BadRequest(result);
            }
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut("update/{id}")]
        public IActionResult UpdateUser(long id, [FromBody] UpdateModel model)
        {
            var user = _mapper.Map<User>(model);
            user.UserId = id;
            try
            {
                _userService.Update(user, model.Password);
                var result = new Result
                {
                    Message = string.Format("Successfuly Updated user {0}", model.Username)
                };
                return Ok(result);
            }
            catch (AppException ex)
            {
                return BadRequest(new Result() { Message = ex.Message });
            }
        }
        [Authorize(Roles = Role.Admin)]
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var model = _mapper.Map<IList<User>>(users);
            var result = new Result
            {
                Data = model,
                Count = model.Count
            };
            return Ok(result);
        }
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.DeleteAsync(id);
            try
            {
                var result = new Result
                {
                    Message = string.Format("Successfuly Deleted user id {0}", id)
                };
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(new Result() { Message = ex.Message });
            }
        }
    }
}
   