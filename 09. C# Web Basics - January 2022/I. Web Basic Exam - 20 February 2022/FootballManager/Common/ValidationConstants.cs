namespace FootballManager.Common
{
    public static class ValidationConstants
    {
        public const int GuidLength = 36;
        public const int UserUsernameMinLength = 5;
        public const int UserUsernameMaxLength = 20;
        public const int UserEmailMinLength = 10;
        public const int UserEmailMaxLength = 60;
        public const int UserPasswordMinLength = 5;
        public const int UserPasswordMaxLength = 20;

        public const int PlayerFullNameMinLength = 5;
        public const int PlayerFullNameMaxLength = 80;
        public const int PlayerPositionMinLength = 5;
        public const int PlayerPositionMaxLength = 20;
        public const int PlayerSpeedMinValue = 0;
        public const int PlayerSpeedMaxValue = 10;
        public const int PlayerEnduranceMinValue = 0;
        public const int PlayerEnduranceMaxValue = 10;
        public const int PlayerDescriptionMaxLength = 200;
    }
}
