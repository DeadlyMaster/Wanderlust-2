using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Wanderlust.Interfaces.Repository;
using Wanderlust.Models;
using Wanderlust.Services;
using Wanderlust.Utility;
using Xamarin.Forms;

namespace Wanderlust.Repository
{
    public class UserRepository : IUserRepository
    {
        // 2 postAsync functions - register and Authenticate
        public async Task<User> GetUserAsync(string username)
        {
            try
            {
                HttpClient httpClient = CreateHttpClient(ApiConstants.AuthenticateApiUrl);

                var json = JsonConvert.SerializeObject(username);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                string jsonResult = string.Empty;

                var responseMessage = await Policy
                    .Handle<HttpRequestException>(ex =>
                    {
                        Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
                        return true;
                    })
                    .WaitAndRetryAsync
                    (
                        5,
                        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                    )
                    .ExecuteAsync(async () => await httpClient.GetAsync(ApiConstants.AuthenticateApiUrl));

                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var json2 = JsonConvert.DeserializeObject<User>(jsonResult);
                    return json2;
                }

                if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                    responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new ServiceAuthentificationException(jsonResult);
                }

                throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);

            }
            catch (Exception e)
            {
                Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
                throw;
            }
        }

        public async Task<User> RegisterUser(User user)
        {
            try
            {
                HttpClient httpClient = CreateHttpClient(ApiConstants.AuthenticateApiUrl);
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                string jsonResult = string.Empty;

                var responseMessage = await Policy
                    .Handle<HttpRequestException>(ex =>
                    {
                        Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
                        return true;
                    })
                    .WaitAndRetryAsync
                    (
                        5,
                        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                    )
                    //.ExecuteAsync(async () => await httpClient.GetAsync($"{ApiConstants.LandmarkApiUrl}/{username}"));
                    .ExecuteAsync(async () => await httpClient.PostAsync(ApiConstants.AuthenticateApiUrl, content));

                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var json2 = JsonConvert.DeserializeObject<User>(jsonResult);
                    return json2;
                }

                if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                    responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new ServiceAuthentificationException(jsonResult);
                }

                throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);

            }
            catch (Exception e)
            {
                Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
                throw;
            }
        }

        private HttpClient CreateHttpClient(string authToken)
        {
            var httpClient = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(authToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            }
            return httpClient;
        }
    }
}
