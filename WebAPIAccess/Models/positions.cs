using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIAccess.Models
{
    public class positions
    {

        public string position_code           { get; set; }
        public string position_title1         { get; set; }
        public string position_title2         { get; set; }
        public string position_short_title    { get; set; }
        public string salary_grade            { get; set; }
        public string csc_level               { get; set; }
        public string position_long_title     { get; set; }
        public string employment_type         { get; set; }
        public string qs_eduction             { get; set; }
        public string qs_work_experience      { get; set; }
        public string qs_training             { get; set; }
        public string qs_eligibility          { get; set; }
       
    }
    public class subdepartments_tbl
    {
        public string effective_date                { get; set; }
        public string subdepartment_code         { get; set; }
        public string subdepartment_short_name  { get; set; }
        public string subdepartment_name1       { get; set; }
        public string subdepartment_name2       { get; set; }

    }

    public class sections_tbl
    {
      public string  effective_date         { get; set; }
      public string  section_code           { get; set; }
      public string  section_short_name     { get; set; }
      public string  section_name1          { get; set; }
      public string  section_name2          { get; set; }
      public string  department_code        { get; set; }
      public string  subdepartment_code     { get; set; }
      public string  division_code          { get; set; }
      public int     sort_order_sect           { get; set; }
      public string  empl_id                { get; set; }
      public string  designation_head1      { get; set; }
      public string  designation_head2      { get; set; }

    }

    public class divisions_tbl
    {
        public string effective_date          { get; set; } 
        public string division_code           { get; set; }
        public string division_short_name     { get; set; }
        public string division_name1          { get; set; }
        public string division_name2          { get; set; }
        public string department_code         { get; set; }
        public string subdepartment_code      { get; set; }
        public int    sort_order_div             { get; set; }
        public string empl_id                 { get; set; }
        public string designation_head1       { get; set; }
        public string designation_head2       { get; set; }
                                             

    }

  

    public class units_tbl
    {
        public string effective_date              { get; set; }
        public string unit_code                   { get; set; }
        public string unit_short_name             { get; set; }
        public string unit_name1                  { get; set; }
        public string unit_name2                  { get; set; }
        public string department_code             { get; set; }
        public string subdepartment_code          { get; set; }
        public string division_code               { get; set; }
        public string section_code                { get; set; }
        public int    sort_order_sect             { get; set; }
        public string empl_id                     { get; set; }
        public string designation_head1           { get; set; }
        public string stringdesignation_head2     { get; set; }
    }

}
























