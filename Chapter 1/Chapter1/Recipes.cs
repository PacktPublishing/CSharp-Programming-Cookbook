using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;

namespace Chapter1
{
    #region Recipe1StringInterpolation
    /// <summary>
    /// Description:    This is the code for the String Interpolation Recipe found in Chapter 1
    /// Recipe:         Recipe 1 - String Interpolation
    /// Chapter:        1
    /// </summary>
    public static class Recipe1StringInterpolation
    {
        public static string BaseCurrency { get; private set; }

        public static string ReadExchangeRate(string fromCurrencyCode, string toCurrencyCode)
        {
            BaseCurrency = fromCurrencyCode;
            decimal conversion = PreformConversion(toCurrencyCode);
            return $"1 {toCurrencyCode} = {conversion} {fromCurrencyCode} ";
            //return String.Format("1 {0} = {1} {2} ", toCurrencyCode, conversion, fromCurrencyCode); // Previously used String.Format
            //return $"{{{conversion}}}";
            //return $"The date is {DateTime.Now}";
            //return $"The date is {DateTime.Now : MMMM dd, yyyy}";
            //return $"The year {DateTime.Now.Year} {(DateTime.IsLeapYear(DateTime.Now.Year) ? " is " : " is not ")} a leap year.";
            //return $"The year {DateTime.Now.Year - 1} {(DateTime.IsLeapYear(DateTime.Now.Year - 1) ? " is " : " is not ")} a leap year.";
        }

        private static decimal PreformConversion(string toCurrency)
        {
            decimal rate = 0.0m;

            if (BaseCurrency.Equals("ZAR"))
            {
                switch (toCurrency)
                {
                    case "USD":
                        rate = 16.3040m;
                        break;
                    default:
                        rate = 1.0m;
                        break;
                }
            }

            return rate;
        }
    }
    #endregion

    #region Recipe2NullConditionalOperator
    /// <summary>
    /// Description:    This is the code for the Null-conditional operator Recipe found in Chapter 1
    /// Recipe:         Recipe 2 - Null-conditional operator
    /// Chapter:        1
    /// </summary>
    public static class Recipe2NullConditionalOperator
    {
        public static int GetStudents()
        {
            //DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            //ds.Tables.Add(dt);

            List<Student> students = new List<Student>();
            Student st = new Student();

            st.FirstName = "Dirk";
            st.LastName = "Strauss";
            st.JobTitle = "";
            st.Age = 19;
            st.StudentNumber = "20323742";
            students.Add(st);

            st.FirstName = "Bob";
            st.LastName = "Healey";
            st.JobTitle = "Lab Assistant";
            st.Age = 21;
            st.StudentNumber = "21457896";
            students.Add(st);

            students = null;

            return students?.Count() ?? 0;
            //return students.Count();            
        }
    }
    #endregion

    #region Recipe3AutoImplementedProperties
    /// <summary>
    /// Description:    This is the code for the Auto-Implemented Properties Recipe found in Chapter 1
    /// Recipe:         Recipe 3 - Auto-Implemented Properties
    /// Chapter:        1
    /// </summary>
    public static class Recipe3AutoImplementedProperties
    {
        public enum DiscountType
        {
            Sale,
            Clearout,
            None
        }
        private static int SaleDiscountPercent { get; } = 20;
        private static int ClearoutDiscountPercent { get; } = 35;
        public static decimal ShelfPrice { get; set; } = 100;
        public static decimal SalePrice { get; set; } = 100;

        public static void CalculateSalePrice(string barCode, DiscountType discount)
        {
            decimal shelfPrice = GetPriceFromBarcode(barCode);

            if (discount == DiscountType.Sale)
                SalePrice = (shelfPrice == 0 ? ShelfPrice.CalculateSalePrice(SaleDiscountPercent) : shelfPrice.CalculateSalePrice(SaleDiscountPercent));

            if (discount == DiscountType.Clearout)
                SalePrice = (shelfPrice == 0 ? ShelfPrice.CalculateSalePrice(ClearoutDiscountPercent) : shelfPrice.CalculateSalePrice(ClearoutDiscountPercent));

            if (discount == DiscountType.None)
                SalePrice = (shelfPrice == 0 ? ShelfPrice : shelfPrice);

            //SalePrice = 200;
            //ShelfPrice = 200;
            //SaleDiscountPercent = 75;
            //ClearoutDiscountPercent = 95;         
        }

        private static decimal GetPriceFromBarcode(string barCode)
        {
            switch (barCode)
            {
                case "123450":
                    return 19.95m;
                case "123451":
                    return 7.55m;
                case "123452":
                    return 59.99m;
                case "123453":
                    return 93.99m;
                default:
                    return 0;
            }
        }
    }
    #endregion
    
