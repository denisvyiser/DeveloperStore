namespace DevStore.Core.Models.Validations
{
    public static class ValidationMessages
    {
        public static string NotNullMessage { get; set; } = "The {PropertyName} is required.";

        public static string GreaterThanMessage { get; set; } = "The {PropertyName} property value must be greater than Current Value {PropertyValue}.";

        public static string MaxLenthMessage { get; set; } = "The {PropertyName} value can´t be greater than {MaxLength} characters long.";

        public static string MinLenthMessage { get; set; } = "The {PropertyName} value can´t be less than {MinLength} characters long.";

    }
}
