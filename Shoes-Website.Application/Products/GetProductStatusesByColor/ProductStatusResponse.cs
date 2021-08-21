using System;
using System.Linq.Expressions;
using Shoes_Website.Domain.Models.ShoesWebsite;

namespace Shoes_Website.Application.Products.GetProductStatusesByColor
{
    public class ProductStatusResponse
    {
        public int Id { get; set; }

        public int Size { get; set; }

        public int Amount { get; set; }

        public static Expression<Func<ProductStatus, ProductStatusResponse>> SelectExpr()
        {
            return item => new ProductStatusResponse
            {
                Id = item.Id,
                Size = item.Size,
                Amount = item.Amount
            };
        }
    }
}
