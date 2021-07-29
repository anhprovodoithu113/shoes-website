using System;

namespace Shoes_Website.Domain.Models.ShoesWebsiteUser
{
    public class AccountDetail : EntityBase
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public bool Gender { get; set; }

        public string Phone { get; set; }

        public string Avatar { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? UpdatedBy { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}
