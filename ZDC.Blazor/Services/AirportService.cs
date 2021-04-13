using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ZDC.Models;

namespace ZDC.Blazor.Services
{
    public class AirportService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;

        public AirportService(IConfiguration config)
        {
            _client = new HttpClient();
            _config = config;
        }

        public async Task<IList<Airport>> GetAirports()
        {
            var response = await _client.GetAsync(_config.GetValue<string>("Airports"));
            return !response.IsSuccessStatusCode
                ? null
                : JsonConvert.DeserializeObject<IList<Airport>>(await response.Content.ReadAsStringAsync());
        }
    }
}