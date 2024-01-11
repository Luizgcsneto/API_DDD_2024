using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Token;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UsersController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> CriarTokenIdentity([FromBody] Login login)
        {
            if(string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Senha))
            {
                return Unauthorized();
            }

            var resultado = await 
                _signInManager.PasswordSignInAsync(login.Email, login.Senha,
                false, lockoutOnFailure: false);

            if (resultado.Succeeded) 
            {
                //var user = new ApplicationUser
                //{
                //    Email = token.Email,
                //    UserName = token.Email,
                //    CPF = token.CPF
                //};
                // recupera user logado
                var userCurrent = await _userManager.FindByEmailAsync(login.Email);
                var userId = userCurrent.Id;

                var token = new TokenJwtBuilder()
               .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-12345678"))
               .AddSubject("Projeto de DDD com o .Net 6")
               .AddIssuer("Teste.Securiry.Bearer")
               .AddAudience("Teste.Securiry.Bearer")
               .AddClaim("userId", userId)
               .AddExperiInMinutes(5)
               .Builder();
                
                return Ok(token.value);

            } else
            {
                return Unauthorized();
            }

        }
      
    }
}
