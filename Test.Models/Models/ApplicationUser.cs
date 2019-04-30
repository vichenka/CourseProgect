using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Test.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            HISTORY = new HashSet<HISTORY>();
            TEST = new HashSet<TEST>();

        }


        [StringLength(450)]
        public string FIO { get; set; }

        public virtual ICollection<HISTORY> HISTORY { get; set; }

         public virtual ICollection<TEST> TEST { get; set; }
    }
}
