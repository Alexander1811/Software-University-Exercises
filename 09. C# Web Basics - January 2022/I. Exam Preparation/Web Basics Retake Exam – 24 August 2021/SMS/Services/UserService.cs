namespace SMS.Services
{
    using AutoMapper;
    using SMS.Common;
    using SMS.Contracts;
    using SMS.Data.Common;
    using SMS.Data.Models;
    using SMS.Models.Users;
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

        public (bool isValid, string errors) ValidateModel(RegisterViewModel model)
        {
            return this.validationService.ValidateModel(model);
        }

        public void RegisterUser(RegisterViewModel model)
        {
            var userExists = this.repository.All<User>()
                .FirstOrDefault(u => u.Username == model.Username) != null;

            if (userExists)
            {
                throw new ArgumentException(ErrorMessages.RegistrationFailed);
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

        public string GetUsername(string id) => this.repository.All<User>()
                .FirstOrDefault(u => u.Id == id).Username;
    }
}

