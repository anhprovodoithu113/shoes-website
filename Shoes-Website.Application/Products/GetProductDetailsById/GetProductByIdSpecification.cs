using System.Linq;
using Ardalis.Specification;
using Shoes_Website.Domain.Models.ShoesWebsite;

namespace Shoes_Website.Application.Products.GetProductDetailsById
{
    public class GetProductByIdSpecification : Specification<Product>
    {
        public GetProductByIdSpecification(int productId)
        {
            Query.Where(p => p.Id == productId)
                .Include(p => p.ProductColors)
                .ThenInclude(pc => pc.ProductStatuses);
        }
    }
}
