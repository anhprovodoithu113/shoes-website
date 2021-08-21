using System;
using System.Linq.Expressions;
using Shoes_Website.Domain.Models.ShoesWebsite;

namespace Shoes_Website.Application.Products.GetColorsByProduct
{
    public class ProductColorResponse
    {
        public int Id { get; set; }

        public string Color { get; set; }

        public static Expression<Func<ProductColor, ProductColorResponse>> SelectExpr()
        {
            return item => new ProductColorResponse
            {
                Id = item.Id,
                Color = item.Color
            };
        }
    }
}
