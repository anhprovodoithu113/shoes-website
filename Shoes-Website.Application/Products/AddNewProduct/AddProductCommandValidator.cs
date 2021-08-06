using FluentValidation;
using Shoes_Website.Application.Products.Common;

namespace Shoes_Website.Application.Products.AddNewProduct
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(v => v)
                .Must(ValidateCommand)
                .WithMessage(string.Format(ProductConstant.INVALID_PRODUCT_COMMAND, "Add new product"));
        }

        private bool ValidateCommand(AddProductCommand command)
        {
            return !string.IsNullOrWhiteSpace(command.Name)
                && !string.IsNullOrWhiteSpace(command.Original)
                && command.DefaultPrice > 0f
                && command.ImageFile != null;
        }
    }
}
