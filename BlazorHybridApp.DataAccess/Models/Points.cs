using System;
using System.Collections.Generic;

namespace BlazorHybridApp.DataAccess.Models
{
    public partial class Points
    {
        public Points()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
        }

        public int Id { get; set; }
        public string AddedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int TotalPoints { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}
