using MediatR;

namespace Shoes_Website.Application.Products.CheckoutProducts
{
    public class CheckoutProductsRequest : IRequest
    {
        public int ProductStatusId { get; set; }

        public int OrderedAmount { get; set; }

        public float TotalPrice { get; set; }
    }
}
