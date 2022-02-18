namespace SharedTrip.Common
{
    public static class ValidationConstants
    {
        public const int UserUsernameMinLength = 5;
        public const int UserUsernameMaxLength = 20;
        public const int UserEmailMaxLength = 100;
        public const int UserPasswordMinLength = 6;
        public const int UserPasswordMaxLength = 20;
        public const int UserDatabasePasswordMaxLength = 64;

        public const int TripStartPointMaxLength = 100;
        public const int TripEndPointMaxLength = 100;
        public const int TripSeatsMinCount = 2;
        public const int TripSeatsMaxCount = 6;
        public const int TripDescriptionMaxLength = 80;
        public const int TripImagePathMaxLength = 300;
    }
}
