namespace FootballManager.Services
{
    using AutoMapper;
    using FootballManager.Common;
    using FootballManager.Contracts;
    using FootballManager.Data.Common;
    using FootballManager.Data.Models;
    using FootballManager.ViewModels.Players;

    public class PlayerService : IPlayerService
    {
        private readonly IRepository repository;
        private readonly IValidationService validationService;

        private readonly IMapper mapper;

        public PlayerService(
            IRepository repository,
            IValidationService validationService,
            IMappingService mappingService)
        {
            this.repository = repository;
            this.validationService = validationService;

            this.mapper = mappingService.CreateMapper();
        }

        public IEnumerable<PlayerListViewModel> All()
        {
            var players = this.repository.All<Player>();

            var models = this.mapper
                .ProjectTo<PlayerListViewModel>(players)
                .ToList();

            return models;
        }

        public IEnumerable<PlayerListViewModel> Collection(string userId)
        {
            var myPlayers = this.repository.All<UserPlayer>()
                .Where(up => up.UserId == userId)
                .Select(up => up.Player);

            var models = this.mapper
                .ProjectTo<PlayerListViewModel>(myPlayers)
                .ToList();

            return models;
        }

        public bool ValidateModel(PlayerAddViewModel model)
        {
            var isValid = this.validationService.ValidateModel(model);

            return isValid;
        }

        public void Add(PlayerAddViewModel model)
        {
            var player = this.mapper.Map<Player>(model);

            this.repository.Add(player);
            this.repository.SaveChanges();
        }

        public void AddToCollection(int playerId, string userId)
        {
            var user = this.repository.All<User>()
                   .FirstOrDefault(u => u.Id == userId);
            var player = this.repository.All<Player>()
                .FirstOrDefault(p => p.Id == playerId);

            if (user == null || player == null)
            {
                throw new ArgumentException(ErrorMessages.UnexpectedError);
            }

            if (this.repository.All<UserPlayer>().Any(up => up.UserId == userId && up.PlayerId == playerId))
            {
                throw new ArgumentException(ErrorMessages.UnexpectedError);
            }

            this.repository.Add<UserPlayer>(new UserPlayer
            {
                PlayerId = playerId,
                UserId = userId
            });

            this.repository.SaveChanges();
        }

        public void RemoveFromCollection(int playerId, string userId)
        {
            var userWithPlayer = this.repository.All<UserPlayer>()
                .FirstOrDefault(up => up.UserId == userId && up.PlayerId == playerId);

            if (userWithPlayer == null)
            {
                throw new Exception(ErrorMessages.UnexpectedError);
            }

            this.repository.Remove(userWithPlayer);

            this.repository.SaveChanges();
        }
    }
}
