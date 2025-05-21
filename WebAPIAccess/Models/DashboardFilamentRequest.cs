using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIAccess.Models
{
    public class DashboardFilamentRequest
    {
        public string empl_id { get; set; }
        public string department_code { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public string dataType { get; set; }
    }
}