namespace Domain.Entities;

public class ServiceTypeEntity : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public virtual ICollection<RequestEntity> Requests { get; set; } = [];
}