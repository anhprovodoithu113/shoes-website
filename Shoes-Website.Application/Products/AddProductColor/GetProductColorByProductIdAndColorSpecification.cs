using System.Linq;
using Ardalis.Specification;
using Shoes_Website.Domain.Models.ShoesWebsite;

namespace Shoes_Website.Application.Products.AddProductColor
{
    public class GetProductColorByProductIdAndColorSpecification : Specification<ProductColor>
    {
        public GetProductColorByProductIdAndColorSpecification(int productId, string color)
        {
            Query.Where(p => p.ProductId.Equals(productId)
                          && p.Color.Equals(color));
        }
    }
}
