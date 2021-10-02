using System;
using System.Linq.Expressions;
using Shoes_Website.Domain.Models.ShoesWebsite;

namespace Shoes_Website.Application.Products.Common
{
    public class ProductResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float DefaultPrice { get; set; }

        public string Original { get; set; }

        public float Star { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public DateTime? CreatedAt { get; set; }

        public static Expression<Func<Product, ProductResponse>> SelectExpr()
        {
            return item => new ProductResponse
            {
                Id = item.Id,
                Star = item.Star,
                Name = item.Name,
                Original = item.Original,
                CreatedAt = item.CreatedAt,
                ImagePath = item.ImagePath,
                Description = item.Description,
                DefaultPrice = item.DefaultPrice,
            };
        }
    }
}
