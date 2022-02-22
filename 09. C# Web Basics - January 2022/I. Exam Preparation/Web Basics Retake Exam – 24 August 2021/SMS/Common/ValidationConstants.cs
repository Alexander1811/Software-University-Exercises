namespace SMS.Common
{
    public static class ValidationConstants
    {
        public const int GuidLength = 36;
        public const int UserUsernameMinLength = 5;
        public const int UserUsernameMaxLength = 20;
        public const int UserEmailMaxLength = 100;
        public const int UserPasswordMinLength = 6;
        public const int UserPasswordMaxLength = 20;
        public const int UserDatabasePasswordMaxLength = 64;

        public const int ProductNameMinLength = 4;
        public const int ProductNameMaxLength = 20;
        public const double ProductPriceMinValue = 0.05;
        public const double ProductPriceMaxValue = 1000;
    }
}
