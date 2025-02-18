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
    public class SchoolsController : ApiController
    {
        HRIS_PAYEntities db = new HRIS_PAYEntities();

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Mvc.HttpPost]

        public HttpResponseMessage post([FromBody] string sync_type)
        {
            try
            {
                
                var json = "";
                if (sync_type == "schools")
                {
                     var data = db.schools_tbl.ToList();
                    json = JsonConvert.SerializeObject(data, Formatting.Indented);
                   
                }
                else if (sync_type == "courses")
                {
                    var data = db.courses_tbl.ToList();
                    json = JsonConvert.SerializeObject(data, Formatting.Indented);
                   
                }

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
