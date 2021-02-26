using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }

    }
}
