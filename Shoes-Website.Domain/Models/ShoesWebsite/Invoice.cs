using System;

namespace Shoes_Website.Domain.Models.ShoesWebsite
{
    public class Invoice : EntityBase
    {
        public float Price { get; set; }

        public string DeliveryAddress { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public string InvoiceCode { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public int ProductStatusId { get; set; }

        public ProductStatus ProductStatus { get; set; }
    }
}
