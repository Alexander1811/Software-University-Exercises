namespace FootballManager.Services
{
    using AutoMapper;
    using FootballManager.Common;
    using FootballManager.Contracts;
    using FootballManager.Data.Common;
    using FootballManager.Data.Models;
    using FootballManager.ViewModels.Users;
    using System;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly IRepository repository;
        private readonly IHashingService hashingService;
        private readonly IValidationService validationService;

        private readonly IMapper mapper;

        public UserService(
            IRepository repository,
            IValidationService validationService,
            IMappingService mappingService,
            IHashingService hashingService)
        {
            this.repository = repository;
            this.validationService = validationService;
            this.hashingService = hashingService;

            this.mapper = mappingService.CreateMapper();
        }

        public bool ValidateModel(RegisterViewModel model)
        {
            return this.validationService.ValidateModel(model);
        }

        public void RegisterUser(RegisterViewModel model)
        {
            var userExists = this.repository.All<User>()
                .FirstOrDefault(u => u.Username == model.Username) != null;

            if (userExists)
            {
                throw new Exception(ErrorMessages.UnexpectedError);
            }

            var user = this.mapper.Map<User>(model);
            user.Password = this.hashingService.HashString(model.Password);

            this.repository.Add(user);
            this.repository.SaveChanges();
        }

        public (string userId, bool isCorrect) IsLoginCorrect(LoginViewModel model)
        {
            bool isCorrect = false;
            string userId = string.Empty;

            var user = this.repository.All<User>()
                .FirstOrDefault(u => u.Username == model.Username);

            if (user != null)
            {
                isCorrect = user.Password == this.hashingService.HashString(model.Password);
            }

            if (isCorrect)
            {
                userId = user.Id;
            }

            return (userId, isCorrect);
        }
    }
}

