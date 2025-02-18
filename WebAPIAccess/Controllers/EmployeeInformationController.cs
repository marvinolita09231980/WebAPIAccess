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
    public class EmployeeInformationController : ApiController
    {
        private string connetionString = GlobalClass.connetionString_pay;

      

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]

        public HttpResponseMessage post(string empl_id)
        {
            
            List<EmpoloyeeInformationModel> employee = new List<EmpoloyeeInformationModel>();
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

               

                string query = @" SELECT                               
                                ISNULL(A. empl_id,'')             AS empl_id                              
                               ,ISNULL(A. employee_name,'')            AS employee_name                              
                               ,ISNULL(A. last_name,'')             AS last_name                              
                               ,ISNULL(A. first_name,'')            AS first_name                              
                               ,ISNULL(A. middle_name,'')            AS middle_name                              
                               ,ISNULL(A. suffix_name,'')            AS suffix_name                              
                               ,ISNULL(A. postfix_name,'')            AS postfix_name                              
                               ,ISNULL(A. courtisy_title,'')           AS courtisy_title                              
                               ,ISNULL(F.gender,'')              AS gender                              
                               ,ISNULL(CONVERT(VARCHAR,F.birth_date),'')        AS birth_date                              
                               ,IIF((SELECT dbo.func_compute_age(F.birth_date)) > 99,'',ISNULL((CONVERT(VARCHAR,(SELECT dbo.func_compute_age(F.birth_date)))),''))       
                                               AS age      
                               FROM  HRIS_PAY.dbo.vw_personnelnames_tbl_2 A                                                       
                               INNER JOIN HRIS_PAY.dbo.personnel_tbl F                              
                               ON F.empl_id = A.empl_id                              
                               WHERE A.empl_id = @empl_id";


                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@empl_id", empl_id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new EmpoloyeeInformationModel
                            {
                                    empl_id          =reader.GetString(0),
                                    employee_name    =reader.GetString(1),
                                    last_name        =reader.GetString(2),
                                    first_name       =reader.GetString(3),
                                    middle_name      =reader.GetString(4),
                                    suffix_name      =reader.GetString(5),
                                    postfix_name     =reader.GetString(6),
                                    courtisy_title   =reader.GetString(7),
                                    gender           =reader.GetString(8),
                                    birth_date       =reader.GetString(9),
                                    age              =reader.GetString(10),
                               
                            };

                            employee.Add(item);

                        }
                    }

                }
                con.Close();
            }

            var json = JsonConvert.SerializeObject(employee, Formatting.Indented);
            return new HttpResponseMessage()
            {
                Content = new StringContent(json)
            };
        }
    }
}
