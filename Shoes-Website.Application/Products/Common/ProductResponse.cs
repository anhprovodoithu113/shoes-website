using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

        public byte[] ImageData { get; set; }

        public DateTime? CreatedAt { get; set; }

        public List<ProductOptionsResponse> ProductOptionsResponses { get; set; }

        public static Expression<Func<Product, ProductResponse>> SelectExpr()
        {
            return item => new ProductResponse
            {
                Id = item.Id,
                Star = item.Star,
                Name = item.Name,
                Original = item.Original,
                CreatedAt = item.CreatedAt,
                ImageData = item.ImageData,
                Description = item.Description,
                DefaultPrice = item.DefaultPrice,
            };
        }
    }

    public class ProductOptionsResponse
    {
        public int Id { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public int Amount { get; set; }

        public static Expression<Func<ProductOptions, ProductOptionsResponse>> SelectExpr()
        {
            return item => new ProductOptionsResponse
            {
                Id = item.Id,
                Size = item.Size,
                Color = item.Color,
                Amount = item.Amount
            };
        }
    }
}
