namespace Hotel.src.Utilities.UserInputManagement
{
    public class MonthConverter
    {
        public static int StringOrIntToMonth(string input)
        {
            int _output = 0;
            if (int.TryParse(input, out int month))
            {
                if (month < 1 || month > 12)
                {
                    Console.WriteLine("Invalid month. Please enter a month between 1 and 12.");
                }
                else
                {
                    _output = month;
                }
            }
            else
            {
                _output = ConvertStringToMonth(input);
            }

            return _output;
        }

        public static string ConvertMonthToString(int month)
        {
            switch (month)
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    return "Invalid month";
            }
        }

        public static int ConvertStringToMonth(string month)
        {
            switch (month.ToLower())
            {
                case "january" or "januari":
                    return 1;
                case "february" or "februari":
                    return 2;
                case "march" or "mars":
                    return 3;
                case "april":
                    return 4;
                case "may" or "maj":
                    return 5;
                case "june" or "juni":
                    return 6;
                case "july" or "juli":
                    return 7;
                case "august" or "augusti":
                    return 8;
                case "september":
                    return 9;
                case "october" or "oktober":
                    return 10;
                case "november":
                    return 11;
                case "december":
                    return 12;
                default:
                    return 0;
            }
        }
    }
}
