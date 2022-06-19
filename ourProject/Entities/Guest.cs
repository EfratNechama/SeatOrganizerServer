using System;
using System.Collections.Generic;
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Confirmed { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string IdentifyName { get; set; }
        public byte[] IdentifyImage { get; set; }
        public int? NumFamilyMembersMale { get; set; }
        public int? NumFamilyMembersFemale { get; set; }
        public string DataUrl { get; set; }
        public string imagePath { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
        [JsonIgnore]
        public virtual Event Event { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<Placement> Placements { get; set; }
    }
}
