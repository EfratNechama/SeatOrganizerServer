using System;
using System.Collections.Generic;

#nullable disable

namespace ourProject.Models
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

        public virtual Category Category { get; set; }
        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Placement> Placements { get; set; }
    }
}
