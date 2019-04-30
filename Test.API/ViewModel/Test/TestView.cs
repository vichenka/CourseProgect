using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.API.ViewModel.Test
{
    public class TestView
    { 
       public TEST T { get; set; }

        public TestView(TEST t)
        {
            T = t;
        }
    }
}
