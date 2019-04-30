using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.API.ViewModel.Test
{
    public class ShowTest
    {
        public string Name { get; set; }
        public List<string> Quest { get; set; }

       public TEST T;

        public ShowTest(TEST t)
        {
            Name = t.NAME_TEST;
            List<QUESTION> quest = t.QUESTION.ToList();
            foreach(var i in quest)
            {
                Quest.Add(i.QUESTION1);
            }
        }
    }
}
