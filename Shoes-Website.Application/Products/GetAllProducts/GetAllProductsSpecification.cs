using Ardalis.Specification;
using Shoes_Website.Domain.Models.ShoesWebsite;

namespace Shoes_Website.Application.Products.GetAllProducts
{
    public class GetAllProductsSpecification : Specification<Product>
    {
        public GetAllProductsSpecification()
        {
            Query.Include(p => p.ProductOptions);
        }
    }
}
