﻿namespace Shared.Contracts;

public class SignUpRequest
{
    [Required] public string LastName { get; set; } = string.Empty;
    [Required] public string FirstName { get; set; } = string.Empty;
    [Required] [EmailAddress] public string Email { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;
    [Required] [Compare(nameof(Password))] public string ConfirmPassword { get; set; } = string.Empty;
    [Required] [Phone] public string PhoneNumber { get; set; } = string.Empty;
}