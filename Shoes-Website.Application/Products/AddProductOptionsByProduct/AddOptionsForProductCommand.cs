using MediatR;

namespace Shoes_Website.Application.Products.AddProductOptionsByProduct
{
    public class AddOptionsForProductCommand : IRequest
    {
        public int ProductId { get; set; }

        public AddOptionsForProductCommand(int productId)
        {
            ProductId = productId;
        }
    }
}
