using blockathon.shared;
using blockathon.smartcontract.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OpenAlprApi.Model;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace blockathon.rdw.oracle.service.Controllers
{
    [Route("api/[controller]")]
    public class PhotoController : ControllerBase
    {
        // TODO: Replace with thread safe list

        public PhotoController(ILogger<PhotoController> logger, ISmartContract smartContract) : base(logger, smartContract)
        { }

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        [HttpPost]
        public IActionResult AnalyzePhoto([FromBody]string url)
        {
            if (AddInProgress(url))
            {
                DoAnalyzePhoto(url); // Do not wait
            }
            return new AcceptedResult();
        }
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

        internal async Task DoAnalyzePhoto(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var sUrl = $"{Constants.OpenALPR}&image_url={url}";
                    var result = await client.PostAsync(sUrl, null);
                    if (!result.IsSuccessStatusCode)
                    {
                        _logger.LogCritical($"Error analyzing image {url}");
                    }
                    else
                    {
                        var raw_response = await result.Content.ReadAsByteArrayAsync();
                        var content = Encoding.UTF8.GetString(raw_response, 0, raw_response.Length);

                        var response = JsonConvert.DeserializeObject<InlineResponse200>(content);

                        if (response.Results.Count > 0)
                        {
                            response.Results.Sort((x, y) => x.Confidence.Value.CompareTo(y.Confidence.Value));
                            _smartContract.Callout(response.Results.First().Plate);
                        }
                        else
                        {
                            _logger.LogWarning($"No plate found in {url}");
                        }
                    }
                }
            }
            finally
            {
                RemoveInProgress(url);
            }
        }
    }
}
