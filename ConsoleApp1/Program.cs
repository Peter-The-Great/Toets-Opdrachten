// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
namespace ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;

//Extension Method Gewicht
//Lijst van Dieren en een apartelijst van zoogdieren
//krokodile

/**
 * Contra en covariance worden hier besproken
 * 
 * Specifiek hier is covariance.
 */
class Dier
{
    public string Naam;
    public int Gewicht = 0;
}

class Zoogdier : Dier { }

class Reptiel : Dier { }

class Krokodil : Reptiel { }

/**
 * * Hier wordt contravariance besproken
 * */
delegate void MyDelegate(Reptiel m);

/*
 * Dit is voor generics
 */
class Vogel<T, S>(T naam, S gewicht, S leeftijd)
{
    public T Naam { get; set; } = naam;
    public S Gewicht { get; set; } = gewicht;
    public S Leeftijd { get; set; } = leeftijd;

}

class Program
{
    public static async Task Main(string[] args)
    {
        //Methode1();
        //Methode2();
        //Methode3();
        //await Methode4Async();
        Methode5();
    }
    static void Method(Reptiel a)
    {
        Console.WriteLine("Type van deze class is: " + a.GetType());
    }

    static void Methode1()
    {
        Vogel<string, int> vogel = new Vogel<string, int>("Piet", 10, 5);

        List<Dier> dieren = new List<Dier>();
        List<Zoogdier> zoogdieren = new List<Zoogdier>();
        dieren.Add(new Zoogdier());
        dieren.Add(new Krokodil());
        zoogdieren.Add(new Zoogdier());
        Console.WriteLine(dieren[0].Gewicht);
        if (zoogdieren.Count > 0)
        {
            Console.WriteLine(zoogdieren[0].GetType());
        }
        Console.WriteLine("Vogel " + vogel.Naam + " is " + vogel.Leeftijd + " jaar oud.");

        //Contravariance
        MyDelegate del = new MyDelegate(Method);
        del(new Krokodil());

        Console.WriteLine();
    }
    static void Methode2()
    {
        Car auto = new Car(new GasolineEngine());
        auto.Start();
        Console.WriteLine();
    }
    static void Methode3()
    {

        Vector a = new Vector { X = 1, Y = 2 };
        Vector b = new Vector { X = 3, Y = 4 };
        Vector c = a / b;
        Console.WriteLine(c.X);
        Console.WriteLine();
    }

    static async Task Methode4Async()
    {

        Task task1 = Bericht1();
        Task task2 = Bericht2();
        //await Bericht1();
        //await Bericht2();
        await Task.WhenAll(task1, task2);
    }
    static async Task Bericht1()
    {
        Console.WriteLine("In bericht 1");
        await Task.Delay(2000);
        Console.WriteLine("In bericht 1 klaar");
    }

    static async Task Bericht2()
    {
        Console.WriteLine("In bericht 2");
        await Task.Delay(2000);
        Console.WriteLine("In bericht 2 klaar");
    }

    static void Methode5()
    {
        //Dit is een voorbeeld van empty sequence
        var empty = Enumerable.Empty<string>();
        // To make sequence into an array use empty.ToArray()
        bool stuff = empty.Count() == 0;
        Console.WriteLine("Sequence is empty: " + stuff);

        //Dit is een voorbeeld van Max
        int[] numbers = { 2, 8, 5, 6, 1 };

        var result = numbers.Max();

        Console.WriteLine("Highest number is: " + result);

        //Dit is een voorbeeld van Min
        int[] numbers2 = { 2, 8, 5, 6, 1 };

        var result2 = numbers2.Min();
        Console.WriteLine("Lowest number is: " + result2);

        //Dit is een voorbeeld van Last
        int[] numbers3 = { 7, 3, 5 };

        var result3 = numbers3.Last();

        Console.WriteLine("Last number in array is: " + result3);
    }
}