using System;
using System.Collections.Generic;

namespace BlazorHybridApp.DataAccess.Models
{
    public partial class Notifications
    {
        public Notifications()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Summary { get; set; }
        public string Link { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}
