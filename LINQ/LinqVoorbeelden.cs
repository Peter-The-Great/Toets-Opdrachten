using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ;
class LinqVoorbeelden
{
    public static void Hoofd()
    {
        Sample_Aggregate_Lambda();
        Sample_All_Lambda();
        Sample_Any_Lambda();
        Sample_OfType_Lambda();
        Sample_OrderBy_Lambda();
        Sample_Single_Lambda();
        Sample_Union_Lambda();
        Sample_Distinct_Lambda();
        Sample_Max_Lambda();
        Sample_Empty_Lambda();
        Normal_Query_Sample();
        Sample_ToList_Lambda();
    }

    static void Sample_ToList_Lambda()
    {
        string[] names = { "Brenda", "Carl", "Finn" };

        List<string> result = names.ToList();

        Console.WriteLine(String.Format("names is of type: {0}", names.GetType().Name));
        Console.WriteLine(String.Format("result is of type: {0}", result.GetType().Name));
    }
    static void Normal_Query_Sample()
    {
        // Data source
        string[] names = { "Bill", "Steve", "James", "Mohan" };

        // LINQ Query 
        var myLinqQuery = from name in names
                          where name.Contains('a')
                          select name;

        // Query execution
        foreach (var name in myLinqQuery)
            Console.WriteLine(name);
    }
    static void Sample_Empty_Lambda()
    {
        var empty = Enumerable.Empty<string>();
        // To make sequence into an array use empty.ToArray()

        Console.WriteLine("Sequence is empty:");
        Console.WriteLine(empty.Count() == 0);
    }
    static void Sample_Max_Lambda()
    {
        int[] numbers = { 2, 8, 5, 6, 1 };

        var result = numbers.Max();

        Console.WriteLine("Highest number is:");
        Console.WriteLine(result);
    }
    static void Sample_Distinct_Lambda()
    {
        int[] numbers = { 1, 2, 2, 3, 5, 6, 6, 6, 8, 9 };

        var result = numbers.Distinct();

        Console.WriteLine("Distinct removes duplicate elements:");
        foreach (int number in result)
            Console.WriteLine(number);
    }
    static void Sample_Union_Lambda()
    {
        int[] numbers1 = { 1, 2, 3 };
        int[] numbers2 = { 3, 4, 5 };

        var result = numbers1.Union(numbers2);

        Console.WriteLine("Union creates a single sequence and eliminates the duplicates:");
        foreach (int number in result)
            Console.WriteLine(number);
    }

    static void Sample_Single_Lambda()
    {
        string[] names1 = { "Peter" };
        string[] names3 = { "Peter", "Joe", "Wilma" };
        string[] empty = { };

        var result1 = names1.Single();

        Console.WriteLine("The only name in the array is:");
        Console.WriteLine(result1);

        try
        {
            // This will throw an exception because array contains no elements
            var resultEmpty = empty.Single();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            // This will throw an exception as well because array contains more than one element
            var result3 = names3.Single();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    static void Sample_Any_Lambda()
    {
        string[] names = { "Bob", "Ned", "Amy", "Bill" };

        var result = names.Any(n => n.StartsWith("B"));

        Console.WriteLine("Does any of the names start with the letter 'B':");
        Console.WriteLine(result);
    }
    static void Sample_All_Lambda()
    {
        string[] names = { "Bob", "Ned", "Amy", "Bill" };

        var result = names.All(n => n.StartsWith("B"));

        Console.WriteLine("Does all of the names start with the letter 'B':");
        Console.WriteLine(result);
    }
    static void Sample_OfType_Lambda()
    {
        object[] objects = { "Thomas", 31, 5.02, null, "Joey" };

        var result = objects.OfType<string>();

        Console.WriteLine("Objects being of type string have the values:");
        foreach (string str in result)
            Console.WriteLine(str);
    }
    static void Sample_OrderBy_Lambda()
    {
        string[] names = { "Bill", "Steve", "James", "Mohan" };

        var result = names.OrderBy(n => n);

        Console.WriteLine("Names in ascending order:");
        foreach (string name in result)
            Console.WriteLine(name);
    }
    static void Sample_Aggregate_Lambda()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };

        // Bereken de som van alle getallen met behulp van Aggregate
        int sum = numbers.Aggregate((acc, x) => acc + x);
        int sumWithSeed = numbers.Aggregate(0, (acc, x) => acc + x);

        Console.WriteLine($"De som van de getallen is: {sum}");
        Console.WriteLine($"De som van de getallen is: {sumWithSeed}");
    }
}
