using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ZDC.Models;

namespace ZDC.Blazor.Services
{
    public class EventService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;

        public EventService(IConfiguration config)
        {
            _client = new HttpClient();
            _config = config;
        }

        public async Task<IList<Event>> GetEvents()
        {
            var response = await _client.GetAsync(_config.GetValue<string>("Events"));
            return !response.IsSuccessStatusCode
                ? null
                : JsonConvert.DeserializeObject<IList<Event>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<IList<Event>> GetEventsFull()
        {
            var response = await _client.GetAsync(_config.GetValue<string>("EventsFull"));
            return !response.IsSuccessStatusCode
                ? null
                : JsonConvert.DeserializeObject<IList<Event>>(await response.Content.ReadAsStringAsync());
        }
    }
}