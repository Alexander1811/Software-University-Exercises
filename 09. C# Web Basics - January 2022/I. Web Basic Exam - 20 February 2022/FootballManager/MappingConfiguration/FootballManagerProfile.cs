namespace FootballManager.MappingConfiguration
{
    using AutoMapper;
    using FootballManager.Data.Models;
    using FootballManager.ViewModels.Players;
    using FootballManager.ViewModels.Users;

    public class FootballManagerProfile : Profile
    {
        public FootballManagerProfile()
        {
            //Users
            CreateMap<RegisterViewModel, User>()
                .ForMember(x => x.Password, y => y.Ignore());

            //Players
            CreateMap<PlayerAddViewModel, Player>();
            CreateMap<Player, PlayerListViewModel>()
                .ForMember(x => x.Speed, y => y.MapFrom(s => s.Speed.ToString()))
                .ForMember(x => x.Endurance, y => y.MapFrom(s => s.Endurance.ToString()));
        }
    }
}
