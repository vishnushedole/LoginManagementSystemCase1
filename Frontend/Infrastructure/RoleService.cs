using AuthorizationLibrary;
using LoginManagement.Entities;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using NuGet.Common;
using System.Text.Json;

namespace Frontend.Infrastructure
{
    public interface IRoleService
    { 
        public Task<IEnumerable<Role>> GetRoles();
    }
    public class RoleService:IRoleService
    {
        private readonly ApiConfigurations _apiConfigs;
        private readonly string token;
        public RoleService(
            IHttpContextAccessor contextAccessor,
           IOptions<ApiConfigurations> apiConfigs
           )
        {
            token = contextAccessor.HttpContext.Session.GetString("Token")!;
            _apiConfigs = apiConfigs.Value;
        }

        //public async Task<IEnumerable<Role>> GetRoles()
        //{
        //    var serializerOptions = new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true,
        //        IncludeFields = true
        //    };

        //    using HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri(_apiConfigs.RoleBaseUrl);

        //    var response = await client.GetAsync("api/roles/list");
        //    response.EnsureSuccessStatusCode();
        //    var result = await response.Content.ReadFromJsonAsync<Role>();
        //    Console.WriteLine(result);
        //    return (IEnumerable<Role>)result;
        //}
        public async Task<IEnumerable<Role>> GetRoles()
        {

            var result = await ApiHelper.ExecuteHttpGet<List<Role>>(
                url: "api/roles/list",
                token: token,
                baseUrl: _apiConfigs.RoleBaseUrl);
            return result;
        }
    }
}
