using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class EventPerUser
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public virtual Event Event { get; set; }

        public virtual User User { get; set; }
    }
}
