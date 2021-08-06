using Moq;
using Xunit;
using System.Linq;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Shoes_Website.Application.Products.Common;
using Shoes_Website.Application.Products.AddNewProduct;

namespace Shoes_Website.Application.UnitTests.Products.AddNewProduct
{
    public class AddProductCommandValidatorTest
    {
        private readonly Mock<IFormFile> _imageFile;

        public AddProductCommandValidatorTest()
        {
            _imageFile = new Mock<IFormFile>();
        }

        [Fact]
        public void AddProductCommand_ShouldBeFalse()
        {
            var command1 = new AddProductCommand
            {
                Name = "  ",
                DefaultPrice = 22,
                Original = "test",
                Description = "test",
                IsMenShoes = false,
                ImageFile = _imageFile.Object
            };

            var command2 = new AddProductCommand
            {
                Name = "test",
                DefaultPrice = 0,
                Original = "test",
                Description = "  ",
                IsMenShoes = true,
                ImageFile = _imageFile.Object
            };

            var command3 = new AddProductCommand
            {
                Name = "test",
                DefaultPrice = 22,
                Original = "  ",
                Description = "  ",
                IsMenShoes = false,
                ImageFile = _imageFile.Object
            };

            var command4 = new AddProductCommand
            {
                Name = "test",
                DefaultPrice = 22,
                Original = "  ",
                Description = "  ",
                IsMenShoes = false,
                ImageFile = null
            };

            var result1 = new AddProductCommandValidator().Validate(command1);
            var result2 = new AddProductCommandValidator().Validate(command2);
            var result3 = new AddProductCommandValidator().Validate(command3);
            var result4 = new AddProductCommandValidator().Validate(command4);

            result1.IsValid.Should().BeFalse();
            result2.IsValid.Should().BeFalse();
            result3.IsValid.Should().BeFalse();
            result4.IsValid.Should().BeFalse();
            result1.Errors.First().Equals(string.Format(ProductConstant.INVALID_PRODUCT_COMMAND, "Add new product"));
            result2.Errors.First().Equals(string.Format(ProductConstant.INVALID_PRODUCT_COMMAND, "Add new product"));
            result3.Errors.First().Equals(string.Format(ProductConstant.INVALID_PRODUCT_COMMAND, "Add new product"));
            result4.Errors.First().Equals(string.Format(ProductConstant.INVALID_PRODUCT_COMMAND, "Add new product"));
        }

        [Fact]
        public void AddProductCommand_ShouldBeTrue()
        {
            var command = new AddProductCommand
            {
                Name = "test",
                DefaultPrice = 22,
                Original = "test",
                Description = "  ",
                IsMenShoes = false,
                ImageFile = _imageFile.Object
            };

            var result = new AddProductCommandValidator().Validate(command);

            result.IsValid.Should().BeTrue();
        }
    }
}
