using MediatR;
using System.Collections.Generic;

namespace Shoes_Website.Application.Products.GetColorsByProduct
{
    public class GetColorsByProductQuery : IRequest<List<ProductColorResponse>>
    {
        public int ProductId { get; set; }
    }
}
