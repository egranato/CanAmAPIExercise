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
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public WeatherForecastController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet(Name = "GetStationForecast")]
        public async Task<ForecastResponse> GetStationForecast(double latitude, double longitude)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://api.weather.gov/points/{latitude},{longitude}")
            {
                Headers =
            {
                { HeaderNames.UserAgent, "CanamInterviewExcersize" }
            }
            };
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            Trace.WriteLine(httpResponseMessage.Content.ToString());
            using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<PointResponse>(contentStream);

            var forecast = await getForecast<ForecastResponse>(data.properties.forecastGridData);

            return forecast;
        }

        [HttpGet(Name = "GetZoneForecast")]
        public async Task<ForecastResponse> GetZoneForecast(string id, string type)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://api.weather.gov/zones/{type}/{id}")
            {
                Headers =
            {
                { HeaderNames.UserAgent, "CanamInterviewExcersize" }
            }
            };
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            Trace.WriteLine(httpResponseMessage.Content.ToString());
            using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<ZoneDetailResponse>(contentStream);

            var coordinates = findPolygonCenter(data.geometry.coordinates[0]);

            return await GetStationForecast(coordinates[1], coordinates[0]);
        }

        private async Task<T> getForecast<T>(string url, int attempts = 0)
        {
            // implemented retry and back off because this endpoint fails sometimes
            if (attempts > 3)
            {
                throw new ArgumentException("Retry has failed too many times, please try again later");
            }

            if (attempts > 0)
            {
                await Task.Delay((int)Math.Pow(2, attempts)).ConfigureAwait(false);
            }

            try
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url)
                {
                    Headers =
                {
                    { HeaderNames.UserAgent, "CanamInterviewExcersize" }
                }
                };
                var httpClient = _httpClientFactory.CreateClient();
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                httpResponseMessage.EnsureSuccessStatusCode();

                Trace.WriteLine(httpResponseMessage.Content.ToString());
                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                var data = await JsonSerializer.DeserializeAsync<T>(contentStream);

                return data;
            }
            catch(HttpRequestException)
            {
                return await getForecast<T>(url, attempts + 1);
            }
        }

        private List<double> findPolygonCenter(List<List<double>> polygonCoordinates)
        {
            int numVertices = polygonCoordinates.Count;
            double sumX = 0.0, sumY = 0.0;

            // Calculate the centroid of the polygon
            foreach (var vertex in polygonCoordinates)
            {
                sumX += vertex[0];
                sumY += vertex[1];
            }

            double centerX = sumX / numVertices;
            double centerY = sumY / numVertices;

            return new List<double> { centerX, centerY };
        }
    }
}
