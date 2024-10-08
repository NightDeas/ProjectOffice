﻿using Newtonsoft.Json;

using ProjectOffice.DataBase.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOffice.ApiLibrary
{
    public static class Api
    {
        static HttpClient _client = new();
        const string _url_adress = "https://localhost:7197";
        public static async Task<Models.UserModel> GetUserAsync(string Login, string Password)
        {
            HttpResponseMessage response = await _client.GetAsync($@"{_url_adress}/api/Auth?login={Login}&password={Password}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(responseBody);
                return Models.UserModel.ToDbModel(user);
            }
            return null;
        }
    }
}
