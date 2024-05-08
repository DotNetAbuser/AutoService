namespace Domain.Entities;

public class RoleEntity 
    : BaseEntity<int>
{
    public string Name { get; set; }

    public virtual ICollection<UserEntity> Users { get; set; } = [];
}