using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AwesomeApp.Models;

namespace AwesomeApp.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var response = await _httpClient.GetAsync("user");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<User>>(responseAsString);
        }

        public async Task<User> GetUser(Guid id)
        {
            var response = await _httpClient.GetAsync($"user/{id}");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<User>(responseAsString);
        }

        public async Task AddUser(User user)
        {
            var response = await _httpClient.PostAsync("user",
                new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteUser(User user)
        {
            var response = await _httpClient.DeleteAsync($"user/{user.Id}");

            response.EnsureSuccessStatusCode();
        }

        public async Task SaveUser(User user)
        {
            var response = await _httpClient.PutAsync($"user/{user.Id}",
                new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }
    }
}
