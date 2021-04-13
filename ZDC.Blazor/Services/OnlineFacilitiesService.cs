using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ZDC.Models;

namespace ZDC.Blazor.Services
{
    public class OnlineFacilitiesService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;

        public OnlineFacilitiesService(IConfiguration config)
        {
            _client = new HttpClient();
            _config = config;
        }

        public async Task<IList<Facility>> GetOnlineFacilities()
        {
            var response = await _client.GetAsync(_config.GetValue<string>("OnlineFacilities"));
            return !response.IsSuccessStatusCode
                ? null
                : JsonConvert.DeserializeObject<IList<Facility>>(await response.Content.ReadAsStringAsync());
        }
    }
}