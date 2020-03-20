using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;
namespace client.Api
{
    class API
    {
        private static API _instance = null;
        private string BASE_URL = "https://localhost:44390/api/";
        public RestClient Client { get; private set; }
        public static API getInstance()
        {
            if(_instance == null)
            {
                _instance = new API();
            }
            return _instance;
        }
        private API()
        {
            Initialize();
        }
        private void Initialize()
        {
            Client = new RestClient(BASE_URL);
        }
    }
}
