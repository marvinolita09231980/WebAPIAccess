using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIAccess.Models
{
    public class sp_get_personnel_attendance_api
    {
        public string dtr_order_no         {get;set;}
        public string empl_id              {get;set;}
        public string dtr_date             {get;set;}
        public string time_in_am           {get;set;}
        public string time_out_am          {get;set;}
        public string time_in_pm           {get;set;}
        public string time_out_pm          {get;set;}
        public string ts_code              {get;set;}
        public int    under_Time           {get;set;}
        public string under_Time_remarks   {get;set;}
        public string remarks_details      {get;set;}
        public string time_ot_hris         {get;set;}
        public double  time_days_equi       {get;set;}
        public double  time_hours_equi      {get;set;}
        public double  time_ot_payable      {get;set;}
        public string approval_status      {get;set;}
        public int    no_of_as             {get;set;}
        public int    no_of_ob             {get;set;}
        public int    no_of_lv             {get; set; }
    }
}
