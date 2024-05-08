namespace Domain.Entities;

public class StatusEntity 
    : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<RequestEntity> Requests { get; set; } = [];
}