using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisiNoti.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public string Sound { get; set; }
        public string FCMToken { get; set; }
    }
}