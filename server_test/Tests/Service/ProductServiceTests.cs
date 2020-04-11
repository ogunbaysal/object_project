using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moq;
using server.Models.Product;
using server.Repositories.Interface;
using server.Services;
using Xunit;

namespace server_test.Tests.Service
{
    public class ProductServiceTests
    {
        private Mock<IRepository<Product>> _productRepo;
        private Mock<IRepository<ProductProperty>> _productPropertyRepo;
        private Mock<IRepository<ProductImage>> _productImageRepo;

        private IProductService _productService;
        public ProductServiceTests()
        {
            SetupMocks();
            _productService = new ProductService(_productRepo.Object, _productPropertyRepo.Object, _productImageRepo.Object);
        }

        private void SetupMocks()
        {
            _productRepo = new Mock<IRepository<Product>>();
            _productRepo.Setup(x => x.FindByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(new Product()
                {
                    ProductId =  1,
                    ChildCategoryId = 2,
                    DateCreated = DateTime.Today,
                    DateModified = DateTime.Today,
                    Title = "Hello new Product",
                    Description = "It is a description",
                    Status = ProductStatus.ACTIVE
                });
            

        }

        
    }
}
