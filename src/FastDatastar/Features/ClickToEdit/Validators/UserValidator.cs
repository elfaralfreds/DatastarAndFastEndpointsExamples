using System.Data;
using FastDatastar.Features.ClickToEdit.Dto;
using FastEndpoints;
using FluentValidation;

namespace FastDatastar.Features.ClickToEdit.Validators;

public class UserValidator : Validator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.Firstname)
            .NotEmpty()
            .WithMessage("Firstname is required!")
            .MinimumLength(2)
            .WithMessage("Firstname must be at least 2 characters long!")
            .MaximumLength(50)
            .WithMessage("Firstname must be at most 50 characters long!");

        RuleFor(u => u.Lastname)
            .NotEmpty()
            .WithMessage("Lastname is required!")
            .MinimumLength(2)
            .WithMessage("Lastname must be at least 2 characters long!")
            .MaximumLength(50)
            .WithMessage("Lastname must be at most 50 characters long!");

        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("Email is required!")
            .EmailAddress()
            .WithMessage("Email is not valid!");
    }
}