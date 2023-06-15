using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIAccess.Models
{
    public class sp_api_cafoa
    {
        public int payroll_year                { get; set; }
        public string payroll_month            { get; set; }
        public string payroll_registry_nbr     { get; set; }
        public string payrolltemplate_code     { get; set; }
        public string payrolltemplate_descr    { get; set; }
        public string payroll_registry_descr   { get; set; }
        public DateTime payroll_period_from    { get; set; }
        public DateTime payroll_period_to      { get; set; }
        public string function_code            { get; set; }
        public string doc_cafoa                { get; set; }
        public string doc_voucher_nbr          { get; set; }
        public string employment_type          { get; set; }
        public string post_status_descr        { get; set; }
        public decimal gross_pay               { get; set; }
        public decimal net_pay                 { get; set; }
    }
}