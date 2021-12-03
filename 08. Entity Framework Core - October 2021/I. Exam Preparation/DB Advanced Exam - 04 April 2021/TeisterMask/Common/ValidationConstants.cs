namespace TeisterMask.Common
{
    public static class ValidationConstants
    {
        public const int EmployeeUsernameMinLength = 3;
        public const int EmployeeUsernameMaxLength = 40;
        public const string EmployeeUsernameRegex = @"^[A-za-z0-9]+$";
        public const string EmployeePhoneRegex = @"^\d{3}-\d{3}-\d{4}$";

        public const int ProjectNameMinLength = 2;
        public const int ProjectNameMaxLength = 40;

        public const int TaskNameMinLength = 2;
        public const int TaskNameMaxLength = 40;
        public const int TaskExecutionTypeMinValue = 0;
        public const int TaskExecutionTypeMaxValue = 3;
        public const int TaskLabelTypeMinValue = 0;
        public const int TaskLabelTypeMaxValue = 4;
    }
}
