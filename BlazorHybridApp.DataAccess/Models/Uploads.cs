using System;
using System.Collections.Generic;

namespace BlazorHybridApp.DataAccess.Models
{
    public partial class Uploads
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FileName { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
