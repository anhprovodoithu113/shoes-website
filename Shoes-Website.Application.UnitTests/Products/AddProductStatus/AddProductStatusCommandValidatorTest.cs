using FluentAssertions;
using Shoes_Website.Application.Products.AddProductStatus;
using Shoes_Website.Application.Products.Common;
using System.Linq;
using Xunit;

namespace Shoes_Website.Application.UnitTests.Products.AddProductStatus
{
    public class AddProductStatusCommandValidatorTest
    {
        [Fact]
        public void AddProductStatusCommand_ShouldBeFalse()
        {
            var errorMessage = string.Format(ProductConstant.INVALID_PRODUCT_COMMAND, "Add product status");

            var command1 = new AddProductStatusCommand
            {
                ProductColorId = -1,
                Size = 1,
                Amount = 1
            };
            var command2 = new AddProductStatusCommand
            {
                ProductColorId = 1,
                Size = -1,
                Amount = 1
            };
            var command3 = new AddProductStatusCommand
            {
                ProductColorId = 1,
                Size = 1,
                Amount = -1
            };

            var validatedResult1 = new AddProductStatusCommandValidator().Validate(command1);
            var validatedResult2 = new AddProductStatusCommandValidator().Validate(command2);
            var validatedResult3 = new AddProductStatusCommandValidator().Validate(command3);

            validatedResult1.IsValid.Should().BeFalse();
            validatedResult2.IsValid.Should().BeFalse();
            validatedResult3.IsValid.Should().BeFalse();
            validatedResult1.Errors.First().Equals(errorMessage);
            validatedResult2.Errors.First().Equals(errorMessage);
            validatedResult3.Errors.First().Equals(errorMessage);
        }
    }
}
