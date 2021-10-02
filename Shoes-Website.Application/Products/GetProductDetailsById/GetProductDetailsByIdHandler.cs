using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shoes_Website.Domain.Intefaces;

namespace Shoes_Website.Application.Products.GetProductDetailsById
{
    public class GetProductDetailsByIdHandler : IRequestHandler<GetProductDetailsByIdQuery, ProductDetailsResponse>
    {
        private readonly IRepository _repository;

        private readonly ILogger<GetProductDetailsByIdHandler> _logger;

        public GetProductDetailsByIdHandler(IRepository repository,
            ILogger<GetProductDetailsByIdHandler> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<ProductDetailsResponse> Handle(GetProductDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Begin process for getting product by Id: {request.ProductId}");
            var getProductByIdSpec = new GetProductByIdSpecification(request.ProductId);
            var product = await _repository.FirstOrDefaultSelectAsync(getProductByIdSpec, ProductDetailsResponse.SelectExpr());

            if(product == null)
            {
                var message = $"Can not find any product of productId: {request.ProductId}";
                _logger.LogError(message);
                throw new GetProductDetailsException(message);
            }

            var getCustomerReviewsByProductIdSpec = new GetCustomerReviewsByProductIdSpecification(product.Id);
            var customerReviews = (await _repository.ListSelectAsync(getCustomerReviewsByProductIdSpec, CustomerReviewsResponse.SelectExpr()))
                                                    .ToList();

            product.CustomerReviews = customerReviews;

            return product;
        }
    }
}
