using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.BLL.Interfaces;
using Test.Models;

namespace Test.API.Controllers
{
    [Produces("application/json")]
    public class TestController : Controller
    {
        private readonly ITestService testService;
        private readonly IQuestionService questionService;
        private readonly IPointService pointService;
        private readonly IResultService resultService;
        private readonly ITypeService typeService;
        private readonly IUserService userService;


        private UserManager<ApplicationUser> _userManager;

        //public TestController(
        //    UserManager<ApplicationUser> userManager,
        //    IUserService s1,
        //    ITestService s2,
        //    IQue
        //    )
    }
}
