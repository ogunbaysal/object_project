using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using server;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace server_test.Core
{
    public class TestClientProvider
    {
        public HttpClient Client { get; private set; }

        public TestClientProvider()
        {
            var testServer = new TestServer(new WebHostBuilder().UseStartup<TestStartup>().UseEnvironment("Development"));

            Client = testServer.CreateClient();
        }
    }
}
