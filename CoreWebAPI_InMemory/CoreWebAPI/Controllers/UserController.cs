using CoreWebAPI.Models;
using CoreWebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private IUserRepository _user;
        public UserController(IUserRepository user)
        {
            _user = user;
        }

        [HttpGet]
        [ResponseCache(Duration =60)]
        public async Task<ActionResult<List<User>>> Get()
        {
            return await _user.getAllUsers();
        }

        [HttpGet("{Id:int}", Name ="GetUser")]
        public async Task<ActionResult<User>> Get(int Id)
        {
            return await _user.GetUserById(Id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(User entity)
        {
            // if(ModelState.IsValid) : not required if ApiController attribute applied on controller level.
            _user.AddUser(entity);
            return new CreatedAtRouteResult("GetUser", new { id = entity.Id }, entity);
            
        }
    }
}
