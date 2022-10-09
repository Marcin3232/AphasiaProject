using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AphasiaClientApp.Extensions.RequestMethod
{
    public class RequestMethod : IRequestMethod
    {
        public async Task<T> Get<T>(string path, HttpClient httpClient)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, path);
                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                    return await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync());

                return default;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<TResult> Post<T, TResult>(string path, HttpClient httpClient, T data)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, path);
                request.Content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

                using var response = await httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                    throw new Exception(error["message"]);
                }

                return await response.Content.ReadFromJsonAsync<TResult>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

        public async Task<TResult> Delete<T, TResult>(string path, HttpClient httpClient, T data)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, path);
                request.Content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

                using var response = await httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                    throw new Exception(error["message"]);
                }

                return await response.Content.ReadFromJsonAsync<TResult>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                throw new Exception(ex.Message);
            }

        }
    }
}
