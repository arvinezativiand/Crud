﻿using System.ComponentModel.DataAnnotations;

namespace Crud.Web.Models.SignIn;

public class RegisterViewModel
{
    [Required]
    public string FullName { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    [Required, MinLength(6), DataType(DataType.Password)]
    public string Password { get; set; }
    [Required, Compare("Password"), DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}
