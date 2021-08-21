using System.Linq;
using Ardalis.Specification;
using Shoes_Website.Domain.Models.ShoesWebsite;

namespace Shoes_Website.Application.Products.GetProductStatusesByColor
{
    public class GetProductStatusByColorSpecification : Specification<ProductStatus>
    {
        public GetProductStatusByColorSpecification(int productColorId)
        {
            Query.Where(p => p.ProductColorId.Equals(productColorId));
        }
    }
}
