using MediatR;
using System.Collections.Generic;

namespace Shoes_Website.Application.Products.GetProductStatusesByColor
{
    public class GetProductStatusesByColorQuery : IRequest<List<ProductStatusResponse>>
    {
        public int ProductColorId { get; set; }
    }
}
