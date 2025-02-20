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

               
                  string  query = @"select 
	                                     A.item_no
		                                ,A.budget_code
		                                ,A.employment_type
		                                ,A.position_code
		                                ,A.department_code
		                                ,A.department_name1
		                                ,A.inPublication
		                                ,A.ctrl_no
		                                ,A.active_status
                                        ,C.position_title1
                                        ,C.position_title2
                                        ,C.position_short_title
                                        ,C.salary_grade
                                        ,C.csc_level
                                        ,C.position_long_title
                                        ,C.qs_eduction
                                        ,C.qs_work_experience
                                        ,C.qs_training
                                        ,C.qs_eligibility
                                        ,D.period_from
                                        ,D.period_to
                                        ,D.period_descr
	                                FROM HRIS_APL.dbo.available_item_tbl A            
                                    INNER JOIN HRIS_APL.dbo.employment_type_tbl B            
                                      ON B.employment_type = A.employment_type            
                                    INNER JOIN HRIS_PAY.dbo.positions_tbl C            
                                    ON C.position_code = A.position_code            
                                    INNER JOIN HRIS_RCT.dbo.psb_hiring_period_tbl D            
                                    ON D.ctrl_nbr = A.ctrl_no  
	                                 WHERE A.active_status = 1            
                                    AND B.active_status = 1";
                
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
                                inPublication           = reader.GetString(6),
                                ctrl_no                 = reader.GetString(7),
                                active_status           = reader.GetString(8),
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



            con.Close();

            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            return new HttpResponseMessage()
            {
                Content = new StringContent(json)
            };
        }
    }
}
