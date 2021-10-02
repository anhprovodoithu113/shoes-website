using Ardalis.Specification;
using Shoes_Website.Domain.Models.ShoesWebsite;

namespace Shoes_Website.Application.Products.AddProductStatus
{
    public class GetProductStatusBySizeAndProductColorIdSpecification : Specification<ProductStatus>
    {
        public GetProductStatusBySizeAndProductColorIdSpecification(int productColorId, int size)
        {
            Query.Where(p => p.ProductColorId.Equals(productColorId)
                          && p.Size.Equals(size));
        }
    }
}
