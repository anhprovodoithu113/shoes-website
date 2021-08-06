using System.Linq;
using Ardalis.Specification;
using Shoes_Website.Domain.Models.ShoesWebsite;

namespace Shoes_Website.Application.Products.GetAllProducts
{
    public class GetProductOptionsByProductIdSpecification : Specification<ProductOptions>
    {
        public GetProductOptionsByProductIdSpecification(long productId)
        {
            Query.Where(p => p.ProductId.Equals(productId));
        }
    }
}
