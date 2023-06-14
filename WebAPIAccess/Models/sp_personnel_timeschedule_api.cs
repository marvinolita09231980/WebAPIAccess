using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIAccess.Models
{
    public class sp_personnel_timeschedule_api
    {
        public string tse_ctrl_no               {get;set;}
        public string day_nbr                   {get;set;}
        public string sort_order                {get;set;}
        public string tse_day_parent            {get;set;}
        public string day_of_week               {get;set;}
        public string dtr_date                  {get;set;}
        public string dtr_date_char             {get;set;}
        public string holiday_name              {get;set;}
        public string empl_id                   {get;set;}
        public string tse_in_am                 {get;set;}
        public string tse_out_am                {get;set;}
        public string tse_in_pm                 {get;set;}
        public string tse_out_pm                {get;set;}
        public string ts_code                   {get;set;}
        public string day_type                  {get;set;}
        public string remarks_details           {get;set;}
        public string ts_descr                  {get;set;}
        public string tse_month                 {get;set;}
        public string tse_year                  {get;set;}
        public string pre_time_in_hrs           {get;set;}
        public string post_time_out_hrs         {get;set;}
        public double ts_day_equivalent         {get;set;}
        public string approval_status           {get;set;}
        public string approval_status_descr     { get; set; }

    }
}