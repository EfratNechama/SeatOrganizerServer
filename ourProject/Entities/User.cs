using System;
using System.Collections.Generic;

#nullable disable

namespace ourProject.Models
{
    public partial class User
    {
        public User()
        {
            Guests = new HashSet<Guest>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }
    }
}
