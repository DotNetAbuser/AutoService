namespace Server.Controllers;

[ApiController]
[Route("api/request")]
public class RequestController(
    IRequestService _requestService)
    : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Operator, Admin")]
    public async Task<IActionResult> GetPaginatedRequestsAsync(
        int pageNumber, int pageSize,
        string? searchTerms)
    {
        var response = await _requestService.GetPaginatedRequestsAsync(
            pageNumber, pageSize,
            searchTerms);
        return Ok(response);
    }
    
    [HttpGet("{userId:guid}/user")]
    [Authorize]
    public async Task<IActionResult> GetPaginatedRequestsByUserIdAsync(
        Guid userId,
        int pageNumber, int pageSize,
        string? searchTerms)
    {
        var response = await _requestService.GetPaginatedRequestsByUserIdAsync(
            userId,
            pageNumber, pageSize,
            searchTerms);
        return Ok(response);
    }

    [HttpGet("{requestId:guid}")]
    [Authorize]
    public async Task<IActionResult> GetByIdAsync(Guid requestId)
    {
        var response = await _requestService.GetByIdAsync(requestId);
        return Ok(response);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateAsync(CreateRequestRequest request)
    {
        return Ok(await _requestService.CreateAsync(request));
    }

    [HttpPut("{requestId:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid requestId, UpdateRequestRequest request)
    {
        return Ok(await _requestService.UpdateAsync(requestId, request));
    }

    [HttpDelete("{requestId:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid requestId)
    {
        return Ok(await _requestService.DeleteAsync(requestId));
    }

   
}