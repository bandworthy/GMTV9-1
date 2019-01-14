using System;
using System.Collections.Generic;

namespace GMTV9.Models
{
    public partial class UserProfile
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
    }
}
