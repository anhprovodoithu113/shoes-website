using System.Collections.Generic;

namespace Shoes_Website.Domain.Models.ShoesWebsite
{
    public class ProductStatus : EntityBase
    {
        public int Size { get; set; }

        public int Amount { get; set; }

        public int ProductColorId { get; set; }

        public ProductColor ProductColor { get; set; }

        public IList<Invoice> Invoice { get; set; }
    }
}
