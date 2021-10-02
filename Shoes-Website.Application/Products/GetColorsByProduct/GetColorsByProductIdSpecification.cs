using System.Linq;
using Ardalis.Specification;
using Shoes_Website.Domain.Models.ShoesWebsite;

namespace Shoes_Website.Application.Products.GetColorsByProduct
{
    public class GetColorsByProductIdSpecification : Specification<ProductColor>
    {
        public GetColorsByProductIdSpecification(int productId)
        {
            Query.Where(p => p.ProductId.Equals(productId))
                .Include(p => p.ProductStatuses);
        }
    }
}
