using MediatR;

namespace Shoes_Website.Application.Products.AddProductStatus
{
    public class AddProductStatusCommand : IRequest
    {
        public int ProductColorId { get; set; }

        public int Size { get; set; }

        public int Amount { get; set; }
    }
}
