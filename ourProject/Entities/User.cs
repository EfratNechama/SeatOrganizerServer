using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class User
    {
        public User()
        {
            Guests = new HashSet<Guest>();
        }

        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [JsonIgnore]
        public virtual ICollection<Guest> Guests { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
