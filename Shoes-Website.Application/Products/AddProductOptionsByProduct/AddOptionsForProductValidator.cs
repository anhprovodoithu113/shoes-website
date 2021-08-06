using FluentValidation;
using Shoes_Website.Application.Products.Common;

namespace Shoes_Website.Application.Products.AddProductOptionsByProduct
{
    public class AddOptionsForProductValidator : AbstractValidator<AddOptionsForProductCommand>
    {
        public AddOptionsForProductValidator()
        {
            RuleFor(v => v.ProductId)
                .Must(ValidateCommand)
                .WithMessage(string.Format(ProductConstant.INVALID_PRODUCT_COMMAND, "Add options for product"));
        }

        private bool ValidateCommand(int productId)
        {
            return productId >= 0;
        }
    }
}
