using System.Collections.Generic;

namespace Shoes_Website.Domain.Models.ShoesWebsite
{
    public class ProductColor : EntityBase
    {
        public string Color { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public IList<ProductStatus> ProductStatuses { get; set; }
    }
}
