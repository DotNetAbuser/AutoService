namespace Server.Controllers;

[ApiController]
[Route("api/car/model")]
public class ModelController(
    IModelService _modelService)
    : ControllerBase
{
    [HttpGet("brand/{brandId:int}")]
    public async Task<IActionResult> GetAllModelsByBrandIdAsync(int brandId)
    {
        var response = await _modelService.GetAllByBrandIdAsync(brandId);
        return Ok(response);
    }
    
    [HttpGet("{modelId:int}")]
    public async Task<IActionResult> GetByIdAsync(int modelId)
    {
        var response = await _modelService.GetByIdAsync(modelId);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateModelRequest request)
    {
        return Ok(await _modelService.CreateAsync(request));
    }

    [HttpPut("{modelId:int}")]
    public async Task<IActionResult> UpdateAsync(int modelId, UpdateModelRequest request)
    {
        return Ok(await _modelService.UpdateAsync(modelId, request));
    }

    [HttpDelete("{modelId:int}")]
    public async Task<IActionResult> DeleteAsync(int modelId)
    {
        return Ok(await _modelService.DeleteAsync(modelId));
    }
}