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
    public class UnitsController : ApiController
    {
        private string connetionString = @"Data Source=HRISD\HRIS;Initial Catalog=HRIS_PAY;User ID=sa;Password=SystemAdmin_PRD123";
        SqlConnection con;

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]

        public HttpResponseMessage post()
        {
            List<units_tbl> data = new List<units_tbl>();
            con = new SqlConnection(connetionString);

            con.Open();
            String sql_str = "SELECT * FROM HRIS_PAY.dbo.units_tbl";
            SqlCommand sql = new SqlCommand(sql_str, con);
            sql.CommandTimeout = Int32.MaxValue;
            using (SqlDataReader reader = sql.ExecuteReader())
            {
                while (reader.Read())
                {
                    units_tbl list = new units_tbl();
                    list.effective_date                 = reader.GetDateTime(0).ToString("yyyy-MM-dd");
                    list.unit_code                      = reader.GetString(1);
                    list.unit_short_name                = reader.GetString(2);
                    list.unit_name1                     = reader.GetString(3);
                    list.unit_name2                     = reader.GetString(4);
                    list.department_code                = reader.GetString(5);
                    list.subdepartment_code             = reader.GetString(6);
                    list.division_code                  = reader.GetString(7);
                    list.section_code                   = reader.GetString(8);
                    list.sort_order_sect                = reader.GetInt32(9);
                    list.empl_id                        = reader.GetString(10);
                    list.designation_head1              = reader.GetString(11);
                    list.stringdesignation_head2        = reader.GetString(12);
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
