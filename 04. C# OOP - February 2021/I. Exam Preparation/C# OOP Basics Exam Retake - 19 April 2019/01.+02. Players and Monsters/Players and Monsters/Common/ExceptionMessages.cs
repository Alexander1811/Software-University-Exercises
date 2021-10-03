namespace Players_and_Monsters.Common
{
    public static class ExceptionMessages
    {
        public const string InvalidPlayerName = "Player's username cannot be null or an empty string.";
        public const string InvalidCardName = "Card's name cannot be null or an empty string.";

        public const string InalidPlayerHealth = "Player's health bonus cannot be less than zero.";
        public const string InvalidCardHealthPoints = "Card's HP cannot be less than zero.";

        public const string InvalidDamagePoints = "Damage points cannot be less than zero.";
        public const string InvalidCardDamagePoints = "Card's damage points cannot be less than zero.";

        public const string PlayerIsNull = "Player cannot be null!"; 
        public const string CardIsNull = "Card cannot be null!";

        public const string PlayerIsDead = "Player is dead!";
    }
}
