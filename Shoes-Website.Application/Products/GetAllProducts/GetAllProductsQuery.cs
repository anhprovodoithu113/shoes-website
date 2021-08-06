using MediatR;
using System.Collections.Generic;
using Shoes_Website.Application.Products.Common;

namespace Shoes_Website.Application.Products.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<ProductResponse>>
    {
    }
}
