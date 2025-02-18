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
    public class ListOfEmployees4IPCRController : ApiController
    {
        private string connetionString = GlobalClass.connetionString_pay;
        SqlConnection con;

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]

        public HttpResponseMessage post([FromBody] string empl_id)
        {
            try
            {
               
                List<sp_get_allpersonnel_names_ipcr_api> data = new List<sp_get_allpersonnel_names_ipcr_api>();
                con = new SqlConnection(connetionString);

                con.Open();
                SqlCommand sql = new SqlCommand("sp_get_allpersonnel_names_ipcr_api", con);
                sql.Parameters.Add("@par_empl_id", SqlDbType.VarChar).Value = empl_id;
                sql.CommandType = CommandType.StoredProcedure;
                sql.CommandTimeout = Int32.MaxValue;

                using (SqlDataReader reader = sql.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sp_get_allpersonnel_names_ipcr_api list = new sp_get_allpersonnel_names_ipcr_api();

                        list.empl_id = reader.IsDBNull(0) ? null : reader.GetString(0);
                        list.employee_name = reader.IsDBNull(1) ? null : reader.GetString(1);
                        list.last_name = reader.IsDBNull(2) ? null : reader.GetString(2);
                        list.first_name = reader.IsDBNull(3) ? null : reader.GetString(3);
                        list.middle_name = reader.IsDBNull(4) ? null : reader.GetString(4);
                        list.suffix_name = reader.IsDBNull(5) ? null : reader.GetString(5);
                        list.postfix_name = reader.IsDBNull(6) ? null : reader.GetString(6);
                        list.courtisy_title = reader.IsDBNull(7) ? null : reader.GetString(7);
                        list.gender = reader.IsDBNull(8) ? null : reader.GetString(8);
                        list.birth_date = reader.IsDBNull(9) ? null : reader.GetString(9);
                        list.age = reader.IsDBNull(10) ? null : reader.GetString(10);
                        list.department_code = reader.IsDBNull(11) ? null : reader.GetString(11);
                        list.subdepartment_code = reader.IsDBNull(12) ? null : reader.GetString(12);
                        list.division_code = reader.IsDBNull(13) ? null : reader.GetString(13);
                        list.section_code = reader.IsDBNull(14) ? null : reader.GetString(14);
                        list.position_code = reader.IsDBNull(15) ? null : reader.GetString(15);
                        list.department_name1 = reader.IsDBNull(16) ? null : reader.GetString(16);
                        list.department_proper_name = reader.IsDBNull(17) ? null : reader.GetString(17);
                        list.department_short_name = reader.IsDBNull(18) ? null : reader.GetString(18);
                        list.position_long_title = reader.IsDBNull(19) ? null : reader.GetString(19);
                        list.position_short_title = reader.IsDBNull(20) ? null : reader.GetString(20);
                        list.position_title1 = reader.IsDBNull(21) ? null : reader.GetString(21);
                        list.position_title2 = reader.IsDBNull(22) ? null : reader.GetString(22);
                        list.is_pghead = !reader.IsDBNull(23) && reader.GetBoolean(23);
                        list.salary_grade = reader.IsDBNull(24) ? null : reader.GetString(24);
                        list.employment_type = reader.IsDBNull(25) ? null : reader.GetString(25);
                        list.employment_type_descr = reader.IsDBNull(26) ? null : reader.GetString(26);
                        list.designate_department_code = reader.IsDBNull(27) ? null : reader.GetString(27);
                        list.active_status = reader.IsDBNull(28) ? null : reader.GetString(28);
                        list.ao_tag = !reader.IsDBNull(29) && reader.GetBoolean(29);

                        data.Add(list);
                    }
                }

                con.Close();

                var json = JsonConvert.SerializeObject(data, Formatting.Indented);
                return new HttpResponseMessage()
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
    }
}
