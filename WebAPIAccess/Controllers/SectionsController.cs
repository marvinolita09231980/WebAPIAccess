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
    public class SectionsController : ApiController
    {
        private string connetionString = GlobalClass.connetionString_pay;
        SqlConnection con;

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]

        public HttpResponseMessage post()
        {
            List<sections_tbl> data = new List<sections_tbl>();
            con = new SqlConnection(connetionString);

            con.Open();
            String sql_str = "SELECT * FROM HRIS_PAY.dbo.sections_tbl";
            SqlCommand sql = new SqlCommand(sql_str, con);
            sql.CommandTimeout = Int32.MaxValue;
            using (SqlDataReader reader = sql.ExecuteReader())
            {
                while (reader.Read())
                {
                    sections_tbl list = new sections_tbl();
                    list.effective_date                  = reader.GetDateTime(0).ToString("yyyy-MM-dd");
                    list.section_code                    = reader.GetString(1);
                    list.section_short_name              = reader.GetString(2);
                    list.section_name1                   = reader.GetString(3);
                    list.section_name2                   = reader.GetString(4);
                    list.department_code                 = reader.GetString(5);
                    list.subdepartment_code              = reader.GetString(6);
                    list.division_code                   = reader.GetString(7);
                    list.sort_order_sect                 = reader.GetInt32 (8);
                    list.empl_id                         = reader.GetString(9);
                    list.designation_head1               = reader.GetString(10);
                    list.designation_head2               = reader.GetString(11);
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
