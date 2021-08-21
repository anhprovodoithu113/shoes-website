using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Shoes_Website.Domain.Intefaces;

namespace Shoes_Website.Application.Products.GetColorsByProduct
{
    public class GetColorsByProductHandler : IRequestHandler<GetColorsByProductQuery, List<ProductColorResponse>>
    {
        private readonly IRepository _repository;
        private readonly ILogger<GetColorsByProductHandler> _logger;

        public GetColorsByProductHandler(IRepository repository,
            ILogger<GetColorsByProductHandler> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<List<ProductColorResponse>> Handle(GetColorsByProductQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin process for getting Product color");

            var filter = new GetColorsByProductIdSpecification(request.ProductId);
            var lstProdColor = (await _repository.ListSelectAsync(filter, ProductColorResponse.SelectExpr()))
                                                    .OrderBy(p => p.Color)
                                                    .ToList();

            _logger.LogInformation("Finish process for getting Product color");

            return lstProdColor;
        }
    }
}
