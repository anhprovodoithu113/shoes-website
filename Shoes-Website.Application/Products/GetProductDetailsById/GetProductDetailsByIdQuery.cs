using MediatR;

namespace Shoes_Website.Application.Products.GetProductDetailsById
{
    public class GetProductDetailsByIdQuery : IRequest<ProductDetailsResponse>
    {
        public int ProductId { get; set; }
    }
}
