using Xunit;
using System.Linq;
using FluentAssertions;
using Shoes_Website.Application.Products.Common;
using Shoes_Website.Application.Products.AddProductColor;

namespace Shoes_Website.Application.UnitTests.Products.AddProductColor
{
    public class AddProductColorCommandValidatorTest
    {
        [Fact]
        public void AddProductColorCommand_ShouldBeFalse()
        {
            string errorMessage = string.Format(ProductConstant.INVALID_PRODUCT_COMMAND, " Add product color");

            var command1 = new AddProductColorCommand
            {
                ProductId = -1,
                Color = "test"
            };

            var command2 = new AddProductColorCommand
            {
                ProductId = 1,
                Color = "  "
            };

            var validatedResult1 = new AddProductColorCommandValidator().Validate(command1);
            var validatedResult2 = new AddProductColorCommandValidator().Validate(command2);

            validatedResult1.IsValid.Should().BeFalse();
            validatedResult2.IsValid.Should().BeFalse();
            validatedResult1.Errors.First().Equals(errorMessage);
            validatedResult2.Errors.First().Equals(errorMessage);
        }

        [Fact]
        public void AddProductColorCommand_ShouldBeTrue()
        {
            var command = new AddProductColorCommand
            {
                ProductId = 1,
                Color = "test"
            };

            var validatedResult = new AddProductColorCommandValidator().Validate(command);

            validatedResult.IsValid.Should().BeTrue();
        }
    }
}
