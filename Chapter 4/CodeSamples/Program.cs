using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Chapter1.Recipe7UsingStatic;
//using static Chapter1.Recipe7UsingStatic.TheDayOfWeek;
//using static System.Console;
using Chapter2;
using System.Data;
using Chapter3;
using System.Reactive.Subjects;
using System.Reactive.Linq;

namespace CodeSamples
{
    class Program
    {
        // Static action event
        static event Action<string> types;

        // IObservable Subject
        static Subject<string> obsTypes = new Subject<string>();        

        static void Main(string[] args)
        {
            #region Chapter1

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

            #endregion

            #region Chapter2

            #region Chapter 2 - Recipe 1 - Abstract Classes
            //Lion lion = new Lion(Lion.ColorSpectrum.White);
            //lion.Hunt();
            //lion.Eat();
            //lion.Sleep();

            //Tiger tiger = new Tiger(Tiger.ColorSpectrum.Blue);
            //tiger.Hunt();
            //tiger.Eat();
            //tiger.Sleep();

            //Console.ReadLine(); 
            #endregion

            #region Chapter 2 - Recipe 2 - Interfaces
            //Cheetah cheetah = new Cheetah();
            //cheetah.Hunt();
            //cheetah.Eat();
            //cheetah.Sleep();
            //cheetah.SoftPurr(60);
            //Console.ReadLine(); 
            #endregion

            #region Chapter 2 - Recipe 3 - Creating and using a generic class or method
            //PerformAction<int> iAction = new PerformAction<int>(21);
            //iAction.IdentifyDataType();

            //PerformAction<decimal> dAction = new PerformAction<decimal>(21.55m);
            //dAction.IdentifyDataType();

            //PerformAction<string> sAction = new PerformAction<string>("Hello Generics");
            //sAction.IdentifyDataType();

            //Console.ReadLine();

            //DataSet dsData = new DataSet();
            //PerformAction<DataSet> oAction = new PerformAction<DataSet>(dsData);
            //oAction.IdentifyDataType();

            //Console.ReadLine();


            //MyHelperClass oHelper = new MyHelperClass();
            //var intExample = oHelper.InspectType(25);
            //Console.WriteLine($"An example of this type is {intExample}");

            //var decExample = oHelper.InspectType(11.78m);
            //Console.WriteLine($"An example of this type is {decExample}");

            //var strExample = oHelper.InspectType("Hello Generics");
            //Console.WriteLine($"An example of this type is {strExample}");

            //var enmExample = oHelper.InspectType(MyEnum.Value2);
            //Console.WriteLine($"An example of this type is {enmExample}");

            //Console.ReadLine(); 
            #endregion

            #region Chapter 2 - Recipe 4 - Creating generic interfaces
            //Invoice oInvoice = new Invoice();
            //InspectClass<Invoice> oClassInspector = new InspectClass<Invoice>(oInvoice);
            //List<string> lstProps = oClassInspector.GetPropertyList();

            //foreach (string property in lstProps)
            //{
            //    Console.WriteLine(property);
            //}
            //Console.ReadLine();

            //InspectClass<int> oClassInspector = new InspectClass<int>(10);
            //List<string> lstProps = oClassInspector.GetPropertyList();
            //foreach (string property in lstProps)
            //{
            //    Console.WriteLine(property);
            //}
            //Console.ReadLine();


            //Invoice oInvoice = new Invoice();
            //InspectClass<Invoice> oInvClassInspector = new InspectClass<Invoice>(oInvoice);
            //List<string> invProps = oInvClassInspector.GetPropertyList();

            //foreach (string property in invProps)
            //{
            //    Console.WriteLine(property);
            //}
            //Console.ReadLine();


            //SalesOrder oSalesOrder = new SalesOrder();
            //InspectClass<SalesOrder> oSoClassInspector = new InspectClass<SalesOrder>(oSalesOrder);
            //List<string> soProps = oSoClassInspector.GetPropertyList();

            //foreach (string property in soProps)
            //{
            //    Console.WriteLine(property);
            //}
            //Console.ReadLine();


            //CreditNote oCreditNote = new CreditNote();
            //InspectClass<CreditNote> oCredClassInspector = new InspectClass<CreditNote>(oCreditNote);
            //List<string> credProps = oCredClassInspector.GetPropertyList();

            //foreach (string property in credProps)
            //{
            //    Console.WriteLine(property);
            //}
            //Console.ReadLine(); 
            #endregion

            #endregion

            #region Chapter 3

            #region Chapter 3 - Recipe 1 - Using Inheritance in C#
            //SpaceShip transporter = new SpaceShip();
            //transporter.ControlBridge();
            //transporter.CrewQuarters(1500);
            //transporter.EngineRoom(2);
            //transporter.MedicalBay(350);
            //transporter.TeleportationRoom();

            //Destroyer warShip = new Destroyer();
            //warShip.Armory(6);
            //warShip.ControlBridge();
            //warShip.CrewQuarters(2200);
            //warShip.EngineRoom(4);
            //warShip.MedicalBay(800);
            //warShip.TeleportationRoom();
            //warShip.WarRoom();
            //warShip.WarSpecialists(1);

            //Annihilator planetClassDestroyer = new Annihilator();
            //planetClassDestroyer.Armory(12);
            //planetClassDestroyer.ControlBridge();
            //planetClassDestroyer.CrewQuarters(4500);
            //planetClassDestroyer.EngineRoom(7);
            //planetClassDestroyer.MedicalBay(3500);
            //planetClassDestroyer.PlanetDestructionCapability();
            //planetClassDestroyer.TeleportationRoom();
            //planetClassDestroyer.TractorBeam();
            //planetClassDestroyer.WarRoom();
            //planetClassDestroyer.WarSpecialists(3); 
            #endregion

            #region Chapter 3 - Recipe 2 - Using Abstraction
            // No code used here for abstraction 
            #endregion

            #region Chapter 3 - Recipe 3 - Leveraging Encapsulation
            //double thrust = 220; // kN
            //double shuttleMass = 16.12; // t
            //double graviatatonalAccelerationEarth = 9.81;
            //double earthMass = 5.9742 * Math.Pow(10, 24);
            //double earthRadius = 6378100;
            //double thrustToWeightRatio = 0;

            //LaunchShuttle NasaShuttle1 = new LaunchShuttle(thrust, shuttleMass, graviatatonalAccelerationEarth);
            //thrustToWeightRatio = NasaShuttle1.TWR();
            //Console.WriteLine(thrustToWeightRatio);

            //LaunchShuttle NasaShuttle2 = new LaunchShuttle(thrust, shuttleMass, LaunchShuttle.Planet.Earth);
            //thrustToWeightRatio = NasaShuttle2.TWR();
            //Console.WriteLine(thrustToWeightRatio);

            //LaunchShuttle NasaShuttle3 = new LaunchShuttle(thrust, shuttleMass, earthMass, earthRadius);
            //thrustToWeightRatio = NasaShuttle3.TWR();
            //Console.WriteLine(thrustToWeightRatio);

            //Console.Read(); 
            #endregion

            #region Chapter 3 - Recipe 4 - Implementing Polymorphism
            // No code used here for polymorphism 
            #endregion

            #endregion



            #region Chapter 4 - Recipe 1 - Events vs Observables
            #region Create the list of DotNet class
            //List<DotNet> lstTypes = new List<DotNet>();
            //DotNet blnTypes = new DotNet();
            //blnTypes.AvailableDatatype = "bool";
            //lstTypes.Add(blnTypes);

            //DotNet strTypes = new DotNet();
            //strTypes.AvailableDatatype = "string";
            //lstTypes.Add(strTypes);

            //DotNet intTypes = new DotNet();
            //intTypes.AvailableDatatype = "int";
            //lstTypes.Add(intTypes);

            //DotNet decTypes = new DotNet();
            //decTypes.AvailableDatatype = "decimal";
            //lstTypes.Add(decTypes); 
            #endregion

            #region Basic Event
            //types += x =>
            //{
            //    Console.WriteLine(x);
            //};


            //for (int i = 0; i <= lstTypes.Count - 1; i++)
            //{
            //    types(lstTypes[i].AvailableDatatype);
            //} 
            #endregion

            #region Reactive Extensions
            //// IObservable
            //obsTypes.Subscribe(x =>
            //{
            //    Console.WriteLine(x);
            //});

            //// IObserver
            //for (int i = 0; i <= lstTypes.Count - 1; i++)
            //{
            //    obsTypes.OnNext(lstTypes[i].AvailableDatatype);                
            //} 
            #endregion

            //Console.ReadLine(); 
            #endregion















        }



