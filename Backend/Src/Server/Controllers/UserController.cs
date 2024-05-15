namespace Server.Controllers;

[ApiController]
[Route("api/identity/user")]
public class UserController(
    IUserService userService)
    : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Operator, Admin")]
    public async Task<IActionResult> GetPaginatedUsersAsync(
        int pageNumber, int pageSize, string? searchTerms)
    {
        var response = await userService.GetPaginatedUsersAsync(
            pageNumber, pageSize, searchTerms);
        return Ok(response);
    }

    [HttpGet("{userId:guid}")]
    [Authorize(Roles = "Operator, Admin")]
    public async Task<IActionResult> GetByIdAsync(Guid userId)
    {
        var response = await userService.GetByIdAsync(userId);
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> SignUpAsync(SignUpRequest request)
    {
        return Ok(await userService.CreateAsync(request));
    }

    // [HttpGet("{userId:guid}/role")]
    // [Authorize(Roles = "Admin")]
    // public async Task<IActionResult> GetRolesByIdAsync(Guid userId)
    // {
    //     var response = await _userService.GetRolesByIdAsync(userId);
    //     return Ok(response);
    // }
    //
    // [HttpPut("{userId}/role")]
    // [Authorize(Roles = "Admin")]
    // public async Task<IActionResult> UpdateRolesAsync(string userId, UpdateUserRolesRequest request)
    // {
    //     return Ok(await _userService.UpdateRolesAsync(userId, request));
    // }
    //
    // [HttpPut("{userId}/toggle-block")]
    // [Authorize(Roles = "Admin")]
    // public async Task<IActionResult> ToggleBlockAsync(string userId, ToggleUserStatusRequest request)
    // {
    //     return Ok(await _userService.ToggleStatusAsync(userId, request));
    // }
}