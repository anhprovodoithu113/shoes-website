using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using Shoes_Website.Domain.Models.ShoesWebsite;

namespace Shoes_Website.Application.Products.GetProductDetailsById
{
    public class ProductDetailsResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float DefaultPrice { get; set; }

        public string Original { get; set; }

        public float Star { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public List<CustomerReviewsResponse> CustomerReviews { get; set; }

        public static Expression<Func<Product, ProductDetailsResponse>> SelectExpr()
        {
            return item => new ProductDetailsResponse
            {
                Id = item.Id,
                Name = item.Name,
                DefaultPrice = item.DefaultPrice,
                Original = item.Original,
                Star = item.Star,
                Description = item.Description,
                ImagePath = item.ImagePath
            };
        }
    }

    public class CustomerReviewsResponse
    {
        public int Id { get; set; }

        public string ReviewText { get; set; }

        public int Star { get; set; }

        public string NationalReviewer { get; set; }

        public string ReviewerName { get; set; }

        public DateTime CreatedDate { get; set; }

        public static Expression<Func<CustomerReviews, CustomerReviewsResponse>> SelectExpr()
        {
            return item => new CustomerReviewsResponse
            {
                Id = item.Id,
                Star = item.Star,
                ReviewText = item.ReviewText,
                CreatedDate = item.CreatedDate,
                ReviewerName = item.CreatedByName,
                NationalReviewer = item.NationalReviewer
            };
        }
    }
}
