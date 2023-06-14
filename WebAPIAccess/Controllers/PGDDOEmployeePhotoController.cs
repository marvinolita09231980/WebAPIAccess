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
    public class PGDDOEmployeePhotoController : ApiController
    {

        private string connetionString = @"Data Source=HRISD\HRIS;Initial Catalog=HRIS_PAY;User ID=sa;Password=SystemAdmin_PRD123";
        SqlConnection con;

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]

        public HttpResponseMessage get(string empl_id)
        {
            List<sp_get_emplphoto_api> data = new List<sp_get_emplphoto_api>();
            con = new SqlConnection(connetionString);

            con.Open();
            SqlCommand sql = new SqlCommand("sp_get_emplphoto_api", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.CommandTimeout = Int32.MaxValue;
            sql.Parameters.Add(new SqlParameter("@p_empl_id", empl_id));

            using (SqlDataReader reader = sql.ExecuteReader())
            {

                while (reader.Read())
                {
                    sp_get_emplphoto_api list = new sp_get_emplphoto_api();
                    list.empl_id = reader.GetString(0);
                    list.empl_photo_img = reader.GetSqlBytes(1);
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
