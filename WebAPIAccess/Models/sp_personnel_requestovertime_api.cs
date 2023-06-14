using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIAccess.Models
{
    public class sp_personnel_requestovertime_api
    {
        public string   dtr_date                    {get;set;}
        public string   dtr_year                    {get;set;}
        public string   dtr_month                   {get;set;}
        public string   empl_id                     {get;set;}
        public string   ot_start_time               {get;set;}
        public string   ot_start_ampm               {get;set;}
        public string   ot_end_time                 {get;set;}
        public string   ot_end_ampm                 {get;set;}
        public string   ot_remarks                  {get;set;}
        public bool     weekdays_flag               {get;set;}
        public string   weekdays_in                 {get;set;}
        public string   weekdays_in_ampm            {get;set;}
        public string   weekdays_out                {get;set;}
        public string   weekdays_out_ampm           {get;set;}
        public bool     weekend_flag                {get;set;}
        public string   weekend_in                  {get;set;}
        public string   weekend_in_ampm             {get;set;}
        public string   weekend_out                 {get;set;}
        public string   weekend_out_ampm            {get;set;}
        public bool     holiday_flag                {get;set;}
        public string   holiday_in                  {get;set;}
        public string   holiday_in_ampm             {get;set;}
        public string   holiday_out                 {get;set;}
        public string   holiday_out_ampm            {get;set;}
        public bool     dayoff_ot_flag              {get;set;}
        public string   dayoff_ot_in                {get;set;}
        public string   dayoff_ot_in_ampm           {get;set;}
        public string   dayoff_ot_out               {get;set;}
        public string   dayoff_ot_out_ampm          {get;set;}
        public bool     ot_coc_credit_flag          { get; set; }


































    }
}