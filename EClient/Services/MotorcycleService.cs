using EClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EClient.Services
{
    public class MotorcycleService : IMotorcycleService
    {
        private const string ErrorCodeResponseFailed = "Http respone has failed";
        private const string SandboxUrl = "https://eserver.azurewebsites.net/";

        private static Random random = new Random();

        private readonly HttpClient _client;

        public MotorcycleService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Motorcycle>> GetAllAsync()
        {
            var httpResponse = await _client.GetAsync($"{SandboxUrl}/api/{nameof(Motorcycle)}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception(ErrorCodeResponseFailed);
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Motorcycle>>(content);
        }

        public async Task<Motorcycle> GetAsync(Guid id)
        {
            var httpResponse = await _client.GetAsync($"{SandboxUrl}/api/{nameof(Motorcycle)}/{id}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception(ErrorCodeResponseFailed);
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Motorcycle>(content);
        }

        public async Task CreateAsync(Motorcycle motorcycle)
        {
            var serializedMotorcycle = JsonConvert.SerializeObject(motorcycle);
            var httpResponse = await _client.PostAsync($"{SandboxUrl}/api/{ nameof(Motorcycle)}", new StringContent(serializedMotorcycle, Encoding.Default, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception(ErrorCodeResponseFailed);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var httpResponse = await _client.DeleteAsync($"{SandboxUrl}/api/{nameof(Motorcycle)}/{id}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception(ErrorCodeResponseFailed);
            }
        }
    }
}
