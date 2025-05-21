using System;

public class Animale
{
    public void FaiVerso()
    {
        Console.WriteLine("L'animale fa un verso");
    }
}
public class Cane : Animale
{
    public void Scodinzola()
    {
        Console.WriteLine("Il cane scondinzola");
    }
}
public class Programma
{
    public static void Main(string[] args)
    {
        Cane mioCane = new Cane();
        mioCane.FaiVerso();
        mioCane.Scodinzola();
    }
}