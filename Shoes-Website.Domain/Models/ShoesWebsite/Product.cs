using System;
using System.Collections.Generic;

namespace Shoes_Website.Domain.Models.ShoesWebsite
{
    public class Product : EntityBase
    {
        public string Name { get; set; }

        public float DefaultPrice { get; set; }

        public string Original { get; set; }

        public float Star { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public bool IsMenShoes { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public IList<ProductOptions> ProductOptions { get; set; }

        public IList<CustomerReviews> CustomerReviews { get; set; }
    }
}
