using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Chapter8
{
    public static class Recipes
    {
        #region Recipe 1 - Code Contract Preconditions
        /// <summary>
        /// Description:    This is the code for the Code Contract Preconditions Recipe found in Chapter 8
        /// Recipe:         Recipe 1 - Code Contract Preconditions
        /// Chapter:        8
        /// </summary>
        public static void ValueGreaterThanZero(int iNonZeroValue)
        {
            //Contract.Requires(iNonZeroValue >= 1, "Parameter iNonZeroValue not greater than zero");
        }
        #endregion

        #region Recipe 2 - Code Contract Postconditions
        /// <summary>
        /// Description:    This is the code for the Code Contract Postconditions Recipe found in Chapter 8
        /// Recipe:         Recipe 2 - Code Contract Postconditions
        /// Chapter:        8
        /// </summary>
        public static int NeverReturnZero(int iNonZeroValue)
        {
            //Contract.Ensures(Contract.Result<int>() > 0, "The value returned was not greater than zero");

            return iNonZeroValue - 1;
        }
        #endregion
        
        #region Recipe 4 - Code Contract Assert and Assume
        /// <summary>
        /// Description:    This is the code for the Code Contract Assert and Assume Recipe found in Chapter 8
        /// Recipe:         Recipe 4 - Code Contract Assert and Assume
        /// Chapter:        8
        /// </summary>
        public static int ValueIsValid(int valueForCalc, int valueToDivide)
        {
            int calculatedVal = valueForCalc - 1;
            Contract.Assert(calculatedVal >= 1, "Calculated value will result in divide by zero exception.");
            return valueToDivide / calculatedVal;
        }

        //public static int ValueIsValid(int valueForCalc, int valueToDivide)
        //{
        //    Contract.Requires((valueForCalc - 1) >= 1);
        //    int calculatedVal = valueForCalc - 1;
        //    Contract.Assert(calculatedVal >= 1, "Calculated value will result in divide by zero exception.");
        //    return valueToDivide / calculatedVal;
        //}

        //public static int ValueIsValid(int valueForCalc, int valueToDivide)
        //{
        //    Contract.Assume((valueForCalc - 1) >= 1);
        //    int calculatedVal = valueForCalc - 1; 
        //    Contract.Assert(calculatedVal >= 1, "Calculated value will result in divide by zero exception.");
        //    return valueToDivide / calculatedVal; 
        //} 
        #endregion

        #region Recipe 5 - Code Contract ForAll
        /// <summary>
        /// Description:    This is the code for the Code Contract ForAll Recipe found in Chapter 8
        /// Recipe:         Recipe 5 - Code Contract ForAll
        /// Chapter:        8
        /// </summary>
        public static void ValidateList(List<int> lstValues)
        {
            Contract.Assert(Contract.ForAll(lstValues, n => n != 0), "Zero values are not allowed");
        }
        #endregion

        #region Recipe 6 - Code Contract ValueAtReturn
        /// <summary>
        /// Description:    This is the code for the Code Contract ValueAtReturn Recipe found in Chapter 8
        /// Recipe:         Recipe 6 - Code Contract ValueAtReturn
        /// Chapter:        8
        /// </summary>
        public static void ValidOutValue(out int secureValue)
        {
            Contract.Ensures(Contract.ValueAtReturn<int>(out secureValue) >= 1, "The secure value is less or equal to zero");
            secureValue = secureValue - 10;
        }
        #endregion

        #region Recipe 7 - Creating Code Contract Result
        /// <summary>
        /// Description:    This is the code for the Creating Code Contract Result Recipe found in Chapter 8
        /// Recipe:         Recipe 7 - Creating Code Contract Result
        /// Chapter:        8
        /// </summary>
        public static int ValidateResult(int value1, int value2)
        {
            Contract.Ensures(Contract.Result<int>() >= 0, "Negative result not allowed");
            return value1 - value2;
        }
        #endregion
        
        #region Recipe 9 - Using Contract Abbreviator Methods
        /// <summary>
        /// Description:    This is the code for the Using Contract Abbreviator Methods Recipe found in Chapter 8
        /// Recipe:         Recipe 9 - Using Contract Abbreviator Methods
        /// Chapter:        8
        /// </summary>
        public static int MethodOne(int value)
        {
            //Contract.Requires(value > 0, "Parameter can't be zero");
            //Contract.Ensures(Contract.Result<int>() > 0, "Method result can't be zero");
            StandardMethodContract(value);

            return value - 1;
        }

        public static int MethodTwo(int value)
        {
            //Contract.Requires(value > 0, "Parameter can't be zero");
            //Contract.Ensures(Contract.Result<int>() > 0, "Method result can't be zero");
            StandardMethodContract(value);

            return (value * 10) - 10;
        }
        
        [ContractAbbreviator]
        private static void StandardMethodContract(int value)
        {
            Contract.Requires(value > 0, "Parameter can't be zero");
            Contract.Ensures(Contract.Result<int>() >= 1, "Method result can't be zero");
        } 
        #endregion

    }

    #region Recipe 3 - Code Contract Invariant
    /// <summary>
    /// Description:    This is the code for the Code Contract Invariant Recipe found in Chapter 8
    /// Recipe:         Recipe 3 - Code Contract Invariant
    /// Chapter:        8
    /// </summary>
    public class InvariantClassState
    {        
        private int _Year { get; set; }
        private int _Month { get; set; }
        private int _Day { get; set; }

        public InvariantClassState(int year, int month, int day)
        {
            _Year = year;
            _Month = month;
            _Day = day;
        }

        [ContractInvariantMethod]
        private void Invariants()
        {
            Contract.Invariant(this._Year >= DateTime.Now.Year, "The supplied year is in the past");
            Contract.Invariant(this._Month <= 12, $"The value {_Month} is not a valid Month value");
            Contract.Invariant(this._Month >= 1, $"The value {_Month} is not a valid Month value");
            Contract.Invariant(this._Day >= 1, $"The value {_Day} is not a valid calendar value");
            Contract.Invariant(this._Day <= DateTime.DaysInMonth(_Year, _Month), $"The month given does not contain {_Day} days");
        }

        public string ReturnGivenMonthDayYearDate()
        {
            return $"{_Month}/{_Day}/{_Year}";
        }        
    }
    #endregion
    
    #region Recipe 8 - Creating Code Contracts on Abstract Classes
    /// <summary>
    /// Description:    This is the code for the Creating Code Contracts on Abstract Classes Recipe found in Chapter 8
    /// Recipe:         Recipe 8 - Creating Code Contracts on Abstract Classes
    /// Chapter:        8
    /// </summary>
    public class Rectangle : Shape
    {
        private int _length { get; set; }
        private int _width { get; set; }
        public override void Length(int value)
        {
            _length = value;
        }
        public override void Width(int value)
        {
            _width = value;
        }
    }

    [ContractClass(typeof(ShapeContract))]
    public abstract class Shape
    {
        public abstract void Length(int value);
        public abstract void Width(int value);
    }

    [ContractClassFor(typeof(Shape))]
    public abstract class ShapeContract : Shape
    {
        public override void Length(int value)
        {
            Contract.Requires(value > 0, "Length can't be zero");
        }

        public override void Width(int value)
        {
            Contract.Requires(value > 0, "Width can't be zero");
        }
    }
    #endregion

    #region Recipe 10 - Creating tests using IntelliTest
    /// <summary>
    /// Description:    This is the code for the Creating tests using IntelliTest Recipe found in Chapter 8
    /// Recipe:         Recipe 10 - Creating tests using IntelliTest
    /// Chapter:        8
    /// </summary>
    public class CodeContractTests
    {
        public int Calculate(int valueOne, int valueTwo)
        {
            Contract.Requires(valueOne > 0, "Parameter can't be zero");
            Contract.Requires(valueTwo > 0, "Parameter can't be zero");
            Contract.Requires(valueOne > valueTwo, "Parameter values will result in value <= 0");
            Contract.Ensures(Contract.Result<int>() >= 1, "");

            return valueOne / valueTwo;
        }
    } 
    #endregion
    
    #region Recipe 11 - Using Code Contracts in Extension Methods
    /// <summary>
    /// Description:    This is the code for the Using Code Contracts in Extension Methods Recipe found in Chapter 8
    /// Recipe:         Recipe 10 - Using Code Contracts in Extension Methods
    /// Chapter:        8
    /// </summary>
    public static class ExtensionMethods
    {
        public static bool ContainsInvalidValue<T>(this List<T> value, T invalidValue)
        {
            try
            {
                Contract.Assert(Contract.ForAll(value, n => !value.Contains(invalidValue)), "Zero values are not allowed");
                return false;
            }
            catch
            {
                return true;
            }
        }
    } 
    #endregion
}
