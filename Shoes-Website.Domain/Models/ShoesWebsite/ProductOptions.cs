namespace Shoes_Website.Domain.Models.ShoesWebsite
{
    public class ProductOptions : EntityBase
    {
        public string Size { get; set; }

        public string Color { get; set; }

        public int Amount { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public Invoice Invoice { get; set; }
    }
}
