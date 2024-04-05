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
using System.Web.Mvc;
using WebAPIAccess.Models;

namespace WebAPIAccess.Controllers
{
    public class EmployeesAttendanceController : ApiController
    {
        //private string connetionString_pay = GlobalClass.connetionString_pay;
        private string connetionString_ats = GlobalClass.connetionString_ats;
        SqlConnection con;


        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]

        public HttpResponseMessage post(string empl_id,string year,string month)
        {
          

            List<sp_get_personnel_attendance_api> data = new List<sp_get_personnel_attendance_api>();
            con = new SqlConnection(connetionString_ats);

            con.Open();
            SqlCommand sql = new SqlCommand("sp_get_personnel_attendance_api", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.CommandTimeout = Int32.MaxValue;
            sql.Parameters.Add(new SqlParameter("@p_empl_id", empl_id));
            sql.Parameters.Add(new SqlParameter("@p_year", year));
            sql.Parameters.Add(new SqlParameter("@p_month", month));
            using (SqlDataReader reader = sql.ExecuteReader())
            {
                while (reader.Read())
                {
                    sp_get_personnel_attendance_api list = new sp_get_personnel_attendance_api();
                    list.dtr_order_no       = reader.GetString(0);
                    list.empl_id            = reader.GetString(1);
                    list.dtr_date           = reader.GetString(2);
                    list.time_in_am         = reader.GetString(3);
                    list.time_out_am        = reader.GetString(4);
                    list.time_in_pm         = reader.GetString(5);
                    list.time_out_pm        = reader.GetString(6);
                    list.ts_code            = reader.GetString(7);
                    list.under_Time         = reader.GetInt32(8);
                    list.under_Time_remarks = reader.GetString(9);
                    list.remarks_details    = reader.GetString(10);
                    list.time_ot_hris       = reader.GetString(11);
                    list.time_days_equi     = reader.GetDouble(12);
                    list.time_hours_equi    = reader.GetDouble(13);
                    list.time_ot_payable    = reader.GetDouble(14);
                    list.approval_status    = reader.GetString(15);
                    list.no_of_as           = reader.GetInt32(16);
                    list.no_of_ob           = reader.GetInt32(17);
                    list.no_of_lv           = reader.GetInt32(18);
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




















