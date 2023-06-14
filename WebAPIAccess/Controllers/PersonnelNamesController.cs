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
using WebApi.Model;

namespace WebAPIAccess.Controllers
{
    public class PersonnelNamesController : ApiController
    {
        private string connetionString = @"Data Source=HRISD\HRIS;Initial Catalog=HRIS_PAY;User ID=sa;Password=SystemAdmin_PRD123";
        SqlConnection con;

        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        //[System.Web.Mvc.HttpPost]

        //public HttpResponseMessage post(string empl_id)
        //{
        //    List<sp_get_personnel_names_api> data = new List<sp_get_personnel_names_api>();
        //    try
        //    {
        //        con = new SqlConnection(connetionString);

        //        con.Open();
        //        SqlCommand sql = new SqlCommand("sp_get_personnel_names_api", con);
        //        sql.CommandType = CommandType.StoredProcedure;
        //        sql.CommandTimeout = Int32.MaxValue;
        //        sql.Parameters.Add(new SqlParameter("@p_empl_id", empl_id));
        //        using (SqlDataReader reader = sql.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                sp_get_personnel_names_api ob = new sp_get_personnel_names_api();
        //                ob.empl_id = reader.GetString(0);
        //                ob.employee_name = reader.GetString(1);
        //                ob.last_name = reader.GetString(2);
        //                ob.first_name = reader.GetString(3);
        //                ob.middle_name = reader.GetString(4);
        //                ob.name_found = reader.GetBoolean(5);
        //                ob.position_code = reader.GetString(6);
        //                ob.position_title1 = reader.GetString(7);
        //                ob.position_long_title = reader.GetString(8);
        //                data.Add(ob);
        //            }
        //        }

        //        con.Close();

        //        if (data[0].name_found == false)
        //        {
        //            throw new Exception("Error 404 : Not found!");
        //        }

        //        var json = JsonConvert.SerializeObject(data[0], Formatting.Indented);
        //        return new HttpResponseMessage()
        //        {
        //            Content = new StringContent(json)
        //        };
        //    }
        //    catch (Exception e)
        //    {
        //        return new HttpResponseMessage()
        //        {
        //            Content = new StringContent(e.Message)
        //        };
        //    }
        //}
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]

        public IHttpActionResult post(string empl_id)
        {
            IHttpActionResult ret;
            List<sp_get_personnel_names_api> data = new List<sp_get_personnel_names_api>();
            try
            {
               
                if(empl_id == "" || empl_id == null)
                {
                    ret = Content(HttpStatusCode.NotFound, "No parameter supplied!");
                }
                else
                {
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

                    if (data[0].name_found == false)
                    {
                        //ret = NotFound();
                        ret = Content(HttpStatusCode.NotFound, "No employee found!");
                    }
                    else
                    {
                        ret = Ok(new
                        {
                            empl_id = data[0].empl_id
                   ,
                            employee_name = data[0].employee_name
                   ,
                            last_name = data[0].last_name
                   ,
                            first_name = data[0].first_name
                   ,
                            middle_name = data[0].middle_name
                   ,
                            name_found = data[0].name_found
                   ,
                            position_code = data[0].position_code
                   ,
                            position_title1 = data[0].position_title1
                   ,
                            position_long_title = data[0].position_long_title
                        });
                    }

                }

                //var json = JsonConvert.SerializeObject(data[0], Formatting.Indented);
                //return new HttpResponseMessage()
                //{
                //    Content = new StringContent(json)
                //};

            }
            catch (Exception ex)
            {
                ret = InternalServerError(ex);
            }
            return ret;
        }
    }
}
