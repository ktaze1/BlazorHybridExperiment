using System;
using System.Collections.Generic;

namespace BlazorHybridApp.DataAccess.Models
{
    public partial class Groups
    {
        public Groups()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}
