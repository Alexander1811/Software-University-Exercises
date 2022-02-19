namespace SharedTrip.Common
{
    public static class ErrorMessages
    {
        public const string UnexpectedError = "Unexpected error!";

        public const string RegistrationInvalid = "Registration failed!";
        public const string LoginInvalid = "Login failed!";

        public const string UserInvalidUsername = $"Username must be between 5 and 20 characters!";
        public const string UserInvalidEmail = "Email is required!";
        public const string UserInvalidPassword = "Password must be between 6 and 20 characters!";
        public const string UserInvalidConfirmPassword = "Passwords do not match!";

        public const string TripInvalidStartPoint = "Startpoint is required!";
        public const string TripInvalidEndPoint = "Endpoint is required!";
        public const string TripInvalidDepartureTime = "Departure time is not valid!";
        public const string TripInvalidSeats = "Seats must be between 2 and 6!";
        public const string TripInvalidDescription = "Description is required and must be less than 80 characters!";

        public const string TripMissingDepartureTime = "Departure time is required!";
        public const string TripMissingSeats = "Seats are required!";
        public const string UserTripPairInvalid = "User or trip not found!";
        public const string TripNoFreeSeats = "All seats are taken!";
    }
}
