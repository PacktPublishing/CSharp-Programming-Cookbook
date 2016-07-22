using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Chapter1.Recipe7UsingStatic;
//using static Chapter1.Recipe7UsingStatic.TheDayOfWeek;
//using static System.Console;

namespace CodeSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Chapter 1 - Recipe 1 - String Interpolation
            //string RandDollarExchangeRate = Chapter1.Recipe1StringInterpolation.ReadExchangeRate("ZAR", "USD");
            //Console.WriteLine("The current Rand / Dollar exchange rate is:");
            //Console.WriteLine(RandDollarExchangeRate);
            //Console.Read();
            #endregion

            #region Chapter 1 - Recipe 2 - Null-conditional operator
            //int StudentCount = Chapter1.Recipe2NullConditionalOperator.GetStudents();
            //if (StudentCount >= 1)
            //    Console.WriteLine($"There {(StudentCount > 1 ? "are " : "is ")}{StudentCount} student{(StudentCount > 1 ? "s" : "")} in the list.");
            //else
            //    Console.WriteLine($"There were {StudentCount} students contained in the list.");
            //Console.Read(); 
            #endregion

            #region Chapter 1 - Recipe 3 - Auto-implemented properties
            //string BarCode = String.Empty;

            //BarCode = "123450";
            //Chapter1.Recipe3AutoImplementedProperties.CalculateSalePrice(BarCode, Chapter1.Recipe3AutoImplementedProperties.DiscountType.Sale);
            //Console.WriteLine(Chapter1.Recipe3AutoImplementedProperties.SalePrice);

            //BarCode = "123451";
            //Chapter1.Recipe3AutoImplementedProperties.CalculateSalePrice(BarCode, Chapter1.Recipe3AutoImplementedProperties.DiscountType.Clearout);
            //Console.WriteLine(Chapter1.Recipe3AutoImplementedProperties.SalePrice);

            //BarCode = "123452";
            //Chapter1.Recipe3AutoImplementedProperties.CalculateSalePrice(BarCode, Chapter1.Recipe3AutoImplementedProperties.DiscountType.Sale);
            //Console.WriteLine(Chapter1.Recipe3AutoImplementedProperties.SalePrice);

            //BarCode = "123453";
            //Chapter1.Recipe3AutoImplementedProperties.CalculateSalePrice(BarCode, Chapter1.Recipe3AutoImplementedProperties.DiscountType.Clearout);
            //Console.WriteLine(Chapter1.Recipe3AutoImplementedProperties.SalePrice);

            //BarCode = "ASW154";
            //Chapter1.Recipe3AutoImplementedProperties.CalculateSalePrice(BarCode, Chapter1.Recipe3AutoImplementedProperties.DiscountType.None);
            //Console.WriteLine(Chapter1.Recipe3AutoImplementedProperties.SalePrice);

            //Console.Read();
            #endregion

            #region Chapter 1 - Recipe 4 - Index Initializers
            //int DayNumber = 3;
            //string DayOfWeek = Chapter1.Recipe4IndexInitializers.ReturnWeekDay(DayNumber);
            //Console.WriteLine($"Day {DayNumber} is {DayOfWeek}");

            //List<int> FinancialAndBonusMonth = Chapter1.Recipe4IndexInitializers.ReturnFinancialAndBonusMonth();
            //Console.WriteLine("Financial Year Start month and Salary Increase Months are:");
            //for (int i = 0; i < FinancialAndBonusMonth.Count(); i++)
            //{
            //    Console.Write(i == 0 ? FinancialAndBonusMonth[i].ToString() + " and " : FinancialAndBonusMonth[i].ToString());
            //}

            //Console.WriteLine();
            //Chapter1.Recipe4IndexInitializers.DetermineSpecies();
            //Console.Read(); 
            #endregion

            #region Chapter 1 - Recipe 5 - Nameof Expressions
            //try
            //{
            //    List<Chapter1.Student> StudentList = Chapter1.Recipe5NameofExpression.GetStudents();
            //    Console.WriteLine($"There are {Chapter1.Recipe5NameofExpression.StudentCount} students");

            //    //int iStudentCount = Chapter1.Recipe5NameofExpression.StudentCount;
            //    //Console.WriteLine($"The value of the the {nameof(Chapter1.Recipe5NameofExpression.StudentCount)} property is {iStudentCount}");

            //    //Chapter1.Recipe5NameofExpression.SetCourse(1);
            //    //Console.WriteLine($"The selected course is {Chapter1.Recipe5NameofExpression.SelectedCourse}");

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    Console.Read();
            //}
            //Console.Read(); 
            #endregion

            #region Chapter 1 - Recipe 6 - Expression-bodied Function members
            //string BarCode = "12345113";
            //decimal ShelfPrice = 56.99m;
            //Chapter1.Recipe6ExpressionBodiedFunctionMembers.SetShelfPrice(ShelfPrice);
            //Console.WriteLine(Chapter1.Recipe6ExpressionBodiedFunctionMembers.ReturnMessage(BarCode));
            //Console.Read(); 
            #endregion

            #region Chapter 1 - Recipe 7 - Using Static
            //decimal ShelfPrice = 56.99m;

            ////Chapter1.Recipe7UsingStatic.TheDayOfWeek weekday = Chapter1.Recipe7UsingStatic.TheDayOfWeek.Friday;
            ////Chapter1.Recipe7UsingStatic.SetShelfPrice(ShelfPrice);
            ////Console.WriteLine(Chapter1.Recipe7UsingStatic.GetSalePrice(weekday));
            ////Console.Read();

            ////Remember to uncomment the using static statements above
            //TheDayOfWeek weekday = Friday;
            //SetShelfPrice(ShelfPrice);
            //WriteLine(GetSalePrice(weekday));
            //Read(); 
            #endregion

            #region Chapter 1 - Recipe 8 - Exception Filters
            //string File = @"c:\temp\XmlFile.xml";
            //Chapter1.Recipe8ExceptionFilters.ReadXMLFile(File);
            ////Chapter1.Recipe8ExceptionFilters.TryReadXMLFile(File);
            ////Console.Read(); 
            #endregion
            
            #region Chapter 1 - Recipe 9 - Await in Catch and Finally
            //Chapter1.Recipe9AwaitInCatchFinally.FileRunAsync(); 
            #endregion
        }
    }
}
