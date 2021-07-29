namespace Shoes_Website.Domain.Models.ShoesWebsiteUser
{
    public class Account : EntityBase
    {
        public string Email { get; set; }

        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
        public AccountDetail AccountDetail { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
