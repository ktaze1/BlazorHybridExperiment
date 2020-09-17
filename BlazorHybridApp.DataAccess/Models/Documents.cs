using System;
using System.Collections.Generic;

namespace BlazorHybridApp.DataAccess.Models
{
    public partial class Documents
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string AllowedRoles { get; set; }
    }
}
