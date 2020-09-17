using System;
using System.Collections.Generic;

namespace BlazorHybridApp.DataAccess.Models
{
    public partial class MeetingPoints
    {
        public int Id { get; set; }
        public int MeetingId { get; set; }
        public string ReceiverUserId { get; set; }
        public int TotalPoint { get; set; }

        public virtual Meetings Meeting { get; set; }
    }
}
