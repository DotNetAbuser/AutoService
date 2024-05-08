namespace Domain.Entities;

public class UserEntity
    : BaseEntity<Guid>
{
    public int RoleId { get; set; }

    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public bool IsBanned { get; set; }

    public RoleEntity Role { get; set; } = null!;
    public virtual ICollection<SessionEntity> Sessions { get; set; } = [];
    public virtual ICollection<RequestEntity> Requests { get; set; } = [];

}