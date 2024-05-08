namespace Server.Controllers;

[ApiController]
[Route("api/car/brand")]
public class BrandController(
    IBrandService _brandService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await _brandService.GetAllAsync();
        return Ok(response);
    }

    [HttpGet("{brandId:int}")]
    public async Task<IActionResult> GetByIdAsync(int brandId)
    {
        var response = await _brandService.GetByIdAsync(brandId);
        return Ok(response);
    }

    [HttpPost]
    [Authorize(Roles = "Operator, Admin")]
    public async Task<IActionResult> CreateAsync(CreateBrandRequest request)
    {
        return Ok(await _brandService.CreateAsync(request));
    }

    [HttpPut("{brandId:int}")]
    [Authorize(Roles = "Operator, Admin")]
    public async Task<IActionResult> UpdateAsync(int brandId, UpdateBrandRequest request)
    {
        return Ok(await _brandService.UpdateAsync(brandId, request));
    }

    [HttpDelete("{brandId:int}")]
    [Authorize(Roles = "Operator, Admin")]
    public async Task<IActionResult> DeleteAsync(int brandId)
    {
        return Ok(await _brandService.DeleteAsync(brandId));
    }
}