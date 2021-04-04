using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ZDC.Models;

namespace ZDC.Blazor.Services
{
    public class AnnouncementService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;

        public AnnouncementService(IConfiguration config)
        {
            _client = new HttpClient();
            _config = config;
        }

        public async Task<IList<Announcement>> GetAnnouncements()
        {
            var response = await _client.GetAsync(_config.GetValue<string>("Announcements"));
            return !response.IsSuccessStatusCode
                ? null
                : JsonConvert.DeserializeObject<IList<Announcement>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<IList<Announcement>> GetAnnouncementsFull()
        {
            var response = await _client.GetAsync(_config.GetValue<string>("AnnouncementsFull"));
            return !response.IsSuccessStatusCode
                ? null
                : JsonConvert.DeserializeObject<IList<Announcement>>(await response.Content.ReadAsStringAsync());
        }
    }
}