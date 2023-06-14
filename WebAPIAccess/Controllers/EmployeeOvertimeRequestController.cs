using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPIAccess.Models;

namespace WebAPIAccess.Controllers
{
    public class EmployeeOvertimeRequestController : ApiController
    {
        private string connetionString_ats = @"Data Source=HRISD\HRIS;Initial Catalog=HRIS_ATS;User ID=sa;Password=SystemAdmin_PRD123";
        SqlConnection con;

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]

        public HttpResponseMessage post(string empl_id, string year, string month)
        {


            List<sp_personnel_requestovertime_api> data = new List<sp_personnel_requestovertime_api>();
            con = new SqlConnection(connetionString_ats);

            con.Open();
            SqlCommand sql = new SqlCommand("sp_personnel_requestovertime_api", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.CommandTimeout = Int32.MaxValue;
            sql.Parameters.Add(new SqlParameter("@p_empl_id", empl_id));
            sql.Parameters.Add(new SqlParameter("@p_year", year));
            sql.Parameters.Add(new SqlParameter("@p_month", month));
            using (SqlDataReader reader = sql.ExecuteReader())
            {
                while (reader.Read())
                {
                    sp_personnel_requestovertime_api list = new sp_personnel_requestovertime_api();
                    list.dtr_date                   = reader.GetString(0);
                    list.dtr_year                   = reader.GetString(1);
                    list.dtr_month                  = reader.GetString(2);
                    list.empl_id                    = reader.GetString(3);
                    list.ot_start_time              = reader.GetString(4);
                    list.ot_start_ampm              = reader.GetString(5);
                    list.ot_end_time                = reader.GetString(6);
                    list.ot_end_ampm                = reader.GetString(7);
                    list.ot_remarks                 = reader.GetString(8);
                    list.weekdays_flag              = reader.GetBoolean(9);
                    list.weekdays_in                = reader.GetString(10);
                    list.weekdays_in_ampm           = reader.GetString(11);
                    list.weekdays_out               = reader.GetString(12);
                    list.weekdays_out_ampm          = reader.GetString(13);
                    list.weekend_flag               = reader.GetBoolean(14);
                    list.weekend_in                 = reader.GetString(15);
                    list.weekend_in_ampm            = reader.GetString(16);
                    list.weekend_out                = reader.GetString(17);
                    list.weekend_out_ampm           = reader.GetString(18);
                    list.holiday_flag               = reader.GetBoolean(19);
                    list.holiday_in                 = reader.GetString(20);
                    list.holiday_in_ampm            = reader.GetString(21);
                    list.holiday_out                = reader.GetString(22);
                    list.holiday_out_ampm           = reader.GetString(23);
                    list.dayoff_ot_flag             = reader.GetBoolean(24);
                    list.dayoff_ot_in               = reader.GetString(25);
                    list.dayoff_ot_in_ampm          = reader.GetString(26);
                    list.dayoff_ot_out              = reader.GetString(27);
                    list.dayoff_ot_out_ampm         = reader.GetString(28);
                    list.ot_coc_credit_flag         = reader.GetBoolean(29);
                    data.Add(list);

                }
            }

            con.Close();

            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            return new HttpResponseMessage()
            {
                Content = new StringContent(json)
            };
        }

    }
}
