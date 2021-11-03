using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TheBookShop.API.Helpers;
using TheBookShop.Common;
using TheBookShop.DataAccess.Data;
using TheBookShop.Models;

namespace TheBookShop.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApiSettings _apiSettings;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, IOptions<ApiSettings> options)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _apiSettings = options.Value;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] UserRequestDto userRequestDto)
        {
            if (userRequestDto == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = new ApplicationUser
            {
                UserName = userRequestDto.Email,
                Email = userRequestDto.Email,
                FirstName = userRequestDto.FirstName,
                LastName = userRequestDto.LastName,
                PhoneNumber = userRequestDto.PhoneNumber,
                EmailConfirmed = true
            };

            var identityResult = await _userManager.CreateAsync(user, userRequestDto.Password);

            if (!identityResult.Succeeded)
            {
                var errors = identityResult.Errors.Select(x => x.Description);
                return BadRequest(new ServiceResponse<RegistrationResponseDto>
                {
                    Data = new RegistrationResponseDto
                    {
                        IsRegistrationSuccessful = false,
                        Errors = errors
                    },
                    IsSuccess = false,
                    Message = errors.FirstOrDefault(e => !string.IsNullOrEmpty(e)),
                    Time = DateTime.Now
                });
            }

            var roleResult = await _userManager.AddToRoleAsync(user, SD.RolePatron);
            if (!roleResult.Succeeded)
            {
                var errors = identityResult.Errors.Select(x => x.Description);
                return BadRequest(new ServiceResponse<RegistrationResponseDto>
                {
                    Data = new RegistrationResponseDto
                    {
                        IsRegistrationSuccessful = false,
                        Errors = errors
                    },
                    IsSuccess = false,
                    Time = DateTime.Now,
                    Message = errors.FirstOrDefault(e => !string.IsNullOrEmpty(e))
                });
            }

            var result = new ServiceResponse<RegistrationResponseDto>
            {
                IsSuccess = true,
                Data = new RegistrationResponseDto { Errors = Enumerable.Empty<string>(), IsRegistrationSuccessful = true },
                Message = "Registration successful",
                Time = DateTime.Now
            };

            return new ObjectResult(result) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] AuthenticationDto authenticationDto)
        {
            var result = await _signInManager.PasswordSignInAsync(authenticationDto.UserName, authenticationDto.Password, false, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(authenticationDto.UserName);
                if (user == null)
                {
                    return Unauthorized(new ServiceResponse<AuthenticationResponseDto>
                    {
                        Data = new AuthenticationResponseDto
                        {
                            IsAuthSuccessful = false,
                            ErrorMessage = "Authorization has been denied for this request"
                        },
                        IsSuccess = false,
                        Message = "Invalid Authentication",
                        Time = DateTime.Now
                    });
                }

                var signInCredentials = GetSigningCredentials();
                var claims = await GetClaims(user);

                var tokenOptions = new JwtSecurityToken(
                    issuer: _apiSettings.ValidIssuer,
                    audience: _apiSettings.ValidAudience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signInCredentials);

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return Ok(new ServiceResponse<AuthenticationResponseDto>
                {
                    Data = new AuthenticationResponseDto
                    {
                        IsAuthSuccessful = true,
                        Token = token,
                        User = new UserDto
                        {
                            Id = user.Id,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Email = user.Email,
                            PhoneNumber = user.PhoneNumber
                        }
                    },
                    IsSuccess = true,
                    Message = "Login successful",
                    Time = DateTime.Now
                });

            }
            else
            {
                return Unauthorized(new ServiceResponse<AuthenticationResponseDto>
                {
                    Data = new AuthenticationResponseDto
                    {
                        IsAuthSuccessful = false,
                        ErrorMessage = "Authorization has been denied for this request"
                    },
                    IsSuccess = false,
                    Message = "Invalid Authentication",
                    Time = DateTime.Now
                });
            }
        }

        private SigningCredentials GetSigningCredentials()
        {
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_apiSettings.SecretKey));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("Id", user.Id),
                new Claim("LoggedOn", DateTime.Now.ToString())
            };

            var roles = await _userManager.GetRolesAsync(await _userManager.FindByEmailAsync(user.Email));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }
    }
}
