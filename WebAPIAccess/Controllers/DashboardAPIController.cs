using Newtonsoft.Json;
using System;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPIAccess.Models;


namespace WebAPIAccess.Controllers
{
    public class DashboardAPIController : ApiController
    {
        HRIS_PAYEntities db = new HRIS_PAYEntities();
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public HttpResponseMessage GeneralListAPI([FromBody] DashboardFilamentRequest request)
        {
            try
            {
                db.Database.CommandTimeout = int.MaxValue;
                var data = db.sp_hrprime_dashboard_generallist_reportAPI(
                    request.year,
                    request.month,
                    request.department_code,
                    request.dataType
                ).ToList();

                var json = JsonConvert.SerializeObject(data, Formatting.Indented);
                return new HttpResponseMessage()
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
