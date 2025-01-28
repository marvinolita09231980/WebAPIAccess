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
    public class ActiveDivisionListController : ApiController
    {
        private string connetionString = GlobalClass.connetionString_pay;



        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]

        public HttpResponseMessage post()
        {

            List<ActiveDivision> divisions = new List<ActiveDivision>();
            using (SqlConnection con = new SqlConnection(connetionString))
            {
                con.Open();

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
                        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;", con))
                {
                    command.ExecuteNonQuery();
                }



                string query = @"select DISTINCT 
                                 A.department_code
                                ,ISNULL(A.subdepartment_code,'') AS subdepartment_code
                                ,ISNULL(D.subdepartment_name1,'') AS subdepartment_name1
                                ,A.division_code
                                ,B.division_name1
                                from vw_payrollemployeemaster_hdr_tbl A
                                INNER JOIN divisions_tbl B
                                ON B.division_code = A.division_code
                                INNER JOIN plantilla_tbl C
                                ON C.empl_id = A.empl_id
                                AND (YEAR(LEFT(C.budget_code,4)) >= 2025 AND RIGHT(C.budget_code,1) = '2')
                                LEFT JOIN subdepartments_tbl D
                                ON D.subdepartment_code = A.subdepartment_code
                                where A.division_code <> ''
                                AND A.emp_rcrd_status = 1
                                ORDER by A.department_code, B.division_name1";


                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.CommandType = CommandType.Text;

                    command.CommandTimeout = int.MaxValue;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new ActiveDivision
                            {
                                department_code          = reader.GetString(0),
                                subdepartment_code       = reader.GetString(1),
                                subdepartment_name1      = reader.GetString(2),
                                division_code            = reader.GetString(3),
                                division_name1           = reader.GetString(4),
                            };

                            divisions.Add(item);

                        }
                    }

                }
                con.Close();
            }

            var json = JsonConvert.SerializeObject(divisions, Formatting.Indented);
            return new HttpResponseMessage()
            {
                Content = new StringContent(json)
            };
        }
    }
}
