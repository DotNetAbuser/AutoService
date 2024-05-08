namespace Application.IServices;

public interface ITokenService
{
    Task<Result<TokenResponse>> SignInAsync(SignInRequest request);
    Task<Result<TokenResponse>> RefreshTokenAsync(RefreshTokenRequest request);
}