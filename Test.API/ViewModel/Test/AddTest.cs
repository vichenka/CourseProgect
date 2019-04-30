using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.API.ViewModel.Test
{//создать тест
    public class AddTest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Quest { get; set; }
       // public List<string> Point { get; set; }
       // public List<string> Restxt { get; set; }
       // public List<int> Ball { get; set; }
        public List<string> Type { get; set; }

        public AddTest(TEST t, List<string> type)
        {
            Id = t.ID;
            Name = t.NAME_TEST;
            Type = type;

            List<QUESTION> quests = t.QUESTION.ToList();
            foreach ( var i in quests)
            {
                Quest.Add(i.QUESTION1);
            }

          //  List<RESULT> results = t.RESULT.ToList();
            //foreach(var e in results)
            //{
            //    Restxt.Add(e.TEXT_RESULT);
            //}

            
            
           
            
        }
    }
}
