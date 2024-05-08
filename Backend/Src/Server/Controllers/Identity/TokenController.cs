namespace Server.Controllers.Identity;

[ApiController]
[Route("api/identity/token")]
public class TokenController(
    )
    : ControllerBase
{
    public async Task<IActionResult> SingInAsync(SignInRequest request)
    {
        var response = "rest";
        return Ok(response);
    }
}