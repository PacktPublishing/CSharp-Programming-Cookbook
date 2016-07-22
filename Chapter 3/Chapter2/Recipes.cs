using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Chapter2
{
    #region Recipe 1 - Creating and implementing an Abstract Class
    /// <summary>
    /// Description:    This is the code for the Creating and implementing an Abstract Class Recipe found in Chapter 2
    /// Recipe:         Recipe 1 - Creating and implementing an Abstract Class
    /// Chapter:        2
    /// </summary>
    public abstract class Cat
    {//http://www.nhptv.org/wild/felidae.asp
        public abstract void Eat();
        public abstract void Hunt();
        public abstract void Sleep();
    }

    public class Lion : Cat
    {
        public enum ColorSpectrum { Brown, White }
        public string LionColor { get; set; }

        public override void Eat()
        {
            WriteLine($"The {LionColor} lion eats.");
        }

        public override void Hunt()
        {
            WriteLine($"The {LionColor} lion hunts.");
        }

        public override void Sleep()
        {
            WriteLine($"The {LionColor} lion sleeps.");
        }

        public Lion(ColorSpectrum color)
        {
            LionColor = color.ToString();
        }
    }

    public class Tiger : Cat
    {
        public enum ColorSpectrum { Orange, White, Gold, Blue, Black }
        public string TigerColor { get; set; }
        public override void Eat()
        {
            WriteLine($"The {TigerColor} tiger eats.");
        }

        public override void Hunt()
        {
            WriteLine($"The {TigerColor} tiger hunts.");
        }

        public override void Sleep()
        {
            WriteLine($"The {TigerColor} tiger sleeps.");
        }

        public Tiger(ColorSpectrum color)
        {
            TigerColor = color.ToString();
        }
    }
    #endregion
    
    #region Recipe 2 - Creating and Implementing an Interface
    /// <summary>
    /// Description:    This is the code for the Creating and Implementing an Interface Recipe found in Chapter 2
    /// Recipe:         Recipe 2 - Creating and Implementing an Interface
    /// Chapter:        2
    /// </summary>
    public class Cheetah : Cat, IPurrable
    {
        public void SoftPurr(int decibel)
        {
            WriteLine($"The {nameof(Cheetah)} purrs at {decibel} decibels.");
        }

        public override void Eat()
        {
            WriteLine($"The cheetah eats.");
        }

        public override void Hunt()
        {
            WriteLine($"The cheetah hunts.");
        }

        public override void Sleep()
        {
            WriteLine($"The cheetah sleeps.");
        }
    }

    interface IPurrable
    {
        void SoftPurr(int decibel);
    }
    #endregion
    
    #region Recipe 3 - Creating and using a generic class or method
    /// <summary>
    /// Description:    This is the code for the Creating and using a generic class or method Recipe found in Chapter 2
    /// Recipe:         Recipe 3 - Creating and using a generic class or method
    /// Chapter:        2
    /// </summary>
    public class PerformAction<T>
    {
        private T _value;

        public PerformAction(T value)
        {
            _value = value;
        }

        public void IdentifyDataType()
        {
            WriteLine($"The data type of the supplied variable is {_value.GetType()}");
        }
    }

    //public class PerformAction<T> where T : IDisposable
    //{
    //    private T _value;

    //    public PerformAction(T value)
    //    {
    //        _value = value;
    //    }

    //    public void IdentifyDataType()
    //    {
    //        WriteLine($"The data type of the supplied variable is {_value.GetType()}");
    //    }
    //}

    //public class MyHelperClass
    //{
    //    public T InspectType<T>(T value) 
    //    {
    //        WriteLine($"The data type of the supplied parameter is {value.GetType()}");

    //        return (T)value;
    //    }
    //} 
    #endregion
        
    #region Recipe 4 - Creating generic interfaces
    /// <summary>
    /// Description:    This is the code for the Creating generic interfaces Recipe found in Chapter 2
    /// Recipe:         Recipe 4 - Creating generic interfaces
    /// Chapter:        2
    /// </summary>
    public class InspectClass<T> : IListClassProperties<T>
    {
        T _classToInspect;
        public InspectClass(T classToInspect)
        {
            _classToInspect = classToInspect;
        }

        public List<string> GetPropertyList()
        {
            return _classToInspect.GetType().GetProperties().Select(p => p.Name).ToList();
        }
    }
    
    //public class InspectClass<T> : IListClassProperties<T> where T : class
    //{
    //    T _classToInspect;
    //    public InspectClass(T classToInspect)
    //    {
    //        _classToInspect = classToInspect;
    //    }

    //    public List<string> GetPropertyList()
    //    {
    //        return _classToInspect.GetType().GetProperties().Select(p => p.Name).ToList();
    //    }
    //}

    //public class InspectClass<T> : IListClassProperties<T> where T : AcmeObject
    //{
    //    T _classToInspect;
    //    public InspectClass(T classToInspect)
    //    {
    //        _classToInspect = classToInspect;
    //    }

    //    public List<string> GetPropertyList()
    //    {
    //        return _classToInspect.GetType().GetProperties().Select(p => p.Name).ToList();
    //    }
    //}

    interface IListClassProperties<T>
    {
        List<string> GetPropertyList();
    }

    public abstract class AcmeObject
    {
        public abstract int ID { get; set; }
    }

    #endregion
}



