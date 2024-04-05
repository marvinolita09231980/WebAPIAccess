using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIAccess.Models
{
    public class sp_get_allpersonnel_names_api
    {
        public string empl_id { get; set; }
        public string employee_name { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string suffix_name { get; set; }
        public string postfix_name { get; set; }
        public string courtisy_title { get; set; }
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
        public bool   is_pghead { get; set; }
        public string employment_type { get; set; }
        public string appointment_date { get; set; }
        public string effective_date { get; set; }
        public string salary_grade { get; set; }
        public bool emp_rcrd_status { get; set; }
        public string pwd_type_id { get; set; }
        public string pwd_descr { get; set; }
        public string pwd_statutory { get; set; }
    }
}
