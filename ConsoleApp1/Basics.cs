namespace ConsoleApp1;

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