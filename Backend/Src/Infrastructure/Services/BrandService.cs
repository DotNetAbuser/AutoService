namespace Infrastructure.Services;

public class BrandService(
    IBrandRepository _brandRepository)
    : IBrandService
{
    public async Task<Result<IEnumerable<BrandResponse>>> GetAllAsync()
    {
        var brandsEntities = await _brandRepository.GetAllAsync();
        var brandsResponse = brandsEntities
            .Select(brandEntity => new BrandResponse(
                Id: brandEntity.Id,
                Name: brandEntity.Name)).ToList();
        return Result<IEnumerable<BrandResponse>>.Success(brandsResponse, "Бренды автомобилей успешно получены");
    }

    public async Task<Result<BrandResponse>> GetByIdAsync(int brandId)
    {
        var brandEntity = await _brandRepository.GetByIdAsync(brandId);
        if (brandEntity == null)
            return Result<BrandResponse>.Fail("Бренд с данным идентификатором не найден!");

        var brandResponse = new BrandResponse(
            Id: brandEntity.Id,
            Name: brandEntity.Name);
        return Result<BrandResponse>.Success(brandResponse, "Бренд успешно получен.");
    }

    public async Task<Result> CreateAsync(CreateBrandRequest request)
    {
        var isExistByName = await _brandRepository
            .IsExistByNameAsync(request.Name);
        if (isExistByName)
            return Result<string>.Fail("Бренд с данным названием уже существует!");
        
        var brandEntity = new BrandEntity {
            Name = request.Name
        };
        await _brandRepository.CreateAsync(brandEntity);
        return Result<string>.Success("Бренд успешно создан!");
    }

    public async Task<Result> UpdateAsync(int brandId, UpdateBrandRequest request)
    {
        var isExistForUpdate = await _brandRepository
            .IsExistForUpdateByNameAsync(brandId, request.Name);
        if (isExistForUpdate)
            return Result<string>.Fail("Бренд с данныи название уже существует!");

        var brandEntity = await _brandRepository.GetByIdAsync(brandId);
        if (brandEntity == null)
            return Result<BrandResponse>.Fail("Бренд с данным идентификатором не найден!");
        brandEntity.Name = request.Name;
        await _brandRepository.UpdateAsync(brandEntity);
        return Result<string>.Success("Бренд успешно обновлён.");
    }

    public async Task<Result> DeleteAsync(int brandId)
    {
        var brandEntity = await _brandRepository.GetByIdAsync(brandId);
        if (brandEntity == null)
            return Result<BrandResponse>.Fail("Бренд с данным идентификатором не найден!");

        await _brandRepository.DeleteAsync(brandEntity);
        return Result<string>.Success("Бренд успешно удалён.");
    }
}