using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AdoptMe.Models;

namespace AdoptMe.Services
{
    public class AuthenticatorService
    {
      

        public async Task<bool> Registration(string email, string password, string confirmPassword)
        {

            var client = new HttpClient();
            CreateUserBindingModel objCreateUserBindingModel = new CreateUserBindingModel { Email = email, ConfirmPassword = confirmPassword, Password = password };

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(objCreateUserBindingModel);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var resonse = await client.PostAsync("http://http://petsadoption.us/api/Account/register", content);
            return resonse.IsSuccessStatusCode;

        }
        public async Task<string> LoginAsync(string email, string password)
        {
            var request = new HttpRequestMessage(
                HttpMethod.Post,
                "http://petsadoption.us/Token");

            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", email),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            HttpResponseMessage response = null;
            AuthResponse result = null;

            try
            {
                response = await client.SendAsync(request);


            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            RootObject RootObject = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(await response.Content.ReadAsStringAsync());
            // getVaulkesAsync(RootObject.access_token);
            return RootObject.access_token;


        }

        public async Task<List<string>> getVaulkesAsync(string Token)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            try
            {
                var item = await client.GetStringAsync("http://aspnet82.azurewebsites.net/api/values");
                var json = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(item);
                return json;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
       

    }
}
