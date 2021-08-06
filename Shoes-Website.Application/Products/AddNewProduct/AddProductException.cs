using Shoes_Website.Domain;

namespace Shoes_Website.Application.Products.AddNewProduct
{
    public class AddProductException : BusinessValidationException
    {
        public AddProductException(string message) : base(message)
        {

        }
    }
}
