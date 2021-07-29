using System;

namespace Shoes_Website.Domain
{
    public class PermissionAccessException : Exception
    {
        protected PermissionAccessException(string message) : base(message) { }
    }
}
