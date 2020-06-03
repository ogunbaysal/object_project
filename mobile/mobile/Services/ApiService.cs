using mobile.Models;
using mobile.Models.Enums;
using mobile.Plugins;
using mobile.Plugins.Interface;
using Newtonsoft.Json;
using Plugin.SecureStorage;
using Plugin.SecureStorage.Abstractions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mobile.Services
{
    public abstract class ApiService
    {
        private string TOKEN_NAME;
        public const string BASE_URL = "http://maviapi.azurewebsites.net/api/";
        protected RestClient Client = null;
        private ISecureStorage _secureStorage;
        public ApiService()
        {
            TOKEN_NAME = StorageKeys.ACCESS_TOKEN.Value;
            _secureStorage = App.Resolve<IStorage>().SecureStorage;
            Client = new RestClient(BASE_URL);

            if(_secureStorage.HasKey(TOKEN_NAME))
            {
                var token = _secureStorage.GetValue(TOKEN_NAME);
                Client.AddDefaultHeader("Authorization", "Bearer " + token);
            }
        }

        protected async Task<Result> PostAsync(string uri, object requestObject, Dictionary<string, string> headers = null)
        {
            var request = new RestRequest(uri, Method.POST, DataFormat.Json);
            var result = await GetResultAsync(Client, request, requestObject, headers);

            return result;
        }
        protected Result Post(string uri, object requestObject, Dictionary<string, string> headers = null)
        {
            var request = new RestRequest(uri, Method.POST, DataFormat.Json);
            var result = GetResult(Client, request, requestObject, headers);

            return result;
        }
        protected Result Get(string uri, Dictionary<string, string> headers = null)
        {
            var request = new RestRequest(uri, Method.GET, DataFormat.Json);
            var result = GetResult(Client, request, null, headers);
            return result;
        }
        protected async Task<Result> GetAsync(string uri, Dictionary<string, string> headers = null)
        {
            var request = new RestRequest(uri, Method.GET, DataFormat.Json);
            var result = await GetResultAsync(Client, request, null, headers);
            return result;
        }

        protected async Task<Result> PutAsync(string uri, object requestObject, Dictionary<string, string> headers = null)
        {
            var request = new RestRequest(uri, Method.PUT, DataFormat.Json);
            var result = await GetResultAsync(Client, request, requestObject, headers);

            return result;
        }
        protected Result Put(string uri, object requestObject, Dictionary<string, string> headers = null)
        {
            var request = new RestRequest(uri, Method.PUT, DataFormat.Json);
            var result = GetResult(Client, request, requestObject, headers);

            return result;
        }
        protected async Task<Result> DeleteAsync(string uri, Dictionary<string, string> headers = null)
        {
            var request = new RestRequest(uri, Method.DELETE, DataFormat.Json);
            var result = await GetResultAsync(Client, request, null, headers);

            return result;
        }
        protected Result Delete(string uri, Dictionary<string, string> headers = null)
        {
            var request = new RestRequest(uri, Method.DELETE, DataFormat.Json);
            var result = GetResult(Client, request, null, headers);

            return result;
        }

        private async Task<Result> GetResultAsync(RestClient client, RestRequest request, object requestObject = null, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }

            if (requestObject != null)
            {
                request.AddJsonBody(requestObject);
            }

            var response = await client.ExecuteAsync(request);

            if(response.IsSuccessful)
            {
                Result deserialized = JsonConvert.DeserializeObject<Result>(response.Content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include });
                return deserialized;
            }
            else
            {
                return null;
            }

            
        }

        private Result GetResult(RestClient client, RestRequest request, object requestObject = null, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }

            if (requestObject != null)
            {
                request.AddJsonBody(requestObject);
            }

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Result deserialized = JsonConvert.DeserializeObject<Result>(response.Content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include });
                return deserialized;
            }
            else
            {
                return null;
            }


        }
    }
}
