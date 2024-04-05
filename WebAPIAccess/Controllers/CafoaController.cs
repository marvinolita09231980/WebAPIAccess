
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
    public class CafoaController : ApiController
    {
        private string connetionString_pay = GlobalClass.connetionString_pay;
        SqlConnection con;

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]

        public HttpResponseMessage post(string year, string month, string employment_type)
        {


            List<sp_api_cafoa> data = new List<sp_api_cafoa>();
            con = new SqlConnection(connetionString_pay);

            con.Open();
            SqlCommand sql = new SqlCommand("sp_api_cafoa", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.CommandTimeout = Int32.MaxValue;
            sql.Parameters.Add(new SqlParameter("@par_payroll_year", year));
            sql.Parameters.Add(new SqlParameter("@par_payroll_month", month));
            sql.Parameters.Add(new SqlParameter("@par_employment_type", employment_type));
            using (SqlDataReader reader = sql.ExecuteReader())
            {
                while (reader.Read())
                {
                    sp_api_cafoa list = new sp_api_cafoa();

                    list.payroll_year             = reader.GetInt32(0);
                    list.payroll_month            = reader.GetString(1);
                    list.payroll_registry_nbr     = reader.GetString(2);
                    list.payrolltemplate_code     = reader.GetString(3);
                    list.payrolltemplate_descr    = reader.GetString(4);
                    list.payroll_registry_descr   = reader.GetString(5);
                    list.payroll_period_from      = reader.GetDateTime(6);
                    list.payroll_period_to        = reader.GetDateTime(7);
                    list.function_code            = reader.GetString(8);
                    list.doc_cafoa                = reader.GetString(9);
                    list.doc_voucher_nbr          = reader.GetString(10);
                    list.employment_type          = reader.GetString(11);
                    list.post_status_descr        = reader.GetString(12);
                    list.gross_pay                = reader.GetDecimal(13);
                    list.net_pay                  = reader.GetDecimal(14);
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
