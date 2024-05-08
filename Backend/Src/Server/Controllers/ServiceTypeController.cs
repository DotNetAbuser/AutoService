namespace Server.Controllers;

[ApiController]
[Route("api/car/service_type")]
public class ServiceTypeController(
    IServiceTypeService _serviceTypeService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await _serviceTypeService.GetAllAsync();
        return Ok(response);
    }

    [HttpGet("{serviceTypeId:int}")]
    public async Task<IActionResult> GetByIdAsync(int serviceTypeId)
    {
        var response = await _serviceTypeService.GetByIdAsync(serviceTypeId);
        return Ok(response);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync(CreateServiceTypeRequest request)
    {
        return Ok(await _serviceTypeService.CreateAsync(request));
    }

    [HttpPut("{serviceTypeId:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(int serviceTypeId, UpdateServiceTypeRequest request)
    {
        return Ok(await _serviceTypeService.UpdateAsync(serviceTypeId, request));
    }

    [HttpDelete("{serviceTypeId:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(int serviceTypeId)
    {
        return Ok(await _serviceTypeService.DeleteAsync(serviceTypeId));
    }
}