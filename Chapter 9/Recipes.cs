using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Chapter9
{
    public class Recipes
    {
        #region Recipe 1 - Matching a Valid Date
        /// <summary>
        /// Description:    This is the code for the Matching a Valid Date Recipe found in Chapter 9
        /// Recipe:         Recipe 1 - Matching a Valid Date
        /// Chapter:        9
        /// </summary>
        public void ValidDate(string stringToMatch)
        {
            /*
            THE YEAR BETWEEN 1900 and 2099
            ^                   - start from the beginning of the string
            (19|20)             - only allow 19 or 20
            \d\d                - only allow two instances of digits between (and including) 0 and 9 
            
            [-./]               - Only match -./ as valid date separators

            THE MONTH BETWEEN 01 AND 12
            (0[1-9]|1[0-2])     - Only match single digits 1 to 9 or 01 to 09 or 10 to 12
            [-./]               - Only match -./ as valid date separators

            THE DAY BETWEEN 01 AND 31
            (0[1-9]|[12][0-9]|3[01])

            0[1-9]      = 01, 02, ... 09
            [12][0-9]   = 10, 11, ... 29
            3[01]       = 30, 31
            $                   - till the end of the string

            */

            //string pattern = $@"^(19|20)\d\d[-./](0[1-9]|1[0-2])[-./](0[1-9]|[12][0-9]|3[01])$";
            string pattern = $@"^(19|20)\d\d[-./](0[1-9]|1[0-2]|[1-9])[-./](0[1-9]|[12][0-9]|3[01])$";

            if (Regex.IsMatch(stringToMatch, pattern))
                Console.WriteLine($"The string {stringToMatch} contains a valid date.");
            else
                Console.WriteLine($"The string {stringToMatch} DOES NOT contain a valid date.");
        }
        #endregion

        #region Recipe 2 - Sanitize Input
        /// <summary>
        /// Description:    This is the code for the Sanitize Input Recipe found in Chapter 9
        /// Recipe:         Recipe 2 - Sanitize Input
        /// Chapter:        9
        /// </summary>
        public string SanitizeInput(string input)
        {
            List<string> lstBad = new List<string>(new string[] { "BadWord1", "BadWord2", "BadWord3" });
            string pattern = "";
            foreach (string badWord in lstBad)
                pattern += pattern.Length == 0 ? $"{badWord}" : $"|{badWord}";

            pattern = $@"\b({pattern})\b";

            return Regex.Replace(input, pattern, "*****", RegexOptions.IgnoreCase);
        }
        #endregion

        #region Recipe 3 - Dynamic Regular Expression Matching
        /// <summary>
        /// Description:    This is the code for the Dynamic Regular Expression Matching Recipe found in Chapter 9
        /// Recipe:         Recipe 3 - Dynamic Regular Expression Matching
        /// Chapter:        9
        /// </summary>
        public void DemoExtendionMethod()
        {
            Console.WriteLine($"Today's date is: {DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}");
            Console.WriteLine($"The file must match: acm_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}.txt including leading month and day zeros");
            Console.WriteLine($"The file must match: acm_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}.docx including leading month and day zeros");
            Console.WriteLine($"The file must match: acm_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}.xlsx including leading month and day zeros");

            string filename = "acm_2016_04_10.txt";
            if (filename.ValidAcmeCompanyFilename())
                Console.WriteLine($"{filename} is a valid file name");
            else
                Console.WriteLine($"{filename} is not a valid file name");

            filename = "acm-2016_04_10.txt";
            if (filename.ValidAcmeCompanyFilename())
                Console.WriteLine($"{filename} is a valid file name");
            else
                Console.WriteLine($"{filename} is not a valid file name");

            //filename = "acm_2015_04_10.txt";
            //if (filename.ValidAcmeCompanyFilename())
            //    Console.WriteLine($"{filename} is a valid file name");
            //else
            //    Console.WriteLine($"{filename} is not a valid file name");

            //filename = "acm_2016_04_10.docx";
            //if (filename.ValidAcmeCompanyFilename())
            //    Console.WriteLine($"{filename} is a valid file name");
            //else
            //    Console.WriteLine($"{filename} is not a valid file name");

            //filename = "acm_2016_04_10.xlsx";
            //if (filename.ValidAcmeCompanyFilename())
            //    Console.WriteLine($"{filename} is a valid file name");
            //else
            //    Console.WriteLine($"{filename} is not a valid file name");

        } 
        #endregion
    }

    #region Extension Method Class for Recipe 3 - Dynamic Regular Expression Matching
    public static class CustomRegexHelper
    {
        public static bool ValidAcmeCompanyFilename(this String value)
        {
            return Regex.IsMatch(value, $@"^acm[_]{DateTime.Now.Year}[_]({DateTime.Now.Month}|0[{DateTime.Now.Month}])[_]({DateTime.Now.Day}|0[{DateTime.Now.Day}])(.txt|.docx|.xlsx)$");
        }
    } 
    #endregion
}
