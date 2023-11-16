using _30HillsProject.Application.Exceptions;
using _30HillsProject.Application.UseCases.Commands;
using _30HillsProject.Application.UseCases.DTO;
using _30HillsProject.DataAccess;
using _30HillsProject.Domain;
using _30HillsProject.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Implementation.UseCases.Commands
{
    public class EFCreateCategoryCommand : EFUseCase,ICreateCategoryCommand
    {

        private readonly CreateCategoryValidator _createCategoryValidator;

        public EFCreateCategoryCommand(_30HillsProjectDbContext context, CreateCategoryValidator createCategoryValidator) : base(context)
        {
            _createCategoryValidator = createCategoryValidator;
        }

        public int Id => 12;

        public string Name => "Create category";

        public void Execute(CreateCategoryDTO request)
        {
            _createCategoryValidator.ValidateAndThrow(request);

            

            if (request.ParentId != null)
            {
                var Parent = Context.Categories.Find(request.ParentId);
                if (Parent == null) 
                {
                    throw new EntityNotFoundException("Parent", (int)request.ParentId);
                }
            }


            var cat = new Category
            {
                CategoryName = request.Name,
                Description = request.Description,
                ParentId = request.ParentId,
            };

            Context.Categories.Add(cat);
            Context.SaveChanges();



        }
    }
}
