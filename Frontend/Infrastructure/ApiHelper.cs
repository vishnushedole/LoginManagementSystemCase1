namespace Frontend.Infrastructure
{
    public static class ApiHelper
    {
        public static async Task<T> ExecuteHttpGet<T>(string url, string token, string baseUrl) where T : class
        {
            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl!);
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<T>();
            return result!;
        }
        /*public static async Task<TOutput> ExecuteHttpPost<TInput, TOutput>(
            string url, 
            string token, 
            string baseUrl,
            TInput inputObj
            )
        { 

            //JsonSerializer Options object 

            //Convert the input object to a JSON Content object

            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl!);
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var response = await client.PostAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<TOutput>();
            return result!;
        }*/
    }
}
