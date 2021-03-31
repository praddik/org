using NodaTime;

namespace Core.Interfaces
{
    public interface IEntity
    {
        Instant CreatedAt { get; set; }
        Instant UpdatedAt { get; set; }
    }
}
