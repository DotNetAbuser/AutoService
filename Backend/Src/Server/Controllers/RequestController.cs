namespace Server.Controllers;

[ApiController]
[Route("api/request")]
public class RequestController(
    IRequestService requestService)
    : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Operator, Admin")]
    public async Task<IActionResult> GetPaginatedRequestsAsync(
        int pageNumber, int pageSize,
        string? searchTerms)
    {
        var response = await requestService.GetPaginatedRequestsAsync(
            pageNumber, pageSize,
            searchTerms);
        return Ok(response);
    }
    
    [HttpGet("user/{userId:guid}")]
    [Authorize]
    public async Task<IActionResult> GetPaginatedRequestsByUserIdAsync(
        Guid userId,
        int pageNumber, int pageSize,
        string? searchTerms)
    {
        var response = await requestService.GetPaginatedRequestsByUserIdAsync(
            userId,
            pageNumber, pageSize,
            searchTerms);
        return Ok(response);
    }

    [HttpGet("{requestId:guid}")]
    [Authorize]
    public async Task<IActionResult> GetByIdAsync(Guid requestId)
    {
        var response = await requestService.GetByIdAsync(requestId);
        return Ok(response);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateAsync(CreateRequestRequest request)
    {
        return Ok(await requestService.CreateAsync(request));
    }

    [HttpPut("{requestId:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid requestId, UpdateRequestRequest request)
    {
        return Ok(await requestService.UpdateAsync(requestId, request));
    }

    [HttpDelete("{requestId:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid requestId)
    {
        return Ok(await requestService.DeleteAsync(requestId));
    }

    [HttpPut("{requestId:guid}/change-status")]
    public async Task<IActionResult> ChangeStatusAsync(Guid requestId, ChangeStatusRequest request)
    {
        return Ok(await requestService.ChangeStatusAsync(requestId, request));
    }

   
}