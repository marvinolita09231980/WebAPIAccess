using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIAccess.Models
{
    public class sp_get_personnel_names_drivers
    {
        public string empl_id { get; set; }
        public string employee_name { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string gender { get; set; }
        public string birth_date { get; set; }
        public string age { get; set; }
        public string department_code { get; set; }
        public string subdepartment_code { get; set; }
        public string division_code { get; set; }
        public string section_code { get; set; }
        public string position_code { get; set; }
        public string department_name1 { get; set; }
        public string department_proper_name { get; set; }
        public string department_short_name { get; set; }
        public string position_long_title { get; set; }
        public string position_short_title { get; set; }
        public string position_title1 { get; set; }
        public string position_title2 { get; set; }
        public object empl_photo_img { get; set; }
    }
}