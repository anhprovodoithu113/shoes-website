using Shoes_Website.Domain;

namespace Shoes_Website.Application.Products.AddProductColor
{
    public class AddProductColorException : BusinessValidationException
    {
        public AddProductColorException(string message) : base(message)
        {

        }
    }
}
