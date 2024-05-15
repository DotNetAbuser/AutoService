namespace Shared.Contracts;

public class SignUpRequest
{
    [Required(ErrorMessage = "Поле фамилия пользователя не может быть пустым")] public string LastName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Поле имя пользователя не может быть пустым")] public string FirstName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Поле эл. почта не может быть пустым")] 
    [EmailAddress(ErrorMessage = "Введеные данные не соответствуют маске 'mail@example.com'")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Поле пароль не может быть пустым")]
    [MinLength(5, ErrorMessage = "Поле пароль должен содержать минимум 5 символов")]
    public string Password { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Поле пароль не может быть пустым")]
    [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")] 
    public string ConfirmPassword { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Поле номер телефона не может быть пустым")] 
    [Phone(ErrorMessage = "Введенные данные не соответвуют маске '+7999999999'")] 
    public string PhoneNumber { get; set; } = string.Empty;
}