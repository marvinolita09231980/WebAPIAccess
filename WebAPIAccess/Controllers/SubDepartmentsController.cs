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
    public class SubDepartmentsController : ApiController
    {
        private string connetionString = @"Data Source=HRISD\HRIS;Initial Catalog=HRIS_PAY;User ID=sa;Password=SystemAdmin_PRD123";
        SqlConnection con;

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]

        public HttpResponseMessage post()
        {
            List<subdepartments_tbl> data = new List<subdepartments_tbl>();
            con = new SqlConnection(connetionString);

            con.Open();
            String sql_str = "SELECT * FROM HRIS_PAY.dbo.subdepartments_tbl";
            SqlCommand sql = new SqlCommand(sql_str, con);
            sql.CommandTimeout = Int32.MaxValue;
            using (SqlDataReader reader = sql.ExecuteReader())
            {
                while (reader.Read())
                {
                    subdepartments_tbl list = new subdepartments_tbl();
                    list.effective_date             = reader.GetDateTime(0).ToString("yyyy-MM-dd");
                    list.subdepartment_code         = reader.GetString(1);
                    list.subdepartment_short_name   = reader.GetString(2);
                    list.subdepartment_name1        = reader.GetString(3);
                    list.subdepartment_name2        = reader.GetString(4);
                   
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
