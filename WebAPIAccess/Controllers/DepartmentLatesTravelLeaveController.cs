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
    public class DepartmentLatesTravelLeaveController : ApiController
    {
        private string connetionString = GlobalClass.connetionString_pay;

        SqlConnection con;

        

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]

        public HttpResponseMessage post([FromBody] to_lates_leave_param request)
        {
            List<sp_departments_lates_leave_to_Result> data = new List<sp_departments_lates_leave_to_Result>();
            con = new SqlConnection(connetionString);

            con.Open();
            SqlCommand sql = new SqlCommand("sp_departments_lates_leave_to", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.CommandTimeout = Int32.MaxValue;
            sql.Parameters.Add(new SqlParameter("@par_year", request.year));
            sql.Parameters.Add(new SqlParameter("@par_department_code", request.department_code));
            using (SqlDataReader reader = sql.ExecuteReader())
            {

                 
                while (reader.Read())
                {
                    sp_departments_lates_leave_to_Result ob = new sp_departments_lates_leave_to_Result();
                    ob.year = (int)reader.GetSqlInt32(0);
                    ob.month = (int)reader.GetSqlInt32(1);
                    ob.department_code = reader.GetString(2);
                    ob.department_name1 = reader.GetString(3);
                    ob.undertime_minutes = (int)reader.GetSqlInt32(4);
                    ob.travelorder_count = (int)reader.GetSqlInt32(5);
                    ob.leave_count = (int)reader.GetSqlInt32(6);
                    ob.absent_count = (int)reader.GetSqlInt32(7);

                    data.Add(ob);
                }
            }

            con.Close();

            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            return new HttpResponseMessage()
            {
                Content = new StringContent(json)
            };
        }

        //public HttpResponseMessage Put()
        //{
        //    return new HttpResponseMessage()
        //    {
        //        Content = new StringContent("PUT: Test message")
        //    };
        //}
    }
}
