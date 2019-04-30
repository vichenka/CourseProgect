using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Test.API.ViewModel.Test;
using Test.BLL.Interfaces;
using Test.BLL.Services;
using Test.Models;

namespace Test.API.Controllers
{
    [Produces("application/json")]
  //  [Route("api/History")]
    public class HistoryController : Controller
    {
        private readonly IHistoryService historyService;
        private readonly IUserService userService;
        private UserManager<ApplicationUser> _userManager;
        public HistoryController(
         UserManager<ApplicationUser> userManager,
            IHistoryService s1,
                IUserService s2
        )
        {
            _userManager = userManager;
            historyService = s1;
            userService = s2;
        }

        [Route("api/history")]
        [HttpGet]
        public async Task<IActionResult> GetAllHistory()
        {
            var list = new List<HistoryView>();
            var list_t = await historyService.Get();
            foreach (var t in list_t)
            {
                list.Add(new HistoryView(t));
            }
            return Ok(list);
        }

        [Route("api/history/id")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistoryByUserId(string id)  //user_id
        {
            var list = new List<HistoryView>();
            var list_t = await historyService.Get(m=> m.ID_USER == id);
            foreach (var t in list_t)
            {
                list.Add(new HistoryView(t));
            }
            return Ok(list);
        }

        //CreateTest POST api/test/create
        [Route("api/history/create")]
        [HttpPost]
        public async Task<IActionResult> CreateHistory([FromBody] HistoryView model)
        {
            if (ModelState.IsValid)
            {
                var UserId = _userManager.GetUserId(User);

                var history = new HISTORY
                {
                    ID_RESULTH = model.H.ID_RESULTH,
                    ID_TYPE = model.H.ID_TYPE,
                    ID_USER = UserId
                    
                };

                await historyService.Add(history);
                return Ok(history);
            }
            return BadRequest(ModelState);
        }
    }
}