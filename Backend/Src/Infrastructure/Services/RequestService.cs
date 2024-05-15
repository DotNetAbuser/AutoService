namespace Infrastructure.Services;

public class RequestService(
    IRequestRepository _requestRepository)
    : IRequestService
{
    public async Task<Result<PaginatedData<RequestResponse>>> GetPaginatedRequestsAsync(
        int pageNumber, int pageSize, string? searchTerms)
    {
        var (requestsEntities, totalCount) = await _requestRepository.GetPaginatedRequestsAsync(
            pageNumber, pageSize, searchTerms);
        var requestsResponse = requestsEntities
            .Select(requestEntity => new RequestResponse(
                Id: requestEntity.Id,
                LastName: requestEntity.User.LastName,
                FirstName: requestEntity.User.FirstName,
                Email: requestEntity.User.Email,
                PhoneNumber: requestEntity.User.PhoneNumber,
                BrandName: requestEntity.Brand.Name,
                ModelName: requestEntity.Model.Name,
                Year: requestEntity.Year,
                ServiceTypeName: requestEntity.ServiceType.Name,
                Price: requestEntity.ServiceType.Price,
                StatusName: requestEntity.Status.Name,
                Arrived: requestEntity.Arrived,
                Created: requestEntity.Created)).ToList();
        return Result<PaginatedData<RequestResponse>>.Success(new PaginatedData<RequestResponse>(
            List: requestsResponse, TotalCount: totalCount), "Список заявок успешно получен!");
    }

    public async Task<Result<PaginatedData<RequestResponse>>> GetPaginatedRequestsByUserIdAsync(
        Guid userId, int pageNumber, int pageSize, string? searchTerms)
    {
        var (requestsEntities, totalCount) = await _requestRepository.GetPaginatedRequestsByUserIdAsync(
            userId, pageNumber, pageSize, searchTerms);
        var requestsResponse = requestsEntities
            .Select(requestEntity => new RequestResponse(
                Id: requestEntity.Id,
                LastName: requestEntity.User.LastName,
                FirstName: requestEntity.User.FirstName,
                Email: requestEntity.User.Email,
                PhoneNumber: requestEntity.User.PhoneNumber,
                BrandName: requestEntity.Brand.Name,
                ModelName: requestEntity.Model.Name,
                Year: requestEntity.Year,
                ServiceTypeName: requestEntity.ServiceType.Name,
                Price: requestEntity.ServiceType.Price,
                StatusName: requestEntity.Status.Name,
                Arrived: requestEntity.Arrived,
                Created: requestEntity.Created)).ToList();
        return Result<PaginatedData<RequestResponse>>.Success(new PaginatedData<RequestResponse>(
            List: requestsResponse, TotalCount: totalCount), "Список заявок успешно получен!");
    }

    public async Task<Result<RequestResponse>> GetByIdAsync(Guid requestId)
    {
        var requestEntity = await _requestRepository.GetByIdAsync(requestId);
        if (requestEntity == null)
            return Result<RequestResponse>.Fail("Заявка с данным идентификатором не найдена!");

        var requestResponse = new RequestResponse(
            Id: requestEntity.Id,
            LastName: requestEntity.User.LastName,
            FirstName: requestEntity.User.FirstName,
            Email: requestEntity.User.Email,
            PhoneNumber: requestEntity.User.PhoneNumber,
            BrandName: requestEntity.Brand.Name,
            ModelName: requestEntity.Model.Name,
            Year: requestEntity.Year,
            ServiceTypeName: requestEntity.ServiceType.Name,
            Price: requestEntity.ServiceType.Price,
            StatusName: requestEntity.Status.Name,
            Arrived: requestEntity.Arrived,
            Created: requestEntity.Created);
        return Result<RequestResponse>.Success(requestResponse, "Заявка успешно получена.");
    }

    public async Task<Result> CreateAsync(CreateRequestRequest request)
    {
        var requestEntity = new RequestEntity {
            UserId = request.UserId,
            BrandId = request.BrandId,
            ModelId = request.ModelId,
            Year = request.Year,
            ServiceTypeId = request.ServiceTypeId,
            StatusId = 1,
            Arrived = request.Arrived
        };
        await _requestRepository.CreateAsync(requestEntity);
        return Result<string>.Success("Заявка успешно создана!");
    }

    public async Task<Result> UpdateAsync(Guid requestId, UpdateRequestRequest request)
    {
        var requestEntity = await _requestRepository.GetByIdAsync(requestId);
        if (requestEntity == null)
            return Result<string>.Fail("Заявка с данным идентификатором не существует!");

        requestEntity.BrandId = request.BrandId;
        requestEntity.ModelId = request.ModelId;
        requestEntity.Year = request.Year;
        requestEntity.ServiceTypeId = request.ServiceTypeId;
        requestEntity.Arrived = request.Arrived;
        await _requestRepository.UpdateAsync(requestEntity);
        return Result<string>.Success("Заявка успешно обновлена.");
    }

    public async Task<Result> DeleteAsync(Guid requestId)
    {
        var requestEntity = await _requestRepository.GetByIdAsync(requestId);
        if (requestEntity == null)
            return Result<string>.Fail("Заявка с данным идентификатором не существует!");

        await _requestRepository.DeleteAsync(requestEntity);
        return Result<string>.Success("Заявка успешно удалена.");
    }

    public async Task<Result> ChangeStatusAsync(Guid requestId, ChangeStatusRequest request)
    {
        var requestEntity = await _requestRepository.GetByIdAsync(requestId);
        if (requestEntity == null)
            return Result<string>.Fail("Заявка с данным идентификатором не существует!");

        requestEntity.StatusId = request.StatusId;
        await _requestRepository.UpdateAsync(requestEntity);
        return Result<string>.Success("Заявка успешно обновлена.");
    }
}