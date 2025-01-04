using System.Text.RegularExpressions;

namespace Hotel.src.Utilities.UserInputManagement.RegexManagement
{
    public class RegexHandler
    {

        /// <summary>
        /// Checks if string matches regex pattern defined in RegexSettings class
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool CheckRegexMatch(string input, string pattern)
        {
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
    }
}
