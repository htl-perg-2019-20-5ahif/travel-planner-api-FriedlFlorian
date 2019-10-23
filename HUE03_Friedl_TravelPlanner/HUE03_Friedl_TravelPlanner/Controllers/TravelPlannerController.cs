using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelPlannerLogic;

namespace HUE03_Friedl_TravelPlanner.Controllers
{
    [Route("api/travelPlan")]
    [ApiController]
    public class TravelPlannerController : ControllerBase
    {
        TravelPlannerLogic.BusSchedule[] bs;

        private HttpClient client;

        public TravelPlannerController(IHttpClientFactory clientFactory)
        {
            client = clientFactory.CreateClient(); ;

        }
        // GET: api/TravelPlanner
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] string from, [FromQuery] string to, [FromQuery] string start )
        {
            var travelResponse = await client.GetAsync("https://cddataexchange.blob.core.windows.net/data-exchange/htl-homework/travelPlan.json");
            travelResponse.EnsureSuccessStatusCode();
            var responseBody = await travelResponse.Content.ReadAsStringAsync();
            bs = JsonSerializer.Deserialize<BusSchedule[]>(responseBody);
            
            string ret = TravelPlanLogic.planTrip(bs, from, to, start);

            return Ok(ret);
        }
    }
}
