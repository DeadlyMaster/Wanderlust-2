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
using Wanderlust.Services;
using Wanderlust.Utility;
using Xamarin.Forms;

namespace Wanderlust.Models
{
    public class LandmarkRepository : ILandmarkRepository
    {
        public async Task AddLandmarkAsync(Landmark landmark)
        {
            try
            {
                HttpClient httpClient = CreateHttpClient(ApiConstants.LandmarkApiUrl);

                var json = JsonConvert.SerializeObject(landmark);
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
                        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)) // retries 5 times in 2s, 4s, 8s...
                    )
                    .ExecuteAsync(async () => await httpClient.PostAsync(ApiConstants.LandmarkApiUrl, content));

                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return;
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

        public async Task DeleteLandmarkAsync(int id)
        {
            try
            {
                HttpClient httpClient = CreateHttpClient(ApiConstants.LandmarkApiUrl);

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
                    .ExecuteAsync(async () => await httpClient.DeleteAsync($"{ApiConstants.LandmarkApiUrl}/{id}"));

                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return;

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

        public async Task<List<Landmark>> GetLandmarksAsync()
        {
            try
            {
                HttpClient httpClient = CreateHttpClient(ApiConstants.LandmarkApiUrl);
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
                    //.CircuitBreakerAsync(exceptionsAllowedBeforeBreaking: 2, durationOfBreak: TimeSpan.FromSeconds(30))
                    .ExecuteAsync(async () =>
                        await httpClient.GetAsync(ApiConstants.LandmarkApiUrl)
                    );

                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var json = JsonConvert.DeserializeObject<List<Landmark>>(jsonResult);
                    return json;
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

        public async Task<List<Landmark>> GetMustSeeLandmarksAsync()
        {
            try
            {
                HttpClient httpClient = CreateHttpClient(ApiConstants.MustSeeLandmarkApiUrl);
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
                    //.CircuitBreakerAsync(exceptionsAllowedBeforeBreaking: 2, durationOfBreak: TimeSpan.FromSeconds(30))
                    .ExecuteAsync(async () =>
                        await httpClient.GetAsync(ApiConstants.MustSeeLandmarkApiUrl)
                    );

                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var json = JsonConvert.DeserializeObject<List<Landmark>>(jsonResult);
                    return json;
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

        public async Task<Landmark> GetLandmarkAsync(int id)
        {
            try
            {
                HttpClient httpClient = CreateHttpClient(ApiConstants.LandmarkApiUrl);
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
                    .ExecuteAsync(async () => await httpClient.GetAsync($"{ApiConstants.LandmarkApiUrl}/{id}"));

                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var json = JsonConvert.DeserializeObject<Landmark>(jsonResult);
                    return json;
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

        public async Task UpdateLandmarkAsync(Landmark landmark)
        {
            try
            {
                HttpClient httpClient = CreateHttpClient(ApiConstants.LandmarkApiUrl);

                var content = new StringContent(JsonConvert.SerializeObject(landmark));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                string jsonResult = string.Empty;

                await httpClient.PutAsync(ApiConstants.LandmarkApiUrl, content);

                //var responseMessage = await Policy
                //    .Handle<HttpRequestException>(ex =>
                //    {
                //        Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
                //        return true;
                //    })
                //    .WaitAndRetryAsync
                //    (
                //        5,
                //        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                //    )
                //    .ExecuteAsync(async () => await httpClient.PutAsync(ApiConstants.LandmarkApiUrl, content));

                

                //if (responseMessage.IsSuccessStatusCode)
                //{
                //    jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                //    return;
                //}

                //if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                //    responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                //{
                //    throw new ServiceAuthentificationException(jsonResult);
                //}

                //throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);

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
