using FluentValidation;
using Shoes_Website.Application.Products.Common;

namespace Shoes_Website.Application.Products.AddProductStatus
{
    public class AddProductStatusCommandValidator : AbstractValidator<AddProductStatusCommand>
    {
        public AddProductStatusCommandValidator()
        {
            RuleFor(v => v)
                .Must(ValidateCommand)
                .WithMessage(string.Format(ProductConstant.INVALID_PRODUCT_COMMAND, "Add product status"));
        }

        private bool ValidateCommand(AddProductStatusCommand command)
        {
            return command.ProductColorId > 0
                && command.Size > 0
                && command.Amount > 0;
        }
    }
}
