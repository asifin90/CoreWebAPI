using JWTAuthentication.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthentication.Controllers
{
    [Route("api/accounts")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _config;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

  
        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody]UserInfo entity)
        {
            var result = await _signInManager.PasswordSignInAsync(entity.Email, entity.Passowrd, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return await BuildToken(entity);
            }
            else
            {
                return BadRequest("Invalid login attempt");
            }
        }


        private async Task<UserToken> BuildToken(UserInfo userInfo)
        {
            var Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userInfo.Email),
                new Claim(ClaimTypes.Email, userInfo.Email),
                new Claim("mykey", "Whatever value I want")
            };

            var identityUser = await _userManager.FindByEmailAsync(userInfo.Email);
            var claimsDB = await _userManager.GetClaimsAsync(identityUser);
            Claims.AddRange(claimsDB);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer:null,
                audience:null,
                claims : Claims,
                expires:expiration,
                signingCredentials : creds
            );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };

        }

        [HttpPost("AssignRole")]
        public async Task<ActionResult> AssignRole(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound();
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
            return NoContent();
        }

        

        [HttpPost("Gnerate")]
        public async Task<ActionResult<UserToken>> Create([FromBody] UserInfo entity)
        {
            var user = new IdentityUser { UserName = entity.Email, Email = entity.Email };
            var result = await _userManager.CreateAsync(user, entity.Passowrd);

            if (result.Succeeded)
            {
                return await BuildToken(entity);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("RenewToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<UserToken>> ReniewToken()
        {
            UserInfo user = new UserInfo() { Email = HttpContext.User.Identity.Name };

            return await BuildToken(user);
        }



    }
}
