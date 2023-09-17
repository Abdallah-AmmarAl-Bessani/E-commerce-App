namespace E_commerce_Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
		//[Fact]
		//public async Task EditProduct_WithValidData_ReturnsRedirectToActionAndSetsImageUrl()
		//{
		//    // Arrange
		//    var product = new Product { ID = 1 };
		//    var fileMock = new Mock<IFormFile>();
		//    var addImageServiceMock = new Mock<IAddImage>();
		//    var productServiceMock = new Mock<IProduct>();
		//    var configurationMock = new Mock<IConfiguration>();

		//    fileMock.Setup(f => f.FileName).Returns("test.jpg");
		//    fileMock.Setup(f => f.ContentType).Returns("image/jpeg");

		//    // Mock the uploadImage method to return the product with imageURL set
		//    addImageServiceMock
		//        .Setup(service => service.UploadImage(It.IsAny<IFormFile>(), It.IsAny<Product>()))
		//        .Callback<IFormFile, Product>((file, p) => p.ImageURL = "https://example.com/test.jpg") // Set imageURL
		//        .ReturnsAsync(product);

		//    productServiceMock
		//        .Setup(service => service.UpdateProductAsync(It.IsAny<int>(), It.IsAny<Product>()))
		//        .ReturnsAsync(product); // Mock the UpdateProductAsync method to return a success result

		//    var controller = new ProductController(productServiceMock.Object, addImageServiceMock.Object);

		//    // Act
		//    var result = await controller.EditProduct(product, 1, fileMock.Object) as RedirectToActionResult;

		//    // Assert
		//    Assert.NotNull(result);
		//    Assert.Equal("ProductDetails", result.ActionName);
		//    Assert.Equal(product.ID, result.RouteValues["ID"]);

		//    // Assert that imageURL is set in the returned product
		//    Assert.Equal("https://example.com/test.jpg", product.ImageURL);
		//}

	}
}