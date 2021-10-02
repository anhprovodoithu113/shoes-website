using MediatR;

namespace Shoes_Website.Application.Products.AddProductColor
{
    public class AddProductColorCommand : IRequest
    {
        public int ProductId { get; set; }

        public string Color { get; set; }
    }
}
