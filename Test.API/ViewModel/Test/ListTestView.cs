using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.API.ViewModel.Test
{
    public class ListTestView
    {
        public string Type { get; set; }
        public int Id_t { get; set; }
        public string Name { get; set; }

        public ListTestView(TEST t)
        {
            Name = t.NAME_TEST;
            Id_t = t.ID;
            Type = t.TYPE.NAME_TYPE;


        }
    }
}
