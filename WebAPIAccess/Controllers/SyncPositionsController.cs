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
    public class SyncPositionsController : ApiController
    {
        private string connetionString = @"Data Source=HRISD\HRIS;Initial Catalog=HRIS_PAY;User ID=sa;Password=SystemAdmin_PRD123";
        SqlConnection con;

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]

        public HttpResponseMessage post()
        {
            List<positions> data = new List<positions>();
            con = new SqlConnection(connetionString);

            con.Open();
            String sql_str = "SELECT * FROM HRIS_PAY.dbo.positions_tbl";
            SqlCommand sql = new SqlCommand(sql_str, con);
            sql.CommandTimeout = Int32.MaxValue;
            using (SqlDataReader reader = sql.ExecuteReader())
            {
                while (reader.Read())
                {
                    positions list = new positions();
                    list.position_code = reader.GetString(0);
                    list.position_title1 = reader.GetString(1);
                    list.position_title2 = reader.GetString(2);
                    list.position_short_title = reader.GetString(3);
                    list.salary_grade = reader.GetString(4);
                    list.csc_level = reader.GetString(5);
                    list.position_long_title = reader.GetString(6);
                    list.employment_type = reader.GetString(7);
                    list.qs_eduction = reader.GetString(8);
                    list.qs_work_experience = reader.GetString(9);
                    list.qs_training = reader.GetString(10);
                    list.qs_eligibility = reader.GetString(11);
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
