using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using blockathon.smartcontract.interfaces;
using blockathon.shared;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using blockathon.shared.model;

namespace blockathon.rdw.oracle.service.Controllers
{
    [Route("api/[controller]")]
    public class RDWCheckController : Controller
    {
        private readonly ISmartContract _smartContract;
        private readonly ILogger<RDWCheckController> _logger;
        public RDWCheckController(ILogger<RDWCheckController> logger, ISmartContract smartContract)
        {
            _logger = logger;
            _smartContract = smartContract;
        }

        // GET api/RDWCheck/kenteken
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        [HttpGet("{kenteken}")]
        public IActionResult CheckKenteken(string kenteken)
        {
            // Start a task, do not wait for the result. Must be fail safe
            DoCheckKenteken(kenteken);

            return new AcceptedResult();
        }
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

        // Internal to make it unit testable
        internal async Task DoCheckKenteken(string kenteken)
        {
            var sKenteken = kenteken.ToUpper();
            sKenteken = kenteken.Replace("-", "");

            var url = $"{Constants.RDWWebApi}?kenteken={sKenteken}";
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(url);
                if (!result.IsSuccessStatusCode)
                {
                    _logger.LogCritical($"Error getting information from the RDW");
                }
                // Get the information
                var content = await result.Content.ReadAsStringAsync();

                // Check if we have at lease one valid car
                var autos = JsonConvert.DeserializeObject<List<RDWAuto>>(content);
                if (autos.Count > 0)
                {
                    // Send the data to the contract
                    _smartContract.Callout(content);
                }
                else
                {
                    _logger.LogWarning($"Cannot find information for {kenteken}");
                }
            }
        }
    }
}
