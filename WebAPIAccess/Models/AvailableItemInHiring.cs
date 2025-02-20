using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIAccess.Models
{
    public class AvailableItemInHiring
    {
        public string item_no                { get; set; }
        public string budget_code            { get; set; }
        public string employment_type        { get; set; }
        public string position_code          { get; set; }
        public string department_code        { get; set; }
        public string department_name1       { get; set; }
        public string inPublication          { get; set; }
        public string ctrl_no                { get; set; }
        public string active_status          { get; set; }
        public string position_title1        { get; set; }
        public string position_title2        { get; set; }
        public string position_short_title   { get; set; }
        public string salary_grade           { get; set; }
        public string csc_level              { get; set; }
        public string position_long_title    { get; set; }
        public string qs_eduction            { get; set; }
        public string qs_work_experience     { get; set; }
        public string qs_training            { get; set; }
        public string qs_eligibility         { get; set; }
        public string period_from            { get; set; }
        public string period_to              { get; set; }
        public string period_descr           { get; set; }
    }
}