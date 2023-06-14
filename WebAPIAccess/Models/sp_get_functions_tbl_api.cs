using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIAccess.Models
{
    public class sp_get_functions_tbl_api
    {
        public string function_code         {get;set;}
        public string function_shortname    {get;set;}
        public string function_name         {get;set;}
        public string function_detail       {get;set;}
        public string function_program      {get;set;}
        public string department_code       {get;set;}
    }                                    
}