using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIAccess.Models
{
    public class sp_get_departments_tbl_api
    {
       public DateTime effective_date         {get;set;}
       public string department_code        {get;set;}
       public string department_short_name  {get;set;}
       public string department_name1       {get;set;}
       public string department_name2       {get;set;}
       public int    sort_order_dept        {get;set;}
       public int    print_group            {get;set;}
       public string empl_id                {get;set;}
       public string designation_head1      {get;set;}
       public string designation_head2      {get;set;}
       public string function_code          {get;set;}
       public string department_proper_name { get; set;} 
       
    }
}