namespace Shared.Contracts;

public class CreateRequestRequest
{
    public Guid UserId { get; set; }
    [Range(1, int.MaxValue,ErrorMessage = "Необходимо выбрать марку авто!")] public int BrandId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Необходимо выбрать модель авто")] public int ModelId { get; set; }
    [Range(1990, int.MaxValue, ErrorMessage = "Необходимо выбрать год выпуска авто!")] public int Year { get; set; } = 1990;
    [Range(1, int.MaxValue, ErrorMessage = "Необходимо выбрать тип услуги!")] public int ServiceTypeId { get; set; } 
    public DateTime Arrived { get; set; } = DateTime.Now;
}