using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIAccess.Models
{
    public class sp_get_division_tbl_api
    {

        public string  effective_date        {get;set;}
        public string  division_code          {get;set;}
        public string  division_short_name    {get;set;}
        public string  division_name1         {get;set;}
        public string division_name2          {get;set;}
        public string department_code         {get;set;}
        public string subdepartment_code      {get;set;}
        public int sort_order_div             {get;set;}
        public string empl_id                 {get;set;}
        public string designation_head1       {get;set;}
        public string designation_head2       { get; set; }

    }
}