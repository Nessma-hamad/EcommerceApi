using AngularApi.DTO;
using AngularApi.Mapper;
using AngularApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using FromBodyAttribute = System.Web.Http.FromBodyAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace AngularApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        protected readonly IMapper Mapper = Mapperconfig.mapp;
        protected readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;


        public AcountController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;

        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register( UserDto userdto)
        {
            var user = Mapper.Map<User>(userdto);
            if (!ModelState.IsValid)
            {
                return BadRequest("Data Not Valid");
            }
            try
            {

                UserStore<IdentityUser> store = new UserStore<IdentityUser>(new DataContext());

             
                IdentityUser identity = new IdentityUser();
                identity.UserName = user.UserName;
                identity.PasswordHash = user.Password;

                IdentityResult result = await _userManager.CreateAsync(identity, user.Password);

                if (result.Succeeded)
                {
                    //  return Redirect("http://localhost:49682/Student_Index.html");
                    return Ok();
                }
                else
                {
                    return BadRequest(result.Errors.ToList()[0]);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(Login model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
             

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                

              

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims
                 
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }
    }
}
