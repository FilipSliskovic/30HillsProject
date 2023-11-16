using _30HillsProject.Application.UseCases.DTO;
using _30HillsProject.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Implementation.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterUserValidator(_30HillsProjectDbContext context)
        {
            RuleFor(x => x.UserName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(3).WithMessage("Username needs to cointain at least 3 characters.")
                .Must(x => !context.Users.Any(u => u.UserName == x)).WithMessage("Username: {PropertyValue} already exists");

            var imePrezimeRegex = @"^[A-Z][a-z]{2,}(\s[A-Z][a-z]{2,})?$";
            RuleFor(x => x.FirstName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required")
                .Matches(imePrezimeRegex).WithMessage("That name is in the wrong format - {PropertyValue}");

            RuleFor(x => x.LastName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Last name is required")
                .Matches(imePrezimeRegex).WithMessage("That last name is in the wrong format - {PropertyValue}");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
                .WithMessage("Password needs to contain at least 8 characters, 1 capital letter,1 non-capital letter, a number and a special character.");
        }
    }
}
