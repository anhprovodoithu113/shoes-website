namespace Shoes_Website.Domain.Models.ShoesWebsite
{
    public class CustomerReviews : EntityBase
    {
        public string ReviewText { get; set; }

        public int Star { get; set; }

        public string CreatedByEmail { get; set; }

        public string CreatedByName { get; set; }

        public string NationalReviewer { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
