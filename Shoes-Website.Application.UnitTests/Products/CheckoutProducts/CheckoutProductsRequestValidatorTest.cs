using Xunit;
using System.Linq;
using FluentAssertions;
using Shoes_Website.Application.Products.CheckoutProducts;
using Shoes_Website.Application.Products.Common;

namespace Shoes_Website.Application.UnitTests.Products.CheckoutProducts
{
    public class CheckoutProductsRequestValidatorTest
    {
        [Fact]
        public void CheckoutProducts_InvalidRequest_ShouldBeFalse()
        {
            var errorMessage = string.Format(ProductConstant.INVALID_PRODUCT_COMMAND, "Checkout product");

            var request1 = new CheckoutProductsRequest
            {
                OrderedAmount = 0,
                ProductStatusId = 1,
                TotalPrice = 5f
            };

            var request2 = new CheckoutProductsRequest
            {
                OrderedAmount = 1,
                ProductStatusId = 0,
                TotalPrice = 5f
            };

            var request3 = new CheckoutProductsRequest
            {
                OrderedAmount = 1,
                ProductStatusId = 1,
                TotalPrice = 0f
            };

            var validatedRequest1 = new CheckoutProductsRequestValidator().Validate(request1);
            var validatedRequest2 = new CheckoutProductsRequestValidator().Validate(request2);
            var validatedRequest3 = new CheckoutProductsRequestValidator().Validate(request3);

            validatedRequest1.IsValid.Should().BeFalse();
            validatedRequest2.IsValid.Should().BeFalse();
            validatedRequest3.IsValid.Should().BeFalse();
            validatedRequest1.Errors.First().Equals(errorMessage);
        }

        [Fact]
        public void CheckoutProducts_ValidRequest_ShouldBeTrue()
        {
            var request = new CheckoutProductsRequest
            {
                OrderedAmount = 1,
                ProductStatusId = 1,
                TotalPrice = 1f
            };

            var validatedRequest = new CheckoutProductsRequestValidator().Validate(request);
            validatedRequest.IsValid.Should().BeTrue();
        }
    }
}
