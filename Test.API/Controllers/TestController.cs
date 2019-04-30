using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.API.ViewModel.Test;
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

        public TestController(
            UserManager<ApplicationUser> userManager,
            IUserService s1,
            ITestService s2,
            IQuestionService s3,
            IPointService s4,
            IResultService s5,
            ITypeService s6
            )
        {
            _userManager = userManager;
            testService = s2;
            questionService = s3;
            pointService = s4;
            resultService = s5;
            typeService = s6;
            userService = s1;
        }

        //метод,путь,параметр 
        //GetAllTest  GET api/tests
        [Route("api/tests")]
        [HttpGet]
        public async Task<IActionResult> GetListTest()
        {
            var list = new List<ListTestView>();
            var list_t = await testService.Get();
            foreach(var t in list_t)
            {
                list.Add(new ListTestView(t));
            }
            return Ok(list);
        }


        //GetTestByid  GET api/test/id
       [Route("api/test/id")]
       [HttpGet("{id}")]
       public async Task<IActionResult> GetTestById(int id)
        {
            if (ModelState.IsValid)
            {
                var test = await testService.Get(id);
                if(test != null)
                {
                    return Ok(new TestView(test));
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }

        //CreateTest POST api/test/create
        [Route("api/test/create")]
        [HttpPost]
        public async Task<IActionResult> CreateTest([FromBody] TestView model)
        {
            if (ModelState.IsValid)
            {
                var UserId = _userManager.GetUserId(User);

                var test = new TEST
                {
                    ID_USER = UserId,
                    NAME_TEST = model.T.NAME_TEST,
                    RESULT = model.T.RESULT,
                    QUESTION = model.T.QUESTION,
                    ID_TYPE = model.T.ID_TYPE
                };

                await testService.Add(test);
                return Ok(test);
            }
            return BadRequest(ModelState);
        }

        //DeleteTest DELETE api/test/id
        [Route("api/test/delete")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTest(int id)
        {
            if (ModelState.IsValid)
            {
                var test = await testService.Get(id);
                if(test != null)
                {
                    await testService.Delete(test);
                    return Ok(test);
                }
                return NotFound();

            }
            return BadRequest(ModelState);
        }

       
       
    }
}
