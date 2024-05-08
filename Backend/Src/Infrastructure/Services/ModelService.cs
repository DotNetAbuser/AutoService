namespace Infrastructure.Services;

public class ModelService(
    IModelRepository _modelRepository)
    : IModelService
{
    public async Task<Result<IEnumerable<ModelResponse>>> GetAllByBrandIdAsync(int brandId)
    {
        var modelsEntities = await _modelRepository
            .GetAllByBrandIdAsync(brandId);
        var modelsResponse = modelsEntities
            .Select(modelEntity => new ModelResponse(
                Id: modelEntity.Id,
                Name: modelEntity.Name)).ToList();
        return Result<IEnumerable<ModelResponse>>.Success(modelsResponse, "Модели авто успешно получены по идентификатору бренда.");
    }

    public async Task<Result<ModelResponse>> GetByIdAsync(int modelId)
    {
        var modelEntity = await _modelRepository.GetByIdAsync(modelId);
        if (modelEntity == null)
            return Result<ModelResponse>.Fail("Модель с данным идентификатором не найдена!");

        var modelResponse = new ModelResponse(
            Id: modelEntity.Id,
            Name: modelEntity.Name);
        return Result<ModelResponse>.Success(modelResponse, "Модель успешно получена.");
    }

    public async Task<Result> CreateAsync(CreateModelRequest request)
    {
        var isExistByName = await _modelRepository
            .IsExistByNameAsync(request.Name);
        if (isExistByName)
            return Result<string>.Fail("Модель с данным названием уже существует!");

        var modelEntity = new ModelEntity {
            Name = request.Name
        };
        await _modelRepository.CreateAsync(modelEntity);
        return Result<string>.Success("Модель успешно создана.");
    }

    public async Task<Result> UpdateAsync(int modelId, UpdateModelRequest request)
    {
        var isExistForUpdateByName = await _modelRepository
            .IsExistForUpdateByNameAsync(modelId, request.Name);
        if (isExistForUpdateByName)
            return Result<string>.Fail("Модель с данным название уже существует!");

        var modelEntity = await _modelRepository.GetByIdAsync(modelId);
        if (modelEntity == null)
            return Result<string>.Fail("Модель с данным идентификатором не найдена!");
        modelEntity.Name = request.Name;
        modelEntity.BrandId = request.BrandId;
        await _modelRepository.UpdateAsync(modelEntity);
        return Result<string>.Success("Модель успешно обновлена.");
    }

    public async Task<Result> DeleteAsync(int modelId)
    {
        var modelEntity = await _modelRepository.GetByIdAsync(modelId);
        if (modelEntity == null)
            return Result<string>.Fail("Модель с данным идентификатором не найдена!");

        await _modelRepository.DeleteAsync(modelEntity);
        return Result<string>.Success("Модель успешно удалена.");
    }
}