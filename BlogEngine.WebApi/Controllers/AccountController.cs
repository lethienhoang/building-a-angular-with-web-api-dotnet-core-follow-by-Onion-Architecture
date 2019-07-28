using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogEngine.Dtos.Dtos.Accounts;
using BlogEngine.Http.Utilities.Authentication;
using BlogEngine.Http.Utilities.Hashs;
using BlogEngine.Services.Abstracts;
using BlogEngine.Services.Abstracts.Accounts;
using BlogEngine.Services.Dtos.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BlogEngine.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;
        private AuthenticationHelper authenticationHelper;
        private readonly IConfiguration _configuration;
        public AccountController(IAccountService accountService, IPasswordHasher passwordHasher,IConfiguration configuration)
        {
            _accountService = accountService;
            authenticationHelper = new AuthenticationHelper(configuration);
        }

        public async Task<IActionResult> SignUp(AccountDto model)
        {
            var user = await _accountService.SignUpAsync(model);

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }


        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _accountService.GetUserAsync(model.Email);

            if (user == null || _passwordHasher.VerifyIdentityV3Hash(user.PasswordHash, model.Password))
            {
                return BadRequest();
            }

            var jwtToken = authenticationHelper.GenerateToken(user);
            var refreshToken = authenticationHelper.GenerateRefreshToken();


            await _accountService.SaveRefeshTokenAsync(user.Id, refreshToken);
            return new ObjectResult(new
            {
                token = jwtToken,
                refreshToken = refreshToken
            });

        }
    }
}