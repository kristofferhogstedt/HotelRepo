namespace Hotel.src.Utilities.UserInputManagement.RegexManagement
{
    public class RegexSettings
    {
        public static string EmailPattern { get; } = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        public static string PhonePattern { get; } = @"^(\+46|0)[1-9]\d{6,16}$";
        public static string StreetAddressPattern { get; } = @"^[a-zA-ZåäöÅÄÖ0-9\s-]{2,50}$";
        public static string PostalCodePattern { get; } = @"^\d{3}\s?\d{2}$";
        public static string CityPattern { get; } = @"^[a-zA-ZåäöÅÄÖ\s-]{2,50}$";
        public static string CountryPattern { get; } = @"^[a-zA-ZåäöÅÄÖ\s-]{2,50}$";
        public static string PasswordPattern { get; } = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d\s:]).{8,}$";
    }
}
