using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPIAccess.Controllers
{
    public class EmployeeSalaryController : ApiController
    {
        private string connetionString = GlobalClass.connetionString_pay;
        SqlConnection con;

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] string cats)
        {
            sp_get_personnelsalary_details_api data = new sp_get_personnelsalary_details_api();
            con = new SqlConnection(connetionString);

            try
            {
                con.Open();
                SqlCommand sql = new SqlCommand("sp_get_personnelsalary_details_api", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.Add("@par_empl_id", SqlDbType.VarChar).Value = cats;
                sql.CommandTimeout = Int32.MaxValue;
                using (SqlDataReader reader = sql.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        data.empl_id = reader.GetString(0);
                        data.daily_rate = reader.GetDecimal(1).ToString();
                        data.monthly_rate = reader.GetDecimal(2).ToString();
                        data.hourly_rate = reader.GetDecimal(3).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
            };
            return response;
        }
    }

    public class sp_get_personnelsalary_details_api
    {
        public string empl_id { get; set; }
        public string daily_rate { get; set; }
        public string monthly_rate { get; set; }
        public string hourly_rate { get; set; }
    }
}
