using System.Linq;
using Ardalis.Specification;
using Shoes_Website.Domain.Models.ShoesWebsite;

namespace Shoes_Website.Application.Products.GetProductDetailsById
{
    public class GetCustomerReviewsByProductIdSpecification : Specification<CustomerReviews>
    {
        public GetCustomerReviewsByProductIdSpecification(int productId)
        {
            Query.Where(c => c.ProductId.Equals(productId));
        }
    }
}
