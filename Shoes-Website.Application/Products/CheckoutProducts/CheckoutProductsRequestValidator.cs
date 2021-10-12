using FluentValidation;
using Shoes_Website.Application.Products.Common;

namespace Shoes_Website.Application.Products.CheckoutProducts
{
    public class CheckoutProductsRequestValidator : AbstractValidator<CheckoutProductsRequest>
    {
        public CheckoutProductsRequestValidator()
        {
            var errorMessage = string.Format(ProductConstant.INVALID_PRODUCT_COMMAND, "Checkout product");

            RuleFor(r => r.OrderedAmount)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .WithMessage(errorMessage);

            RuleFor(r => r.ProductStatusId)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .WithMessage(errorMessage);

            RuleFor(r => r.TotalPrice)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .WithMessage(errorMessage);
        }
    }
}
