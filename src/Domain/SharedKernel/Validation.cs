namespace SharedKernel
{
    public record Validation(bool Success, string[] InvalidReasons)
    {
        public static Validation Valid => new Validation(true, null);
        public static Validation Invalid(string[] invalidReasons) => new Validation(false, invalidReasons);
    }
}