    #region Recipe4IndexInitializers
    /// <summary>
    /// Description:    This is the code for the Index Initializers Recipe found in Chapter 1
    /// Recipe:         Recipe 4 - Index Initializers
    /// Chapter:        1
    /// </summary>
    public static class Recipe4IndexInitializers
    {
        public static string ReturnWeekDay(int dayNumber)
        {
            Dictionary<int, string> day = new Dictionary<int, string>
            {
                [1] = "Monday",
                [2] = "Tuesday",
                [3] = "Wednesday",
                [4] = "Thursday",
                [5] = "Friday",
                [6] = "Saturday",
                [7] = "Sunday"
            };

            return day[dayNumber];
        }

        public static List<int> ReturnFinancialAndBonusMonth()
        {
            Month currentMonth = new Month();
            int[] array = new[] { currentMonth.StartFinancialYearMonth, currentMonth.SalaryIncreaseMonth };
            return new List<int>(array) { [1] = 2 };
        }


        public static string Human { get; set; } = "Homo sapiens";
        public static string Rabbit { get; set; } = "Oryctolagus cuniculus";
        public static string Sloth { get; set; } = "Choloepus hoffmanni";
        public static string Mouse { get; set; } = "Mus musculus";
        public static string Hedgehog { get; set; } = "Erinaceus europaeus";
        public static string Dolphin { get; set; } = "Tursiops truncatus";
        public static string Dog { get; set; } = "Canis lupus familiaris";

        public static void DetermineSpecies()
        {
            Dictionary<string, string> Species = new Dictionary<string, string>
            {
                [Human] = Human + " : Additional species information",
                [Rabbit] = Rabbit + " : Additional species information",
                [Sloth] = Sloth + " : Additional species information",
                [Mouse] = Mouse + " : Additional species information",
                [Hedgehog] = Hedgehog + " : Additional species information",
                [Dolphin] = Dolphin + " : Additional species information",
                [Dog] = Dog + " : Additional species information"
            };

            Console.WriteLine(Species[Human]);
        }

        //public static Month ToMonth()
        //{
        //    var result = new Month() { SalaryIncreaseMonth = 3, StartFinancialYearMonth = 4 };
        //    return result;
        //}
    }
    #endregion

    #region Recipe5NameofExpression
    /// <summary>
    /// Description:    This is the code for the Nameof Expression Recipe found in Chapter 1
    /// Recipe:         Recipe 5 - Nameof Expression
    /// Chapter:        1
    /// </summary>
    public static class Recipe5NameofExpression
    {
        public static int StudentCount { get; set; } = 0;
        public static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            try
            {
                Student st = new Student();

                st.FirstName = "Dirk";
                st.LastName = "Strauss";
                st.JobTitle = "";
                st.Age = 19;
                st.StudentNumber = "20323742";
                students.Add(st);

                st.FirstName = "Bob";
                st.LastName = "Healey";
                st.JobTitle = "Lab Assistant";
                st.Age = 21;
                st.StudentNumber = "21457896";
                students.Add(st);

                //students = null;

                StudentCount = students.Count();

                return students;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(nameof(students));
            }
        }


