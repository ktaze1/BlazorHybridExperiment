using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorHybridApp.DataAccess.Model
{
    public class CurrentUser
    {
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public Dictionary<string, string> Claims { get; set; }
    }
}
