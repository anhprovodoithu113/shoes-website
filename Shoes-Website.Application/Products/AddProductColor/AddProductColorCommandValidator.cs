using FluentValidation;
using Shoes_Website.Application.Products.Common;

namespace Shoes_Website.Application.Products.AddProductColor
{
    public class AddProductColorCommandValidator : AbstractValidator<AddProductColorCommand>
    {
        public AddProductColorCommandValidator()
        {
            RuleFor(v => v)
                .Must(ValidateCommand)
                .WithMessage(string.Format(ProductConstant.INVALID_PRODUCT_COMMAND, "Add product color"));
        }

        private bool ValidateCommand(AddProductColorCommand command)
        {
            return command.ProductId > 0
                && !string.IsNullOrWhiteSpace(command.Color);
        }
    }
}
