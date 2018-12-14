using clean.architecture.core.SharedKernel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace clean.architecture.functional.test.Api
{
    public abstract class BaseWebControllerServiceTest<T> : BaseWebControllerTest<T> where T : BaseEntity
    {
        protected async Task<IEnumerable<T>> GetList(string url)
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<T>>(stringResponse);
        }

        protected async Task<T> GetById(string url)
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringResponse);
        }

        protected async Task Post(string url, object obj)
        {
            var response = await _client.PostAsync(url, GetPayLoad(obj));
            response.EnsureSuccessStatusCode();
        }

        protected async Task<T> Patch(string url, object obj)
        {
            var response = await _client.PatchAsync(url, GetPayLoad(obj));

            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(stringResponse);
        }

        protected HttpContent GetPayLoad(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
