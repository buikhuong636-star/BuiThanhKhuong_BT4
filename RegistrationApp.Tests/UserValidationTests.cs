using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RegistrationApp.Models;
using Xunit;

namespace RegistrationApp.Tests;

public class UserValidationTests
{
    private static IList<ValidationResult> ValidateModel(User user)
    {
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(user, null, null);
        Validator.TryValidateObject(user, validationContext, validationResults, true);
        return validationResults;
    }

    [Fact]
    public void ValidUser_ShouldPassValidation()
    {
        var user = new User
        {
            Username = "leminhnhat",
            Email = "leminh@example.com",
            Password = "Password123",
            ConfirmPassword = "Password123"
        };

        var validationResults = ValidateModel(user);

        Assert.Empty(validationResults);
    }

    [Fact]
    public void InvalidUser_ShouldReturnValidationErrors()
    {
        var user = new User
        {
            Username = "ab",
            Email = "invalid-email",
            Password = "123",
            ConfirmPassword = "321"
        };

        var validationResults = ValidateModel(user);

        Assert.Contains(validationResults, r => r.MemberNames.Contains("Username"));
        Assert.Contains(validationResults, r => r.MemberNames.Contains("Email"));
        Assert.Contains(validationResults, r => r.MemberNames.Contains("Password"));
        Assert.Contains(validationResults, r => r.MemberNames.Contains("ConfirmPassword"));
    }
}
