namespace Domain.Entities.Base;

public class BaseEntity<TID>
{
    public TID Id { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Updated { get; set; }
}