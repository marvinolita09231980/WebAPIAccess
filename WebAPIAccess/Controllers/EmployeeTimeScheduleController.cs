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
    public class EmployeeTimeScheduleController : ApiController
    {

        private string connetionString_ats = GlobalClass.connetionString_ats;
        SqlConnection con;

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]

        public HttpResponseMessage post(string empl_id, string year, string month)
        {


            List<sp_personnel_timeschedule_api> data = new List<sp_personnel_timeschedule_api>();
            con = new SqlConnection(connetionString_ats);

            con.Open();
            SqlCommand sql = new SqlCommand("sp_personnel_timeschedule_api", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.CommandTimeout = Int32.MaxValue;
            sql.Parameters.Add(new SqlParameter("@p_empl_id", empl_id));
            sql.Parameters.Add(new SqlParameter("@p_year", year));
            sql.Parameters.Add(new SqlParameter("@p_month", month));
            using (SqlDataReader reader = sql.ExecuteReader())
            {
                while (reader.Read())
                {
                    sp_personnel_timeschedule_api list = new sp_personnel_timeschedule_api();
                    list.tse_ctrl_no                 = reader.GetString(0);
                    list.day_nbr                     = reader.GetString(1);
                    list.sort_order                  = reader.GetString(2);
                    list.tse_day_parent              = reader.GetString(3);
                    list.day_of_week                 = reader.GetString(4);
                    list.dtr_date                    = reader.GetString(5);
                    list.dtr_date_char               = reader.GetString(6);
                    list.holiday_name                = reader.GetString(7);
                    list.empl_id                     = reader.GetString(8);
                    list.tse_in_am                   = reader.GetString(9);
                    list.tse_out_am                  = reader.GetString(10);
                    list.tse_in_pm                   = reader.GetString(11);
                    list.tse_out_pm                  = reader.GetString(12);
                    list.ts_code                     = reader.GetString(13);
                    list.day_type                    = reader.GetString(14);
                    list.remarks_details             = reader.GetString(15);
                    list.ts_descr                    = reader.GetString(16);
                    list.tse_month                   = reader.GetString(17);
                    list.tse_year                    = reader.GetString(18);
                    list.pre_time_in_hrs             = reader.GetString(19);
                    list.post_time_out_hrs           = reader.GetString(20);
                    list.ts_day_equivalent           = reader.GetDouble(21);
                    list.approval_status             = reader.GetString(22);
                    list.approval_status_descr       = reader.GetString(23);
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
