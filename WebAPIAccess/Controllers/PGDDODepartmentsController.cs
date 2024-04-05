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
    public class PGDDODepartmentsController : ApiController
    {

        private string connetionString = GlobalClass.connetionString_pay;
        SqlConnection con;

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]

        public HttpResponseMessage get()
        {
            List<sp_get_departments_tbl_api> data = new List<sp_get_departments_tbl_api>();
            con = new SqlConnection(connetionString);

            con.Open();
            SqlCommand sql = new SqlCommand("sp_get_departments_tbl_api", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.CommandTimeout = Int32.MaxValue;
          
            using (SqlDataReader reader = sql.ExecuteReader())
            {
                
                while (reader.Read())
                {
                    sp_get_departments_tbl_api list = new sp_get_departments_tbl_api();
                    list.effective_date = reader.GetDateTime(0);
                    list.department_code = reader.GetString(1);
                    list.department_short_name = reader.GetString(2);
                    list.department_name1 = reader.GetString(3);
                    list.department_name2 = reader.GetString(4);
                    list.sort_order_dept = reader.GetInt32(5);
                    list.print_group = reader.GetInt32(6);
                    list.empl_id = reader.GetString(7);
                    list.designation_head1 = reader.GetString(8);
                    list.designation_head2 = reader.GetString(9);
                    list.function_code = reader.GetString(10);
                    list.department_proper_name = reader.GetString(10);
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
