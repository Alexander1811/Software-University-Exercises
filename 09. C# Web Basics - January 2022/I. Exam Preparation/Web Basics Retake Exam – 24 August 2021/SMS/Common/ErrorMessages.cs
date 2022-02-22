namespace SMS.Common
{
    public static class ErrorMessages
    {
        public const string UnexpectedError = "Unexpected error!";

        public const string RegistrationFailed = "Registration failed!";
        public const string LoginFailed = "Login failed!";

        public const string UserRequiredUsername = "Username is required!";
        public const string UserRequiredEmail = "Email is required!";
        public const string UserRequiredPassword = "Password is required!";
        public const string UserRequiredConfirmPassword = "Confirm Password is required!";   
        
        public const string UserInvalidUsername = "Username must be between 5 and 20 characters!";
        public const string UserInvalidEmail = "Email is not valid!";
        public const string UserInvalidPassword = "Password must be between 6 and 20 characters!";
        public const string UserInvalidConfirmPassword = "Passwords do not match!";

        public const string ProductRequiredName = "Name is required!";
        public const string ProductRequiredPrice = "Price is required!";

        public const string ProductInvalidName = "Product must be between 4 and 20 characters!";
        public const string ProductInvalidPrice = "Price must be between 0.5 and 1000!";

        //public const string TripMissingDepartureTime = "Departure time is required!";
        //public const string TripMissingSeats = "Seats are required!";
        //public const string UserTripPairInvalid = "User or trip not found!";
        //public const string TripNoFreeSeats = "All seats are taken!";
        //public const string TripAlreadyJoined = "You have already joined this trip!";
    }
}
