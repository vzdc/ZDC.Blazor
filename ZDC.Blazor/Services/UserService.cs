using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ZDC.Models;

namespace ZDC.Blazor.Services
{
    public class UserService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;

        public UserService(IConfiguration config)
        {
            _client = new HttpClient();
            _config = config;
        }

        public async Task<IList<User>> GetUsers()
        {
            return await _client.GetFromJsonAsync<IList<User>>(_config.GetValue<string>("Users"));
        }

        public async Task<IList<User>> GetUsersFull()
        {
            return await _client.GetFromJsonAsync<IList<User>>(_config.GetValue<string>("UsersFull"));
        }

        public async Task<IList<Hours>> GetTopControllers()
        {
            return await _client.GetFromJsonAsync<IList<Hours>>(_config.GetValue<string>("UsersTop"));
        }

        public async Task<IList<Hours>> GetTopControllersFull()
        {
            return await _client.GetFromJsonAsync<IList<Hours>>(_config.GetValue<string>("UsersTopFull"));
        }

        public async Task<IList<User>> GetStaff()
        {
            return await _client.GetFromJsonAsync<IList<User>>(_config.GetValue<string>("Staff"));
        }

        public async Task<IList<User>> GetTrainingStaff()
        {
            return await _client.GetFromJsonAsync<IList<User>>(_config.GetValue<string>("TrainingStaff"));
        }
    }
}