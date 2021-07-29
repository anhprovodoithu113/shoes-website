using System;

namespace Shoes_Website.Domain
{
    public class BusinessValidationException : Exception
    {
        public BusinessValidationException(string message) : base(message)
        {

        }
    }
}
