namespace Behlog.Core.Domain;

public abstract class BehlogDomainEvent : IBehlogEvent
{

    public BehlogDomainEvent()
    {
        EventId = Guid.NewGuid();
        EventPublishedAt = DateTime.UtcNow;
    }
    
    public DateTime EventPublishedAt { get; private set; }
    
    public Guid EventId { get; private set; }

    public int EventVersion { get; private set; } = 1;
}