namespace Infrastructure.Services;

public class ServiceTypeService(
    IServiceTypeRepository _serviceTypeRepository)
    : IServiceTypeService
{
    public async Task<Result<IEnumerable<ServiceTypeResponse>>> GetAllAsync()
    {
        var serviceTypesEntities = await _serviceTypeRepository.GetAllAsync();
        var serviceTypesResponse = serviceTypesEntities
            .Select(serviceTypeEntity => new ServiceTypeResponse(
                Id: serviceTypeEntity.Id,
                Name: serviceTypeEntity.Name,
                Description: serviceTypeEntity.Description,
                Price: serviceTypeEntity.Price)).ToList();
        return Result<IEnumerable<ServiceTypeResponse>>.Success(serviceTypesResponse, "Виды услуг успешно получены.");
    }

    public async Task<Result<ServiceTypeResponse>> GetByIdAsync(int serviceTypeId)
    {
        var serviceTypeEntity = await _serviceTypeRepository.GetByIdAsync(serviceTypeId);
        if (serviceTypeEntity == null)
            return Result<ServiceTypeResponse>.Fail("Услуга с данным идентификатором не существует!");

        var serviceTypeResponse = new ServiceTypeResponse(
            Id: serviceTypeEntity.Id,
            Name: serviceTypeEntity.Name,
            Description: serviceTypeEntity.Description,
            Price: serviceTypeEntity.Price);
        return Result<ServiceTypeResponse>.Success(serviceTypeResponse, "Вид услуги успешно получен.");
    }

    public async Task<Result> CreateAsync(CreateServiceTypeRequest request)
    {
        var isExistByName = await _serviceTypeRepository
            .IsExistByNameAsync(request.Name);
        if (isExistByName)
            return Result<string>.Fail("Вид услуги с данным названием уже существует!");

        var isExistByDescription = await _serviceTypeRepository
            .IsExistByDescriptionAsync(request.Description);
        if (isExistByDescription)
            return Result<string>.Fail("Вид услуги с данным описанием уже существует!");

        var serviceTypeEntity = new ServiceTypeEntity {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        };
        await _serviceTypeRepository.CreateAsync(serviceTypeEntity);
        return Result<string>.Success("Вид услуги успешно создан.");
    }

    public async Task<Result> UpdateAsync(int serviceTypeId, UpdateServiceTypeRequest request)
    {
        var isExistForUpdateByName = await _serviceTypeRepository
            .IsExistForUpdateByNameAsync(serviceTypeId, request.Name);
        if (isExistForUpdateByName)
            return Result<string>.Fail("Вид услуги с данным названием уже существует!");

        var isExistForUpdateByDescription = await _serviceTypeRepository
            .IsExistForUpdateByDescriptionAsync(serviceTypeId, request.Description);
        if (isExistForUpdateByDescription)
            return Result<string>.Fail("Вид услуги с данным описанием уже существует!");

        var serviceTypeEntity = await _serviceTypeRepository.GetByIdAsync(serviceTypeId);
        if (serviceTypeEntity == null)
            return Result<string>.Fail("Вид услуги с данныи идентификатором не найден!");
        serviceTypeEntity.Name = request.Name;
        serviceTypeEntity.Description = request.Description;
        serviceTypeEntity.Price = request.Price;
        await _serviceTypeRepository.UpdateAsync(serviceTypeEntity);
        return Result<string>.Success("Вид услуги успешно обновлён.");
    }

    public async Task<Result> DeleteAsync(int serviceTypeId)
    {
        var serviceTypeEntity = await _serviceTypeRepository.GetByIdAsync(serviceTypeId);
        if (serviceTypeEntity == null)
            return Result<string>.Fail("Вид услуги с данныи идентификатором не найден!");

        await _serviceTypeRepository.DeleteAsync(serviceTypeEntity);
        return Result<string>.Success("Вид услуги успешно удалён.");
    }
}