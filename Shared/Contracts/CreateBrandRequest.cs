namespace Shared.Contracts;

public class CreateBrandRequest
{
    [Required] public string Name { get; set; } = string.Empty;
}