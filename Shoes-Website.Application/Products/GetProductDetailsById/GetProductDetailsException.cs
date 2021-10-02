using Shoes_Website.Domain;

namespace Shoes_Website.Application.Products.GetProductDetailsById
{
    public class GetProductDetailsException : BusinessValidationException
    {
        public GetProductDetailsException(string message) : base(message)
        {

        }
    }
}
