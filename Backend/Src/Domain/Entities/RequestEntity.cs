namespace Domain.Entities;

public class RequestEntity 
    : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    
    public int BrandId { get; set; }
    public int ModelId { get; set; }
    public int Year { get; set; }
    public int ServiceTypeId { get; set; }
    public int StatusId { get; set; }
    public DateTime Arrived { get; set; }

    public UserEntity User { get; set; } = null!;
    
    public BrandEntity Brand { get; set; } = null!;
    public ModelEntity Model { get; set; } = null!;
    public ServiceTypeEntity ServiceType { get; set; } = null!;
    public StatusEntity Status { get; set; } = null!;

}