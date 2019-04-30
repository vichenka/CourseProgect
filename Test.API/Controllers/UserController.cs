using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.API.ViewModel.Auth;
using Test.BLL.Infrastructure;
using Test.BLL.Interfaces;
using Test.BLL.Models;

namespace Test.API.Controllers
{
    [Produces("application/json")]
    [Authorize]
 
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut]
        [Route("api/user")]
        public async Task<IActionResult> Update([FromBody]UserVM userModel)
        {
            if (ModelState.IsValid)
            {
                CurrentUser user = await _userService.GetUser(User.Identity.Name);

                if (user != null)
                {
                    user.FIO = userModel.FIO;
                    OperationResult result = await _userService.UpdateUser(user);
                    return Ok(result);
                }

                return NotFound();
            }
            return BadRequest(ModelState);
        }
    }
}