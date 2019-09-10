using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BlogEngine.Http.Utilities.Authentication;
using BlogEngine.Services.Abstracts.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BlogEngine.WebApi.Controllers
{
    [Route("api/tokens")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private AuthenticationHelper authenticationHelper;
        public TokenController(IAccountService accountService, IConfiguration configuration)
        {
            _accountService = accountService;
            authenticationHelper = new AuthenticationHelper(configuration);
        }

        [HttpPost]
        [Route("/{token}/refresh-tokens/{refreshToken}")]
        public async Task<IActionResult> Refresh(string token, string refreshToken)
        {
            var principal = authenticationHelper.GetPrincipalFromExpiredToken(token);
            var email = principal.FindFirst(ClaimTypes.Email).Value;

            if (!string.IsNullOrEmpty(email))
            {
                var user = await _accountService.GetUserAsync(email);

                if (user != null && user.RefreshToken != refreshToken)
                {
                    var newJwtToken = authenticationHelper.GenerateToken(user);
                    var newJwtRefreshToken = authenticationHelper.GenerateRefreshToken();

                    // Save refresh token
                    await _accountService.SaveRefeshTokenAsync(user.Id, newJwtRefreshToken);

                    return new ObjectResult(new
                    {
                        token = newJwtToken,
                        refreshToken = newJwtRefreshToken
                    });

                }
                else
                {
                    throw new SecurityTokenException("Invalid refresh token");
                }

            }

            return BadRequest();
           
        }

        [HttpPost, Authorize]
        [Route("revoke")]
        public async Task<IActionResult> Revoke()
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;
            var user = await _accountService.GetUserAsync(email);

            if (user != null)
            {
                await _accountService.SaveRefeshTokenAsync(user.Id, null);
            }
            return BadRequest();
        }
    }
}