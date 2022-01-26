using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class User
    {
        public User()
        {
            EventUserAs = new HashSet<Event>();
            EventUserBs = new HashSet<Event>();
            Guests = new HashSet<Guest>();
        }

        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [JsonIgnore]
        public virtual ICollection<Event> EventUserAs { get; set; }
        [JsonIgnore]
        public virtual ICollection<Event> EventUserBs { get; set; }
        [JsonIgnore]
        public virtual ICollection<Guest> Guests { get; set; }
    }
}
