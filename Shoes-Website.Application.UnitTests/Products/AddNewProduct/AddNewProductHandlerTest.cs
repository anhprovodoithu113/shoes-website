using Moq;
using Xunit;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Shoes_Website.Domain.Intefaces;
using Shoes_Website.Application.Products.AddNewProduct;

namespace Shoes_Website.Application.UnitTests.Products.AddNewProduct
{
    public class AddNewProductHandlerTest
    {
        private readonly Mock<IRepository> _repository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<IFormFile> _formFile;

        private readonly AddNewProductHandler _handler;

        public AddNewProductHandlerTest()
        {
            _repository = new Mock<IRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _formFile = new Mock<IFormFile>();
            _handler = new AddNewProductHandler(_repository.Object, _unitOfWork.Object);

            //IFormFile file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("dummy image")), 0, 0, "Data", "image.png");
        }

        [Fact]
        public void AddNewProduct_WrongExtension_ThrowException()
        {
            var fileName = "testImage.cs";

            _formFile.Setup(r => r.FileName).Returns(fileName)
                                            .Verifiable();

            var command = new AddProductCommand
            {
                Name = "test",
                Original = "Test",
                DefaultPrice = 2,
                IsMenShoes = false,
                Description = "",
                ImageFile = _formFile.Object
            };

            Assert.ThrowsAnyAsync<AddProductException>(async () => await _handler.Handle(command, CancellationToken.None));
        }
    }
}
