using System.Collections.Generic;
using System.Linq;
using Moq;
using SportsStores.Controllers;
using SportsStores.Models;
using Xunit;

namespace SportsStores.Tests
{
    public class ProductControllerTest
    {
        [Fact]
        public void Can_Paginate() {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductID = 1, Name = "p1"},
                new Product {ProductID = 2, Name = "p2"},
                new Product {ProductID = 3, Name = "p3"},
                new Product {ProductID = 4, Name = "p4"},
                new Product {ProductID = 5, Name = "p5"},
            }).AsQueryable<Product>());

            ProductControllers controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //Act
            ProductsListViewModel result =
                controller.List(2).ViewData.Model as ProductsListViewModel;
            //Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("p4", prodArray[0].Name);
            Assert.Equal("p5", prodArray[1].Name);

        }
    }
}
