namespace Infrastructure.Services;

public class TokenService(
    IConfiguration _configuration,
    IUserRepository _userRepository,
    ISessionRepository _sessionRepository)
    : ITokenService
{
    public async Task<Result<TokenResponse>> SignInAsync(SignInRequest request)
    {
        var userEntity = await _userRepository.GetByEmailWithRoleAsync(request.Email);
        if (userEntity == null)
            return Result<TokenResponse>.Fail("Пользователь с данной почтой не найден!");

        var isPasswordVerify = BCrypt.Net.BCrypt.EnhancedVerify(request.Password, userEntity.Password);
        if (!isPasswordVerify)
            return Result<TokenResponse>.Fail("Непривильный пароль!");

        if (userEntity.IsBanned)
            return Result<TokenResponse>.Fail("Пользователь находится в чёрном списке!");
        
        var authToken = GenerateJwtToken(userEntity);
        var refreshToken = GenerateRefreshToken();
        
        var sessionEntity = new SessionEntity {
            UserId = userEntity.Id,
            Token = refreshToken,
            Expires = DateTime.UtcNow.AddDays(7),
        };
        await _sessionRepository.CreateAsync(sessionEntity);
        var response = new TokenResponse(
            AuthToken: authToken,
            RefreshToken: refreshToken);
        return Result<TokenResponse>
            .Success(response, "Пользователь успешно авторизирован.");
    }

    public async Task<Result<TokenResponse>> RefreshTokenAsync(RefreshTokenRequest request)
    {
        var refreshSessionEntity = await _sessionRepository
            .GetByRefreshTokenAsync(request.RefreshToken);
        if (refreshSessionEntity == null)
            return Result<TokenResponse>.Fail("Сессии не существует, необходимо пройти аунтификацию!");
        
        if (refreshSessionEntity.Expires < DateTime.UtcNow)
            return Result<TokenResponse>.Fail("Сессия устарела, необходимо вновь пройти аунтификацию!");
        
        var userEntity = await _userRepository.GetByIdWithRoleAsync(refreshSessionEntity.UserId);
        if (userEntity == null)
            return Result<TokenResponse>.Fail("Пользователя не найден!");
        
        await _sessionRepository.DeleteAsync(refreshSessionEntity);
        var newAuthToken = GenerateJwtToken(userEntity);
        var newRefreshToken = GenerateRefreshToken();
        var newRefreshSessionEntity = new SessionEntity {
            UserId = userEntity.Id,
            Token = newRefreshToken,
            Expires = DateTime.UtcNow.AddDays(7),
        };
        await _sessionRepository.CreateAsync(newRefreshSessionEntity);
        var tokenResponse = new TokenResponse(
            AuthToken: newAuthToken,
            RefreshToken: newRefreshToken);
        return Result<TokenResponse>
            .Success(tokenResponse, "Новая пара токенов успешно получены.");
    }
    
    
    private string GenerateJwtToken(UserEntity user) =>
        GenerateEncryptedToken(GetSigningCredentials(), GetClaims(user));

    private IEnumerable<Claim> GetClaims(UserEntity user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Name, user.FirstName),
            new(ClaimTypes.Surname, user.LastName),
            new(ClaimTypes.Role, user.Role.Name)
        };

        return claims;
    }

    private string GenerateEncryptedToken(SigningCredentials signingCredentials, IEnumerable<Claim> claims)
    {
        var expiresStr = _configuration.GetSection("JwtOptions:Expires").Value 
                         ?? throw new ArgumentException("Expires minutes is missing");
        var expiresMinutes = Convert.ToInt32(expiresStr);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiresMinutes),
            signingCredentials: signingCredentials);
        var tokenHandler = new JwtSecurityTokenHandler();
        var encryptedToken = tokenHandler.WriteToken(token);

        return encryptedToken;
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private SigningCredentials GetSigningCredentials()
    {
        var secretKey = _configuration.GetSection("JwtOptions:SecretKey").Value 
                        ?? throw new ArgumentException("Secret key is missing");
        var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        return new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);
    }
}