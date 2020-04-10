using server;
using server_test.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace server_test.Tests.Product
{
    public class ProductTests
    {
        
        [Fact]
        public async Task Test_Get_All_Products()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/product/all");
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
        [Fact]
        public async Task Test_Get_One_Product()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/product/one/1");
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
        [Fact]
        public async Task Test_Get_Product_Properties_For_One_Product()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/properties/1");
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
        [Fact]
        public async Task Test_Property_Image_By_Property_Id()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/properties/image/1");
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
