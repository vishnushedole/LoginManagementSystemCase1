using LoginManagement.Entities;
using Microsoft.Extensions.Options;

namespace UsersAPI
{
    public class CustomAuthenticationMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        public CustomAuthenticationMiddleWare(RequestDelegate next, IOptions<AppSettings> options)
        {
            _next = next;
            _appSettings = options.Value;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var authHeader = context.Request.Headers["Authorization"];
            var authHeaderValue = authHeader.FirstOrDefault();
            if (authHeaderValue != null)
            {
                var token = authHeaderValue.Split(" ").Last();

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_appSettings.AuthAPIBaseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var response = await client.GetAsync(_appSettings.AuthAPIValidateUrl);
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadFromJsonAsync<User>();
                    if (result != null)
                    {
                        context.Items["User"] = result;
                    }
                }
            }
            await _next(context);
        }
    }
}
