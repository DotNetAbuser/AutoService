using Domain.Enums;

namespace Infrastructure.Services;

public class UserService(
    IUserRepository _userRepository,
    IRoleRepository _roleRepository)
    : IUserService
{
    public async Task<Result<PaginatedData<UserResponse>>> GetPaginatedUsersAsync(
        int pageNumber, int pageSize, string? searchTerms)
    {
        var (usersEntities, totalCount) = await _userRepository.GetPaginatedUsersAsync(
            pageNumber, pageSize, searchTerms);
        var usersResponse = usersEntities
            .Select(userEntity => new UserResponse(
                Id: userEntity.Id,
                LastName: userEntity.LastName,
                FirstName: userEntity.FirstName,
                Email: userEntity.Email,
                PhoneNumber: userEntity.PhoneNumber,
                IsBanned: userEntity.IsBanned)).ToList();
        return Result<PaginatedData<UserResponse>>.Success(new PaginatedData<UserResponse>(
            List: usersResponse, TotalCount: totalCount), "Список пользователей успешно получен.");
    }

    public async Task<Result<UserResponse>> GetByIdAsync(Guid userId)
    {
        var userEntity = await _userRepository.GetByIdAsync(userId);
        if (userEntity == null)
            return Result<UserResponse>.Fail("Пользователь с данным идентификатором не найден!");

        var userResponse = new UserResponse(
            Id: userEntity.Id,
            LastName: userEntity.LastName,
            FirstName: userEntity.FirstName,
            Email: userEntity.Email,
            PhoneNumber: userEntity.PhoneNumber,
            IsBanned: userEntity.IsBanned);
        return Result<UserResponse>.Success(userResponse, "Пользователь успешно получен.");
    }

    public async Task<Result> CreateAsync(SignUpRequest request)
    {
        var isExistByEmail = await _userRepository
            .IsExistByEmailAsync(request.Email);
        if (isExistByEmail)
            return Result<string>.Fail("Пользователь с данной почтой уже существует!");

        var isExistByPhoneNumber = await _userRepository
            .IsExistByPhoneNumberAsync(request.PhoneNumber);
        if (isExistByPhoneNumber)
            return Result<string>.Fail("Пользователь с данным номер уже существует!");
        var userEntity = new UserEntity {
            RoleId = (int)Role.Guest,
            LastName = request.LastName,
            FirstName = request.FirstName,
            Email = request.Email,
            Password = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password),
            PhoneNumber = request.PhoneNumber
        };
        await _userRepository.CreateAsync(userEntity);
        return Result<string>.Success("Пользователь успешно зарегестрирован");
    }
}