        #region Classes for Chapter 4 - Recipe 1 - Events vs Observables
        public class DotNet
        {
            public string AvailableDatatype { get; set; }
        } 
        #endregion
                
        public enum MyEnum { Value1, Value2, Value3 }

        #region Classes for Chapter 2 - Recipe 4 - Creating generic interfaces
        public class Invoice
        {
            public int ID { get; set; }
            public decimal TotalValue { get; set; }
            public int LineNumber { get; set; }
            public string StockItem { get; set; }
            public decimal ItemPrice { get; set; }
            public int Qty { get; set; }
        }

        //public class Invoice : AcmeObject
        //{
        //    public override int ID { get; set; }
        //    public decimal TotalValue { get; set; }
        //    public int LineNumber { get; set; }
        //    public string StockItem { get; set; }
        //    public decimal ItemPrice { get; set; }
        //    public int Qty { get; set; }            
        //}

        //public class SalesOrder : AcmeObject
        //{
        //    public override int ID { get; set; }
        //    public decimal TotalValue { get; set; }
        //    public int LineNumber { get; set; }
        //    public string StockItem { get; set; }
        //    public decimal ItemPrice { get; set; }
        //    public int Qty { get; set; }
        //}

        //public class CreditNote
        //{
        //    public int ID { get; set; }
        //    public decimal TotalValue { get; set; }
        //    public int LineNumber { get; set; }
        //    public string StockItem { get; set; }
        //    public decimal ItemPrice { get; set; }
        //    public int Qty { get; set; }
        //} 
        #endregion

    }
}
