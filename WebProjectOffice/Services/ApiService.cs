using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectOffice.DataBase.Entities;

namespace WebProjectOffice.Services
{
    public class ApiService
    {
        public const string _url_adress = "https://localhost:7197";
        private static HttpClient _client = new HttpClient();


        public static async Task<User> GetUser(string Login, string Password)
        {
            HttpResponseMessage response = await _client.GetAsync($@"{_url_adress}/api/Users/auth?login={Login}&password={Password}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                User user = JsonConvert.DeserializeObject<User>(responseBody);
                return user;
            }
            return null;
        }
    }
}
