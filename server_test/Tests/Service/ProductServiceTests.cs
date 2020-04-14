using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Moq;
using server.Controllers;
using server.Models;
using server.Models.Product;
using server.Repositories.Interface;
using server.Services;
using server_test.Core;
using Sieve.Models;
using Xunit;

namespace server_test.Tests.Service
{
    public class ProductServiceTests
    {
        private readonly IProductService _productService;
        private readonly Fixture _fixture;

        private readonly ProductController _sut;
        public ProductServiceTests()
        {
            _productService = A.Fake<IProductService>();
            _sut = new ProductController(_productService);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task Get_All_Products_Success()
        {
            var products = _fixture.CreateMany<Product>(3).ToList();

            A.CallTo(() => _productService.GetAllAsync(new SieveModel())).Returns(products);

            var result = await _sut.GetAll(new SieveModel());

            A.CallTo(() => _productService.GetAllAsync(new SieveModel())).MustHaveHappenedOnceExactly();
            Assert.IsType<ActionResult<Result>>(result);
            Assert.NotNull(result.Value.Data);
            Assert.Equal(products.Count, result.Value.Count);

        }
        
    }
}
