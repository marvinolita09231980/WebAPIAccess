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
    public class AvailableItemInHiringController : ApiController
    {
        private string connetionString = GlobalClass.connetionString_pay;

        SqlConnection con;

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage post()
        {
            List<AvailableItemInHiring> data = new List<AvailableItemInHiring>();
          

            using (SqlConnection connection = new SqlConnection(connetionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(@"
                        SET TEXTSIZE 2147483647;
                        SET LANGUAGE us_english;
                        SET DATEFORMAT mdy;
                        SET DATEFIRST 7;
                        SET LOCK_TIMEOUT -1;
                        SET QUOTED_IDENTIFIER ON;
                        SET ARITHABORT ON;
                        SET ANSI_NULL_DFLT_ON ON;
                        SET ANSI_WARNINGS ON;
                        SET ANSI_PADDING ON;
                        SET ANSI_NULLS ON;
                        SET CONCAT_NULL_YIELDS_NULL ON;
                        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;", connection))
                {
                    command.ExecuteNonQuery();
                }


                //string  query = @"select 
                //                    item_no
                //                ,budget_code
                //                ,employment_type
                //                ,position_code
                //                ,department_code
                //                ,department_name1
                //                ,inPublication
                //                ,ctrl_no
                //                ,active_status
                //                      ,position_title1
                //                      ,position_title2
                //                      ,position_short_title
                //                      ,salary_grade
                //                      ,csc_level
                //                      ,position_long_title
                //                      ,qs_eduction
                //                      ,qs_work_experience
                //                      ,qs_training
                //                      ,qs_eligibility
                //                      ,period_from
                //                      ,period_to
                //                      ,period_descr
                //               FROM HRIS_PAY.dbo.vw_AvailableItemInHiring_tbl";

                string query = @"select 
                                    item_no
                                ,budget_code
                                ,employment_type
                                ,position_code
                                ,department_code
                                ,department_name1
                                ,inPublication
                                ,ctrl_no
                                ,active_status
                                      ,position_title1
                                      ,position_title2
                                      ,position_short_title
                                      ,salary_grade
                                      ,csc_level
                                      ,position_long_title
                                      ,qs_eduction
                                      ,qs_work_experience
                                      ,qs_training
                                      ,qs_eligibility
                                      ,period_from
                                      ,period_to
                                      ,period_descr
                               FROM HRIS_PAY.dbo.vw_AvailableItemInHiring_tbl_test";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.CommandType = CommandType.Text;


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new AvailableItemInHiring
                            {
                                item_no                 = reader.GetString(0),
                                budget_code             = reader.GetString(1),
                                employment_type         = reader.GetString(2),
                                position_code           = reader.GetString(3),
                                department_code         = reader.GetString(4),
                                department_name1        = reader.GetString(5),
                                inPublication           = reader.GetBoolean(6),
                                ctrl_no                 = reader.GetString(7),
                                active_status           = reader.GetBoolean(8),
                                position_title1         = reader.GetString(9),
                                position_title2         = reader.GetString(10),
                                position_short_title    = reader.GetString(11),
                                salary_grade            = reader.GetString(12),
                                csc_level               = reader.GetString(13),
                                position_long_title     = reader.GetString(14),
                                qs_eduction             = reader.GetString(15),
                                qs_work_experience      = reader.GetString(16),
                                qs_training             = reader.GetString(17),
                                qs_eligibility          = reader.GetString(18),
                                period_from             = reader.GetString(19),
                                period_to               = reader.GetString(20),
                                period_descr            = reader.GetString(21),

                            };
                            data.Add(item);
                        }
                    }

                }
                connection.Close();
            }


            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            return new HttpResponseMessage()
            {
                Content = new StringContent(json)
            };
        }
    }
}
