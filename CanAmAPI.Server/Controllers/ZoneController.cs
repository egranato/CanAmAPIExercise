using CanAmAPI.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Diagnostics;
using System.Text.Json;

namespace CanAmAPI.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZoneController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ZoneController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet(Name = "GetZones")]
        [ResponseCache(Duration = 604800)]
        public async Task<List<Zone>> Get(string state)
        {
            var response = new List<Zone>();

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://api.weather.gov/zones?area={state}")
            {
                Headers =
                {
                    { HeaderNames.UserAgent, "CanamInterviewExcersize" }
                }
            };
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                Trace.WriteLine(httpResponseMessage.Content.ToString());
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<ZoneResponse>(contentStream);

                if (data != null)
                {
                    foreach (var zone in data.features)
                    {
                        response.Add(new Zone(zone));
                    }
                }
            }

            return response;
        }
    }
}
