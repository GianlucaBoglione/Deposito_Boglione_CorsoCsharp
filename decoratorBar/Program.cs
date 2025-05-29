using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

//Interfaccia IBevanda Metodo string Descrizione() Metodo double Costo()

public interface IBevanda
{
    string Descrizione();
    double Costo();

}

//Classi concrete (bevande base): Caffè Tè
//Entrambe implementano IBevanda
//Restituiscono una descrizione e un costo base

public class Caffè : IBevanda
{
    public string Descrizione()
    {
        return "caffè";
    }
    public double Costo()
    {
        return 1.00;
    }
}
public class Tè : IBevanda
{
    public string Descrizione()
    {
        return "tè";
    }
    public double Costo()
    {
        return 1.00;
    }
}

//Classe astratta DecoratoreBevanda Implementa IBevanda
//Contiene un campo protetto di tipo IBevanda (componente da decorare)
//Costruttore: riceve una bevanda da decorare

public abstract class DecoratoreBevanda : IBevanda
{
    protected IBevanda bevanda;

    public DecoratoreBevanda(IBevanda bevanda)
    {
        this.bevanda = bevanda;
    }

    public abstract string Descrizione();
    public abstract double Costo();
}

//Classi concrete decoratrici: ConLatte, ConCioccolato, ConPanna, whiskey
//Ognuna aggiunge descrizione e costo specifico alla bevanda decorata

public class ConLatte : DecoratoreBevanda
{
    public ConLatte(IBevanda bevanda) : base(bevanda) { }

    public override string Descrizione()
    {
        return bevanda.Descrizione() + "con latte";
    }
    public override double Costo()
    {
        return bevanda.Costo() + 0.40;
    }
}
public class ConCioccolato : DecoratoreBevanda
{
    public ConCioccolato(IBevanda bevanda) : base(bevanda) { }

    public override string Descrizione()
    {
        return bevanda.Descrizione() + " + cioccolato";
    }
    public override double Costo()
    {
        return bevanda.Costo() + 0.80;
    }
}
public class ConPanna : DecoratoreBevanda
{
    public ConPanna(IBevanda bevanda) : base(bevanda) { }

    public override string Descrizione()
    {
        return bevanda.Descrizione() + " + panna";
    }
    public override double Costo()
    {
        return bevanda.Costo() + 0.50;
    }
}//whiskey
public class ConWhiskey : DecoratoreBevanda
{
    public ConWhiskey(IBevanda bevanda) : base(bevanda) { }

    public override string Descrizione()
    {
        return bevanda.Descrizione() + " + whiskey";
    }
    public override double Costo()
    {
        return bevanda.Costo() + 1.00;
    }
}

//Nel Main:Crea una bevanda di base (es. Caffè)
//Applica dinamicamente una o più decorazioni
//Stampa descrizione completa e costo totale

public class Program
{
    public static void Main(string[] args)
    {
        //Bevanda di base
        IBevanda bevandaBase = new Caffè();

        bevandaBase = new ConWhiskey(bevandaBase);
        bevandaBase = new ConPanna(bevandaBase);

        Console.WriteLine($"Descrizione: {bevandaBase.Descrizione()}");
        Console.WriteLine($"Costo totale euro: {bevandaBase.Costo()} ");  //.ToString("F2")

    }
}



































