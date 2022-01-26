using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class Guest
    {
        public Guest()
        {
            Placements = new HashSet<Placement>();
        }

        public int Id { get; set; }
        public int EventId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Phone]
        public string Phone { get; set; }
        public int GenderId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public bool Confirmed { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string IdentifyName { get; set; }
        public byte[] IdentifyImage { get; set; }
        public int? NumFamilyMembers { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
        [JsonIgnore]
        public virtual Event Event { get; set; }
        [JsonIgnore]
        public virtual Gender Gender { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<Placement> Placements { get; set; }
    }
}
