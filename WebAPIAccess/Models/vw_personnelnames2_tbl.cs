using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class vw_personnelnames2_tbl
    {
        public string empl_id               { get; set; }
        public string employee_name         { get; set; }
        public string last_name             { get; set; }
        public string first_name            { get; set; }
        public string middle_name           { get; set; }
        public string suffix_name           { get; set; }
        public string courtisy_title        { get; set; }
        public string postfix_name          { get; set; }
        public string employee_name_format2   { get; set; }
        public string employee_name_format3 { get; set; }
        
    }

    public class sp_get_personnel_names_api
    {
        public string empl_id { get; set; }
        public string employee_name { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public bool name_found { get; set; }
        public string position_code { get; set; }
        public string position_title1 { get; set; }
        public string position_long_title { get; set; }
    }
}
