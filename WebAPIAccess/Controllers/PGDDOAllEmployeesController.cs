using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPIAccess.Models;

namespace WebAPIAccess.Controllers
{
    public class PGDDOAllEmployeesController : ApiController
    {
        int capacity = 255;
        int maxCapacity = Int32.MaxValue;
        
        private string connetionString = GlobalClass.connetionString_pay;

        SqlConnection con;

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]

        public HttpResponseMessage post()
        {
            StringBuilder stringBuilder = new StringBuilder(capacity, maxCapacity);

            List<sp_get_personnel_names_wfilter> data = new List<sp_get_personnel_names_wfilter>();
            con = new SqlConnection(connetionString);

            con.Open();
            SqlCommand sql = new SqlCommand("sp_get_allpersonnel_names_api2", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.CommandTimeout = Int32.MaxValue;
            using (SqlDataReader reader = sql.ExecuteReader())
            {
                while (reader.Read())
                {
                    sp_get_personnel_names_wfilter list = new sp_get_personnel_names_wfilter();
                    list.empl_id = reader.GetString(0);
                    list.employee_name = reader.GetString(1);
                    list.last_name = reader.GetString(2);
                    list.first_name = reader.GetString(3);
                    list.middle_name = reader.GetString(4);
                    list.gender = reader.GetString(5);
                    list.birth_date = reader.GetString(6);
                    list.age = reader.GetString(7);
                    list.department_code = reader.GetString(8);
                    list.subdepartment_code = reader.GetString(9);
                    list.division_code = reader.GetString(10);
                    list.section_code = reader.GetString(11);
                    list.position_code = reader.GetString(12);
                    list.department_name1 = reader.GetString(13);
                    list.department_proper_name = reader.GetString(14);
                    list.department_short_name = reader.GetString(15);
                    list.position_long_title = reader.GetString(16);
                    list.position_short_title = reader.GetString(17);
                    list.position_title1 = reader.GetString(18);
                    list.position_title2 = reader.GetString(19);
                    list.empl_photo_img = reader.GetSqlBytes(20);
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
