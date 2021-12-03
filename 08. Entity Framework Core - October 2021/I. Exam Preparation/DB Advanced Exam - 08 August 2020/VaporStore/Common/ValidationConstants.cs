namespace VaporStore.Common
{
    public static class ValidationConstants
    {
        public const int GameMinPriceValue = 0;
        public const int GameTagsMinCount = 1;

        public const int UserUsernameMinLength = 3;
        public const int UserUsernameMaxLength = 20;
        public const string UserFullNameRegex = @"^[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+$";
        public const int UserAgeMinValue = 3;
        public const int UserAgeMaxValue = 103;
        public const int UserCardsMinCount = 1;

        public const string CardNumberRegex = @"^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$";
        public const int CardCvcMaxLength = 3;
        public const string CardCvcRegex = @"^[0-9]{3}$";
        public const string CardTypeMinValue = "Debit";
        public const string CardTypeMaxValue = "Credit";

        public const string PurchaseProductKeyRegex = @"^[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}$";
        public const string PurchaseTypeMinValue = "Retail";
        public const string PurchaseTypeMaxValue = "Digital";
    }
}
