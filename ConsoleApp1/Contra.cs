using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;
class Contra
{
    static object GetObject() { return null; }
    static void SetObject(object obj) { }

    static string GetString() { return "Gelukt"; }
    static void SetString(string str) { }

    public static void Test()
    {
        // Covariance. A delegate specifies a return type as object,  
        // but you can assign a method that returns a string.  
        Func<object> del = GetString;

        // Contravariance. A delegate specifies a parameter type as string,  
        // but you can assign a method that takes an object.  
        Action<string> del2 = SetObject;

        del2("hello");
        Console.WriteLine(del());
    }
}
