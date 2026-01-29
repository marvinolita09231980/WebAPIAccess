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
    public class DashBoardFilamentAPIController : ApiController
    {
        HRIS_PAYEntities db = new HRIS_PAYEntities();

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public HttpResponseMessage PostDashboardData([FromBody] DashboardFilamentRequest request)
        {
            try
            {
                var data = db.sp_hrprime_dashboard_reportAPI(
                    request.year,
                    request.month,
                    request.department_code,
                    request.dataType
                ).ToList();

                // Transform to separate lists
                var series = data.Select(d => Convert.ToInt32(d.var_value)).ToList();
                var labels = data.Select(d => d.var_labels.ToString()).ToList();

                var result = new[]
                {
                    new {
                        series = series,
                        labels = labels
                    }
                };

                var json = JsonConvert.SerializeObject(result, Formatting.Indented);
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



        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public HttpResponseMessage PlantillaOfPersonnel([FromBody] DashboardFilamentRequest request)
        {
            try
            {
                var plantilla = db.sp_plantilla_filament_API(
                    request.year.ToString(),
                    request.department_code
                ).ToList();

                var json = JsonConvert.SerializeObject(plantilla, Formatting.Indented);
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
