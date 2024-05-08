namespace Shared.Contracts;

public class UpdateRequestRequest
{
    public int BrandId { get; set; }
    public int ModelId { get; set; }
    public int Year { get; set; }
    public int ServiceTypeId { get; set; }
    public DateTime Arrived { get; set; }
}