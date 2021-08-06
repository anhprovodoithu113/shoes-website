namespace Shoes_Website_Project.Configuration.Exceptions
{
    //
    // Summary:
    //     A machine-readable format for specifying errors in HTTP API responses based on
    //     https://tools.ietf.org/html/rfc7807.
    public class ProblemFromSwaggerResponse
    {
        public string Detail { get; set; }

        public int? Status { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string TraceId { get; set; }

        public string RequestId { get; set; }

        public string CorrelationId { get; set; }
    }
}
