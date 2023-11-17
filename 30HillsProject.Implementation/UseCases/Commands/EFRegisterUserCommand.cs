using _30HillsProject.Application.UseCases.Commands;
using _30HillsProject.Application.UseCases.DTO;
using _30HillsProject.DataAccess;
using _30HillsProject.Domain;
using _30HillsProject.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30HillsProject.Implementation.UseCases.Commands
{

    public class EFRegisterUserCommand : EFUseCase, IRegisterUserCommand
    {

        private readonly RegisterUserValidator validator;

        public EFRegisterUserCommand(_30HillsProjectDbContext context, RegisterUserValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 1;

        public string Name => "Register user";

        public void Execute(RegisterDTO request)
        {
            validator.ValidateAndThrow(request);

            var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            List<UserUseCase> RegisteredUserUseCases = new List<UserUseCase>();
            var user = new User
            {
                UserName = request.UserName,
                Password = hash,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            Context.Users.Add(user);
            user.UseCases = GetRegisteredUserUseCases(user.Id);
            Context.UserUseCases.AddRange(user.UseCases);
            Context.SaveChanges();
        }


        public List<UserUseCase> GetRegisteredUserUseCases(int id)
        {
            List<UserUseCase> RegisteredUserUseCases = new List<UserUseCase>();
            int[] UseCases = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12,13,14,15,16,17,18,19,20};

            foreach (int i in UseCases)
            {
                RegisteredUserUseCases.Add(new UserUseCase
                {
                    
                    UserId = id,
                    UseCaseId = i
                });
            }


            return RegisteredUserUseCases;
        }

    }
}
