using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

        /// <summary>
        /// Checks if email matches regex pattern defined in RegexSettings class
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool CheckRegexEmail(string input)
        {
            var _pattern = RegexSettings.EmailPattern;
            return RegexHandler.CheckRegexMatch(input, _pattern);
        }

        /// <summary>
        /// Checks if phone number matches regex pattern defined in RegexSettings class
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool CheckRegexPhone(string input)
        {
            var _pattern = RegexSettings.PhonePattern;
            return RegexHandler.CheckRegexMatch(input, _pattern);
        }
    }
}
