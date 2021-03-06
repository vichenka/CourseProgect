﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Test.BLL.Models
{
   public class CurrentUser
    {
        public string Id { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public bool IsAuntificated { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string FIO { get; set; }

        public CurrentUser()
        {
            Roles = new List<string>();
            IsAuntificated = false;
            Email = string.Empty;
            Username = string.Empty;
            FIO = string.Empty;
        }
    }
}
