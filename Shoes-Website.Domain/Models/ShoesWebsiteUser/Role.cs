using System.Collections.Generic;

namespace Shoes_Website.Domain.Models.ShoesWebsiteUser
{
    public class Role : EntityBase
    {
        public string Name { get; set; }

        public IList<Account> Accounts { get; set; }
    }
}
