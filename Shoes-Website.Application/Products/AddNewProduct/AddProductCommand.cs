using MediatR;
using Microsoft.AspNetCore.Http;

namespace Shoes_Website.Application.Products.AddNewProduct
{
    public class AddProductCommand : IRequest
    {
        public string Name { get; set; }

        public float DefaultPrice { get; set; }

        public string Original { get; set; }

        public string Description { get; set; }

        public IFormFile ImageFile { get; set; }

        public bool IsMenShoes { get; set; }
    }
}
