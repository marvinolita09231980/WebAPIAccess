using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web;
using System.Web.Mvc;
using WebApi.Model;
using Newtonsoft.Json;
using System.Data;

namespace WebAPIAccess.Controllers
{
    public class AccessAPIController : ApiController
    {
        private string connetionString = GlobalClass.connetionString_pay;

        SqlConnection con;

        //[EnableCors(origins: "http://localhost:93", headers: "*", methods: "*")]
        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        //public HttpResponseMessage Get()
        //{
        //      List<vw_personnelnames2_tbl> data = new List<vw_personnelnames2_tbl>();
        //      con = new SqlConnection(connetionString);

        //      con.Open();
        //      SqlCommand sql = new SqlCommand("Select * from vw_personnelnames2_tbl", con);

        //      using (SqlDataReader reader = sql.ExecuteReader())
        //      {
        //          while (reader.Read())
        //          {
        //              vw_personnelnames2_tbl ob = new vw_personnelnames2_tbl();
        //              ob.empl_id = reader.GetString(0);
        //              ob.employee_name = reader.GetString(1);
        //              ob.last_name = reader.GetString(2);
        //              ob.first_name = reader.GetString(3);
        //              ob.middle_name = reader.GetString(4);
        //              ob.suffix_name = reader.GetString(5);
        //              ob.courtisy_title = reader.GetString(6);
        //              ob.postfix_name = reader.GetString(7);
        //              ob.employee_name_format2 = reader.GetString(8);
        //              ob.employee_name_format3 = reader.GetString(9);
        //              data.Add(ob);
        //          }
        //      }

        //      con.Close();

        //    var json = JsonConvert.SerializeObject(data, Formatting.Indented);
        //    return new HttpResponseMessage()
        //    {
        //        Content = new StringContent(json)
        //    };
        //}

        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        //public HttpResponseMessage Post()
        //{
        //    List<vw_personnelnames2_tbl> data = new List<vw_personnelnames2_tbl>();
        //    con = new SqlConnection(connetionString);

        //    con.Open();
        //    SqlCommand sql = new SqlCommand("Select * from vw_personnelnames2_tbl", con);

        //    using (SqlDataReader reader = sql.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            vw_personnelnames2_tbl ob = new vw_personnelnames2_tbl();
        //            ob.empl_id = reader.GetString(0);
        //            ob.employee_name = reader.GetString(1);
        //            ob.last_name = reader.GetString(2);
        //            ob.first_name = reader.GetString(3);
        //            ob.middle_name = reader.GetString(4);
        //            ob.suffix_name = reader.GetString(5);
        //            ob.courtisy_title = reader.GetString(6);
        //            ob.postfix_name = reader.GetString(7);
        //            ob.employee_name_format2 = reader.GetString(8);
        //            ob.employee_name_format3 = reader.GetString(9);
        //            data.Add(ob);
        //        }
        //    }
        //    con.Close();
        //    var json = JsonConvert.SerializeObject(data, Formatting.Indented);
        //    return new HttpResponseMessage()
        //    {
        //        Content = new StringContent(json)
        //    };
        //}

       //[EnableCors(origins: "*", headers: "*", methods: "*")]
       //[System.Web.Mvc.HttpGet]
       // public HttpResponseMessage Get(string empl_id)
       // {
       //     List<sp_get_personnel_names_api> data = new List<sp_get_personnel_names_api>();
       //     con = new SqlConnection(connetionString);

       //     con.Open();
       //     SqlCommand sql = new SqlCommand("sp_get_personnel_names_api", con);
       //     sql.CommandType = CommandType.StoredProcedure;
       //     sql.CommandTimeout = Int32.MaxValue;
       //     sql.Parameters.Add(new SqlParameter("@p_empl_id", empl_id));
       //     using (SqlDataReader reader = sql.ExecuteReader())
       //     {
       //         while (reader.Read())
       //         {
       //             sp_get_personnel_names_api ob = new sp_get_personnel_names_api();
       //             ob.empl_id = reader.GetString(0);
       //             ob.employee_name = reader.GetString(1);
       //             ob.last_name = reader.GetString(2);
       //             ob.first_name = reader.GetString(3);
       //             ob.middle_name = reader.GetString(4);
       //             ob.name_found = reader.GetBoolean(5);
       //             data.Add(ob);
       //         }
       //     }

       //     con.Close();

       //     var json = JsonConvert.SerializeObject(data, Formatting.Indented);
       //     return new HttpResponseMessage()
       //     {
       //         Content = new StringContent(json)
       //     };
       // }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]

        public HttpResponseMessage post(string empl_id)
        {
            List<sp_get_personnel_names_api> data = new List<sp_get_personnel_names_api>();
            con = new SqlConnection(connetionString);

            con.Open();
            SqlCommand sql = new SqlCommand("sp_get_personnel_names_api", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.CommandTimeout = Int32.MaxValue;
            sql.Parameters.Add(new SqlParameter("@p_empl_id", empl_id));
            using (SqlDataReader reader = sql.ExecuteReader())
            {
                while (reader.Read())
                {
                    sp_get_personnel_names_api ob = new sp_get_personnel_names_api();
                    ob.empl_id = reader.GetString(0);
                    ob.employee_name = reader.GetString(1);
                    ob.last_name = reader.GetString(2);
                    ob.first_name = reader.GetString(3);
                    ob.middle_name = reader.GetString(4);
                    ob.name_found = reader.GetBoolean(5);
                    ob.position_code = reader.GetString(6);
                    ob.position_title1 = reader.GetString(7);
                    ob.position_long_title = reader.GetString(8);
                    data.Add(ob);
                }
            }

            con.Close();

            var json = JsonConvert.SerializeObject(data[0], Formatting.Indented);
            return new HttpResponseMessage()
            {
                Content = new StringContent(json)
            };
        }
        
        public HttpResponseMessage Put()
        {
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent("PUT: Test message")
                    };
        }
    }
}
