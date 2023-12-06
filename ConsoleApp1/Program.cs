// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler
namespace ConsoleApp1;
using System;
using System.Collections.Generic;

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
    public string? Naam;
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
    public static void Main(string[] args)
    {
        //Methode1();
        //Methode2();
        Methode3();
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
}