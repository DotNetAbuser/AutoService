namespace Domain.Entities;

public class BrandEntity : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<ModelEntity> Models { get; set; } = [];
    public virtual ICollection<RequestEntity> Requests { get; set; } = [];
}