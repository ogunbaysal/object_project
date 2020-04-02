using client.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace client.Api.Core
{
    public class ApiService
    {
        private string BASE_URL = "https://localhost:44390/api/";
        protected RestClient Client { get; private set; }
        public ApiService()
        {
            Client = new RestClient(BASE_URL);
        }
        protected Result PostMethod(object requestObject, string uri, Dictionary<string, string> headers = null)
        {
            var request = new RestRequest(uri, Method.POST, DataFormat.Json);
            var result = GetResult(Client, request, requestObject, headers);

            return result;
        }

        protected Result GetMethod(string uri, Dictionary<string, string> headers = null)
        {
            var request = new RestRequest(uri, Method.GET, DataFormat.Json);
            var result = GetResult(Client, request, null, headers);
            return result;
        }

        protected Result PutMethod(object requestObject, string uri, Dictionary<string, string> headers = null)
        {
            var request = new RestRequest(uri, Method.PUT, DataFormat.Json);
            var result = GetResult(Client, request, requestObject, headers);

            return result;
        }

        protected Result DeleteMethod(string uri, Dictionary<string, string> headers = null)
        {
            var request = new RestRequest(uri, Method.DELETE, DataFormat.Json);
            var result = GetResult(Client, request, null, headers);

            return result;
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
            Result deserialized = JsonConvert.DeserializeObject<Result>(response.Content, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include });
            return deserialized;
        }
    }
}
