namespace Theatre.Common
{
    public static class ValidationConstants
    {
        public const int TheatreNameMinLength = 4;
        public const int TheatreNameMaxLength = 30;
        public const sbyte TheatreNameMinHallsCount = 1;
        public const sbyte TheatreNameMaxHallsCount = 10;
        public const int TheatreDirectorNameMinLength = 4;
        public const int TheatreDirectorNameMaxLength = 30;

        public const int PlayTitleMinLength = 4;
        public const int PlayTitleMaxLength = 50;
        public const float PlayRatingMinValue = 0;
        public const float PlayRatingMaxValue = 10;
        public const int PlayDescriptionMaxLength = 700;
        public const string PlayGenreMinValue = "Drama";
        public const string PlayGenreMaxValue = "Musical";
        public const int PlayScreenwriterNameMinLength = 4;
        public const int PlayScreenwriterNameMaxLength = 30;

        public const int CastFullNameMinLength = 4;
        public const int CastFullNameMaxLength = 30;
        public const int CastPhoneNumberMaxLength = 15;
        public const string CastPhoneNumberRegex = @"^\+44-\d{2}-\d{3}-\d{4}$";


        public const float TicketPriceMinValue = 1;
        public const float TicketPriceMaxValue = 100;
        public const sbyte TicketRowMinCount = 1;
        public const sbyte TicketRowMaxCount = 10;
    }
}
