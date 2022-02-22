namespace FootballManager.Contracts
{
    using FootballManager.ViewModels.Players;

    public interface IPlayerService
    {
        IEnumerable<PlayerListViewModel> All();

        IEnumerable<PlayerListViewModel> Collection(string id);

        bool ValidateModel(PlayerAddViewModel model);

        void Add(PlayerAddViewModel model);

        void AddToCollection(int playerId, string userId);

        void RemoveFromCollection(int playerId, string userId);
    }
}
