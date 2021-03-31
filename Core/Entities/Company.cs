using Core.Interfaces;
using NodaTime;

namespace Core.Entities
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Instant CreatedAt { get; set; }
        public Instant UpdatedAt { get; set; }
    }
}
