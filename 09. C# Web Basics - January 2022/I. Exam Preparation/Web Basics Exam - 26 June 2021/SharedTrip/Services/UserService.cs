namespace SharedTrip.Services
{
    using AutoMapper;
    using SharedTrip.Common;
    using SharedTrip.Contracts;
    using SharedTrip.Data.Common;
    using SharedTrip.Data.Models;
    using SharedTrip.Models;
    using SharedTrip.Models.Users;
    using System;
    using System.Collections.Generic;
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

        public (bool isValid, List<ErrorViewModel> errors) ValidateModel(RegisterViewModel model)
        {
            var (isValid, errors) = this.validationService.ValidateModel(model);

            if (model.Password != model.ConfirmPassword)
            {
                isValid = false;
                errors.Add(new ErrorViewModel(ErrorMessages.UserInvalidConfirmPassword));
            }

            return (isValid, errors);
        }

        public void RegisterUser(RegisterViewModel model)
        {
            var userExists = this.repository.All<User>()
            .FirstOrDefault(u => u.Username == model.Username) != null;

            if (userExists)
            {
                throw new ArgumentException(ErrorMessages.RegistrationInvalid);
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

