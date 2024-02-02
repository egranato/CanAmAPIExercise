using CanAmAPI.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;

namespace CanAmAPI.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StationController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public StationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet(Name = "GetStations")]
        [ResponseCache(Duration = 604800)]
        public async Task<List<Station>> Get(string state)
        {
            var response = new List<Station>();

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://api.weather.gov/stations?state={state}&limit=500")
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

                var data = await JsonSerializer.DeserializeAsync<StationResponse>(contentStream);

                if (data != null)
                {
                    foreach (var station in data.features)
                    {
                        var newStation = new Station(station);
                        response.Add(newStation);
                    }
                }
            }

            return response;
        }
    }
}
