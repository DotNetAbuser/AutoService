namespace Server.Controllers;

[ApiController]
[Route("api/identity/token")]
public class TokenController(
    ITokenService _tokenService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SingInAsync(SignInRequest request)
    {
        var response = await _tokenService.SignInAsync(request);
        return Ok(response);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshTokenAsync(RefreshTokenRequest request)
    {
        var response = await _tokenService.RefreshTokenAsync(request);
        return Ok(response);
    }
}