        public enum Course { InformationTechnology = 1, Statistics = 2, AppliedSciences = 3 }
        public static string SelectedCourse { get; set; }
        public static void SetCourse(int iCourseID)
        {
            Course course = (Course)iCourseID;
            switch (course)
            {
                case Course.InformationTechnology:
                    SelectedCourse = nameof(Course.InformationTechnology);
                    break;
                case Course.Statistics:
                    SelectedCourse = nameof(Course.InformationTechnology);
                    break;
                case Course.AppliedSciences:
                    SelectedCourse = nameof(Course.InformationTechnology);
                    break;
                default:
                    SelectedCourse = "InvalidCourse";
                    break;
            }
        }
    }
    #endregion
    
    #region Recipe6ExpressionBodiedFunctionMembers
    /// <summary>
    /// Description:    This is the code for the Expression Bodied Function members Recipe found in Chapter 1
    /// Recipe:         Recipe 6 - Expression Bodied Function members
    /// Chapter:        1
    /// </summary>
    public static class Recipe6ExpressionBodiedFunctionMembers
    {
        private static int SaleDiscountPercent { get; } = 20;
        private static decimal ShelfPrice { get; set; } = 100;

        #region Old code
        /*
        // Computed property
        private static decimal GetCalculatedSalePrice
        {
            get { return Math.Round(ShelfPrice.CalculateSalePrice(SaleDiscountPercent), 2); }
        }

        public static void SetShelfPrice(decimal shelfPrice)
        {
            ShelfPrice = shelfPrice;
        }

        public static string ReturnMessage(string barCode)
        {
            return $"The sale price for barcode {barCode} is {GetCalculatedSalePrice}";
        }
        */
        #endregion

        // Expression-bodied property - no get keyword. That is implied
        private static decimal GetCalculatedSalePrice => Math.Round(ShelfPrice.CalculateSalePrice(SaleDiscountPercent));

        // Expression-bodied void returning method
        public static void SetShelfPrice(decimal shelfPrice) => ShelfPrice = shelfPrice;

        // Expression-bodied method
        public static string ReturnMessage(string barCode) => $"The sale price for barcode {barCode} is {GetCalculatedSalePrice}";
    }
    #endregion
    
    #region Recipe7UsingStatic
    /// <summary>
    /// Description:    This is the code for the Using Static Recipe found in Chapter 1
    /// Recipe:         Recipe 7 - Using Static
    /// Chapter:        1
    /// </summary>
    public static class Recipe7UsingStatic
    {
        public enum TheDayOfWeek
        {
            Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
        }

        private static int SaleDiscountPercent { get; } = 20;
        private static decimal ShelfPrice { get; set; } = 100;

        //private static decimal GetCalculatedSalePrice
        //{
        //    get { return Math.Round(ShelfPrice.CalculateSalePrice(SaleDiscountPercent), 2); }
        //}

        private static decimal GetCalculatedSalePrice
        {
            get { return Round(ShelfPrice.CalculateSalePrice(SaleDiscountPercent), 2); }
        }

        public static void SetShelfPrice(decimal shelfPrice)
        {
            ShelfPrice = shelfPrice;
        }

        public static decimal GetSalePrice(TheDayOfWeek dayOfWeek)
        {
            //Sqrt(64);
            //Tan(64);
            //Pow(8, 2);

            return dayOfWeek == TheDayOfWeek.Friday ? GetCalculatedSalePrice : ShelfPrice;
        }
    }
    #endregion
    
    #region Recipe8ExceptionFilters
    /// <summary>
    /// Description:    This is the code for the Exception Filters Recipe found in Chapter 1
    /// Recipe:         Recipe 8 - Exception Filters
    /// Chapter:        1
    /// </summary>
    public static class Recipe8ExceptionFilters
    {
        #region Old Try Catch
        //public static void ReadXMLFile(string fileName)
        //{
        //    try
        //    {
        //        bool blnReadFileFlag = true;
        //        if (blnReadFileFlag)
        //        {
        //            File.ReadAllLines(fileName);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log(ex);
        //        throw;
        //    }
        //}

        //private static void Log(Exception e)
        //{
        //    /* Log the error */            
        //} 
        #endregion

        public static void ReadXMLFile(string fileName)
        {
            try
            {
                bool blnReadFileFlag = true;
                if (blnReadFileFlag)
                {
                    File.ReadAllLines(fileName);
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            //catch (FileNotFoundException ex)
            //{

            //}
        }

        private static bool Log(Exception e)
        {
            /* Log the error */
            return false;
        }

        public static void TryReadXMLFile(string fileName)
        {
            bool blnFileRead = false;
            do
            {
                int iTryCount = 0;
                try
                {
                    bool blnReadFileFlag = true;
                    if (blnReadFileFlag)
                        File.ReadAllLines(fileName);
                }
                catch (Exception ex) when (RetryRead(ex, iTryCount++) == true)
                {

                }
            } while (!blnFileRead);
        }

        private static bool RetryRead(Exception e, int tryCount)
        {
            bool blnThrowEx = tryCount <= 10 ? blnThrowEx = false : blnThrowEx = true;
            /* Log the error if blnThrowEx = false */
            return blnThrowEx;
        }
    }
    #endregion
    
    #region Recipe9AwaitInCatchFinally
    /// <summary>
    /// Description:    This is the code for the Await In Catch and Finally Recipe found in Chapter 1
    /// Recipe:         Recipe 9 - Await In Catch and Finally
    /// Chapter:        1
    /// </summary>
    public static class Recipe9AwaitInCatchFinally
    {
        public static void FileRunAsync()
        {
            string filePath = @"c:\temp\XmlFile.xml";
            RemoveFileAcync(filePath);
            ReadLine();
        }
        public static async void RemoveFileAcync(string filepath)
        {
            try
            {
                WriteLine("Read file");
                File.ReadAllLines(filepath);
            }
            catch (Exception ex)
            {
                WriteLine($"Exception - wait 3 seconds {DateTime.Now.ToString("hh:MM:ss tt")}");
                await Task.Delay(3000);
                WriteLine($"Exception - Print {DateTime.Now.ToString("hh:MM:ss tt")}");
                WriteLine(ex.Message);
            }
            finally
            {
                WriteLine($"Finally - wait 3 seconds {DateTime.Now.ToString("hh:MM:ss tt")}");
                await Task.Delay(3000);
                WriteLine($"Finally - completed {DateTime.Now.ToString("hh:MM:ss tt")}");
            }
        }
    }
    #endregion
    
    #region Helper Classes
    public class Month
    {
        public int StartFinancialYearMonth { get; set; } = 2;
        public int SalaryIncreaseMonth { get; set; } = 3;
    }

    public static class ExtensionMethods
    {
        public static decimal CalculateSalePrice(this decimal shelfPrice, int discountPercent)
        {
            decimal discountValue = (shelfPrice / 100) * discountPercent;
            return shelfPrice - discountValue;
        }
    }

    public class Student
    {
        public string StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string JobTitle { get; set; }

        //public Student MastersStudent { get; set; }
    } 
    #endregion
}
