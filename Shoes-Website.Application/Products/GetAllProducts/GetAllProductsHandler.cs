using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Shoes_Website.Domain.Intefaces;
using Shoes_Website.Application.Products.Common;

namespace Shoes_Website.Application.Products.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductResponse>>
    {
        private readonly IRepository _repository;

        public GetAllProductsHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var filter = new GetAllProductsSpecification();
            var lstProduct = (await _repository.ListSelectAsync(filter, ProductResponse.SelectExpr()))
                                                .ToList();

            return lstProduct;
        }
    }
}
