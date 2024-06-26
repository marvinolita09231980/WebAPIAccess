﻿using Newtonsoft.Json;
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
    public class ListOfEmployees4IPCRController : ApiController
    {
        private string connetionString = GlobalClass.connetionString_pay;
        SqlConnection con;

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]

        public HttpResponseMessage post()
        {
            List<sp_get_allpersonnel_names_ipcr_api> data = new List<sp_get_allpersonnel_names_ipcr_api>();
            con = new SqlConnection(connetionString);

            con.Open();
            SqlCommand sql = new SqlCommand("sp_get_allpersonnel_names_ipcr_api", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.CommandTimeout = Int32.MaxValue;
            using (SqlDataReader reader = sql.ExecuteReader())
            {
                while (reader.Read())
                {
                    sp_get_allpersonnel_names_ipcr_api list = new sp_get_allpersonnel_names_ipcr_api();
                    list.empl_id = reader.GetString(0);
                    list.employee_name = reader.GetString(1);
                    list.last_name = reader.GetString(2);
                    list.first_name = reader.GetString(3);
                    list.middle_name = reader.GetString(4);
                    list.suffix_name = reader.GetString(5);
                    list.postfix_name = reader.GetString(6);
                    list.courtisy_title = reader.GetString(7);
                    list.gender = reader.GetString(8);
                    list.birth_date = reader.GetString(9);
                    list.age = reader.GetString(10);
                    list.department_code = reader.GetString(11);
                    list.subdepartment_code = reader.GetString(12);
                    list.division_code = reader.GetString(13);
                    list.section_code = reader.GetString(14);
                    list.position_code = reader.GetString(15);
                    list.department_name1 = reader.GetString(16);
                    list.department_proper_name = reader.GetString(17);
                    list.department_short_name = reader.GetString(18);
                    list.position_long_title = reader.GetString(19);
                    list.position_short_title = reader.GetString(20);
                    list.position_title1 = reader.GetString(21);
                    list.position_title2 = reader.GetString(22);
                    list.is_pghead = reader.GetBoolean(23);
                    list.salary_grade = reader.GetString(24);
                    list.employment_type = reader.GetString(25);
                    list.employment_type_descr = reader.GetString(26);
                    list.designate_department_code = reader.GetString(27);
                    list.active_status = reader.GetString(28);
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
