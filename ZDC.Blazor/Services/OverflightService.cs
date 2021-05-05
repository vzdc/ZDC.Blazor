using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ZDC.Models;

namespace ZDC.Blazor.Services
{
    public class OverflightService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;

        public OverflightService(IConfiguration config)
        {
            _client = new HttpClient();
            _config = config;
        }

        public async Task<IList<Overflight>> GetOverflights()
        {
            return await _client.GetFromJsonAsync<IList<Overflight>>(_config.GetValue<string>("Overflights"));
        }
    }
}