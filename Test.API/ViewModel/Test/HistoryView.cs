using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.API.ViewModel.Test
{
    public class HistoryView
    {
        public HISTORY H { get; set; }
        public HistoryView(HISTORY h)
        {
            H = h;
        }
    }
}
