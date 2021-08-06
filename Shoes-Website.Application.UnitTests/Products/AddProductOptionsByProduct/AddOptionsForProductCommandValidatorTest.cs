using Xunit;
using System.Linq;
using FluentAssertions;
using Shoes_Website.Application.Products.AddProductOptionsByProduct;
using Shoes_Website.Application.Products.Common;

namespace Shoes_Website.Application.UnitTests.Products.AddProductOptionsByProduct
{
    public class AddOptionsForProductCommandValidatorTest
    {
        [Fact]
        public void AddOptionsForProductCommand_ShouldBeFalse()
        {
            var command = new AddOptionsForProductCommand(-1);

            var result = new AddOptionsForProductValidator().Validate(command);

            result.IsValid.Should().BeFalse();
            result.Errors.First().Equals(string.Format(ProductConstant.INVALID_PRODUCT_COMMAND, "Add options for product"));
        }

        [Fact]
        public void AddOptionsForProductCommand_ShouldBeTrue()
        {
            var command = new AddOptionsForProductCommand(1);

            var result = new AddOptionsForProductValidator().Validate(command);

            result.IsValid.Should().BeTrue();
        }
    }
}
