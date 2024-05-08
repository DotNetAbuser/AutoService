namespace Shared.Contracts;

public class UpdateModelRequest
{
    public string Name { get; set; } = string.Empty;
    public int BrandId { get; set; }
}