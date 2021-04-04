using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ZDC.Models;

namespace ZDC.Blazor.Services
{
    public class OnlineControllerService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;

        public OnlineControllerService(IConfiguration config)
        {
            _client = new HttpClient();
            _config = config;
        }

        public async Task<IList<OnlineController>> GetOnlineControllers()
        {
            var response = await _client.GetAsync(_config.GetValue<string>("OnlineControllers"));
            return !response.IsSuccessStatusCode
                ? null
                : JsonConvert.DeserializeObject<IList<OnlineController>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<IList<OnlineController>> GetOnlineControllersFull()
        {
            var response = await _client.GetAsync(_config.GetValue<string>("OnlineControllersFull"));
            return !response.IsSuccessStatusCode
                ? null
                : JsonConvert.DeserializeObject<IList<OnlineController>>(await response.Content.ReadAsStringAsync());
        }
    }
}