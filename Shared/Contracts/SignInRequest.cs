namespace Shared.Contracts;

public class SignInRequest
{
    [Required(ErrorMessage = "Поле эл. почта не может быть пустым")] [EmailAddress(ErrorMessage = "Введеные данные не соответствуют маске 'mail@example.com'")] public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Поле пароль не может быть пустым")] [MinLength(5, ErrorMessage = "Поле пароль должен содержать минимум 5 символов")] public string Password { get; set; } = string.Empty;
}