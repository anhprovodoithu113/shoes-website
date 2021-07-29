using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Shoes_Website_Project.Configuration.Exceptions
{
    public class ValidationProblemDetails : ProblemDetails
    {
        public ValidationProblemDetails(ValidationException exception)
        {
            Title = "Validation failed";
            Status = StatusCodes.Status400BadRequest;
            Detail = exception.Message;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
        }
    }
}
