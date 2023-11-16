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
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDTO>
    {
        private _30HillsProjectDbContext _context;

        public CreateCategoryValidator(_30HillsProjectDbContext context)
        {

            _context = context;

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name field can't be empty")
                .MinimumLength(3).WithMessage("Name field must have at least 3 characters")
                .Must(CatNotInUse).WithMessage("{PropertyValue} is alredy in use")
                ;
            RuleFor(x => x.Description)
                .Cascade(CascadeMode.Stop)
                .MinimumLength(5).WithMessage("Description field must have at least 5 characters")
                ;

        }

        private bool CatNotInUse(string name)
        {

            var exists = _context.Categories.Any(x => x.CategoryName == name);

            return !exists;
        }
    }
}
