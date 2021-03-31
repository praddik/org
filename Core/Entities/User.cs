using Core.Interfaces;
using NodaTime;

namespace Core.Entities
{
    public class User : IEntity
    {
        public long Id { get; set; }
        public AccessLevel Access { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public Instant CreatedAt { get; set; }
        public Instant UpdatedAt { get; set; }
    }

    public enum AccessLevel : byte
    {
        Admin,
        User
    }
}
