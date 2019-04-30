using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Test.API.ViewModel.Auth;
using Test.BLL.Interfaces;
using Test.BLL.Models;
using Test.Models;

namespace Test.API.Controllers
{
    [Produces("application/json")]
     public class AuthController : Controller
    {
        private readonly IUserService _userService;
         private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;


        public AuthController(IUserService userService,  UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userService = userService;         
            _userManager = userManager;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("api/auth/login")]
        public async Task<IActionResult> Login([FromBody]SignInVM SignInVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser ApplicationUser = _mapper.Map<SignInVM, ApplicationUser>(SignInVM);
                ApplicationUser user = await _userManager.FindByNameAsync(ApplicationUser.UserName);

                if (user != null)
                {
                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        return Unauthorized();
                    }
                    else
                    {
                        Microsoft.AspNetCore.Identity.SignInResult result = await _userService.SignIn(ApplicationUser);
                        return Ok(result.Succeeded);
                    }
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("api/auth/externalLogin")]
        public async Task<IActionResult> ExternalLogin([FromBody]SignUpVM externelUser)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByNameAsync(externelUser.Username);
                if (user != null)
                {
                    return await Login(new SignInVM { Username = externelUser.Username, Password = externelUser.Password });
                }
              //  IActionResult result = await SignUpVM(externelUser);
                ApplicationUser newUser = await _userManager.FindByNameAsync(externelUser.Username);
                string code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                await _userManager.ConfirmEmailAsync(newUser, code);
                return await Login(new SignInVM { Username = externelUser.Username, Password = externelUser.Password });
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("api/auth/logout")]
        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            return Ok();
        }

        [HttpGet]
        [Route("api/auth/user")]
        public async Task<CurrentUser> GetCurrentUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                CurrentUser user = await _userService.GetUser(User.Identity.Name);
                user.IsAuntificated = true;
                return user;
            }
            return new CurrentUser();
        }
    }
}