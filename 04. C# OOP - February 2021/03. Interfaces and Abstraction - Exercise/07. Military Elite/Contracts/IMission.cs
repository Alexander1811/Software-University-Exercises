using _07._Military_Elite.Enums;

namespace _07._Military_Elite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }

        MissionState MissionState { get; }

        void CompleteMission();
    }
}
