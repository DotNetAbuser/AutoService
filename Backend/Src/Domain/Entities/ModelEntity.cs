namespace Domain.Entities;

public class ModelEntity : BaseEntity<int>
{
    public int BrandId { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public BrandEntity Brand { get; set; } = null!;
    public virtual ICollection<RequestEntity> Requests { get; set; } = [];
}