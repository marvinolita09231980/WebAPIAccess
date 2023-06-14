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
    public class FunctionsChargesController : ApiController
    {

        private string connetionString = @"Data Source=HRISD\HRIS;Initial Catalog=HRIS_PAY;User ID=sa;Password=SystemAdmin_PRD123";
        SqlConnection con;

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]

        public HttpResponseMessage get()
        {
            List<sp_get_functions_tbl_api> data = new List<sp_get_functions_tbl_api>();
            con = new SqlConnection(connetionString);

            con.Open();
            SqlCommand sql = new SqlCommand("sp_get_functions_tbl_api", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.CommandTimeout = Int32.MaxValue;

            using (SqlDataReader reader = sql.ExecuteReader())
            {

                while (reader.Read())
                {
                    sp_get_functions_tbl_api list = new sp_get_functions_tbl_api();
                    list.function_code         = reader.GetString(0);
                    list.function_shortname    = reader.GetString(1);
                    list.function_name         = reader.GetString(2);
                    list.function_detail       = reader.GetString(3);
                    list.function_program      = reader.GetString(4);
                    list.department_code       = reader.GetString(5);
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
