using AuthorizationLibrary;
using LoginManagement.Entities;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Frontend.Infrastructure
{
    public interface IAuthenticatService
    {
        public Task<AuthenticationResponse> Authenticate(AuthenticationRequest request);
        public Task<User> GetUserModel(int userId);
    }

    public class AuthenticationService : IAuthenticatService
    {
        private readonly ApiConfigurations _apiConfigs;
        public AuthenticationService(
            IOptions<ApiConfigurations> apiConfigs
            )
        {
            _apiConfigs = apiConfigs.Value;
        }

        public async Task<AuthenticationResponse> Authenticate(AuthenticationRequest model)
        {
            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                IncludeFields = true
            };
            var jsonContent = JsonContent.Create<AuthenticationRequest>(
                inputValue: model,
                mediaType: new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"),
                options: serializerOptions
            );
            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_apiConfigs.AuthBaseUrl);

            var response = await client.PostAsync(_apiConfigs.AuthenticateUrl, jsonContent);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<AuthenticationResponse>();

            return result!;
        }

        public async Task<User> GetUserModel(int userId)
        {
            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_apiConfigs.AuthBaseUrl);

            var response = await client.GetAsync($"{_apiConfigs.AuthenticateUrl}/{userId}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<User>();
            return result!;
        }
    }
}
