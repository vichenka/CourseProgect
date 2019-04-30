using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.API.ViewModel.Test
{
    public class AddPoint
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Ball { get; set; }

        public AddPoint(POINT p)
        {
            Id = p.ID_ANSWER;
            Text = p.ANSWER;
            Ball = (int)p.POINT1;


        }
    }
}
