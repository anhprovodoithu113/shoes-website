using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Shoes_Website.Domain.Intefaces;

namespace Shoes_Website.Application.Products.GetProductStatusesByColor
{
    public class GetProductStatusesByColorHandler : IRequestHandler<GetProductStatusesByColorQuery, List<ProductStatusResponse>>
    {
        private readonly IRepository _repository;
        private readonly ILogger<GetProductStatusesByColorHandler> _logger;

        public GetProductStatusesByColorHandler(IRepository repository,
            ILogger<GetProductStatusesByColorHandler> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<List<ProductStatusResponse>> Handle(GetProductStatusesByColorQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Begin process for getting Product status of colorId: {request.ProductColorId}");

            var filter = new GetProductStatusByColorSpecification(request.ProductColorId);
            var lstproductStatus = (await _repository.ListSelectAsync(filter, ProductStatusResponse.SelectExpr()))
                                                        .OrderBy(m => m.Size)
                                                        .ToList();

            _logger.LogInformation($"Finish process for getting Product status of colorId: {request.ProductColorId}");

            return lstproductStatus;
        }
    }
}
