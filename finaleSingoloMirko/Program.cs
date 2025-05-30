using System;
using System.Collections.Generic;

//Interfaccia IPizza

public interface IPizza
{
    string Descrizione();
    decimal Costo();
}
//Pizze base (Factory Pattern)
public class Margherita : IPizza
{
    public string Descrizione() 
    {
        return "Margherita";
    }
    public decimal Costo()
    {
        return 5.00m;
    }
}

public class Diavola : IPizza
{
    public string Descrizione()
    {
        return "Diavola";
    }
    public decimal Costo() 
    {
        return 6.50m;
    }
}

public class Vegetariana : IPizza
{
    public string Descrizione() 
    {
        return "Vegetariana";
    }
    public decimal Costo()
    {
        return 6.00m;
    }
}


//PizzaFactory (statica)
public static class PizzaFactory
{
    public static IPizza CreaPizza(string tipo)
    {

        switch (tipo)
        {
            case "margherita":
                return new Margherita();
            case "diavola":
                return new Diavola();
            case "vegetariana":
                return new Vegetariana();
            default:
                Console.WriteLine("Tipo non riconosciuto.");
                return null;
        }

    }
}


//Decorator Pattern - Ingredienti Extra
public abstract class IngredienteDecoratore : IPizza
{
    protected IPizza _pizza;
    public IngredienteDecoratore(IPizza pizza)
    {
        _pizza = pizza;
    }


    public abstract string Descrizione();
    public abstract decimal Costo();
}


//Decoratori Concreti
public class ConOlive : IngredienteDecoratore
{
    public ConOlive(IPizza pizza) : base(pizza) { }

    public override string Descrizione()
    {
        return _pizza.Descrizione() + " con Olive";
    }
    public override decimal Costo()
    {
        return _pizza.Costo() + 0.50m;
    }
}

public class ConMozzarellaExtra : IngredienteDecoratore
{
    public ConMozzarellaExtra(IPizza pizza) : base(pizza) { }

    public override string Descrizione() => _pizza.Descrizione() + " con Mozzarella Extra";
    public override decimal Costo() => _pizza.Costo() + 0.75m;
}

public class ConFunghi : IngredienteDecoratore
{
    public ConFunghi(IPizza pizza) : base(pizza) { }

    public override string Descrizione() 
    {
        return _pizza.Descrizione() + " con Funghi";
    }
    public override decimal Costo()
    {
        return _pizza.Costo() + 0.60m;
    }
}



//Strategy Pattern - Metodo di Cottura
public interface IMetodoCottura
{
    string Cuoci(string pizza);
}


//Strategie Concret
public class FornoElettrico : IMetodoCottura
{
    public string Cuoci(string pizza)  
    {
        return $"Pizza '{pizza}' cotta in forno elettrico.";
    }
}

public class FornoLegna : IMetodoCottura
{
    public string Cuoci(string pizza)  
    {
        return $"Pizza '{pizza}' cotta in forno a legna.";
    }
}

public class FornoVentilato : IMetodoCottura
{
    public string Cuoci(string pizza)  
    {
        return $"Pizza '{pizza}' cotta in forno ventilato.";
    }
}
//Singleton Pattern - Gestione Ordine

public class GestioneOrdine
{
    private static GestioneOrdine _istanza;
    //private static readonly object _lock = new();
    private List<IPizza> _ordini = new();

    private List<IObserverOrdine> _osservatori = new();

    private GestioneOrdine() { }

    public static GestioneOrdine Istanza
    {
        get
        {
            return _istanza = new GestioneOrdine();
        }
    }

    public void AggiungiOrdine(IPizza pizza)
    {
        _ordini.Add(pizza);
        NotificaOsservatori(pizza);
    }

    public void RegistraOsservatore(IObserverOrdine osservatore)
    {
        _osservatori.Add(osservatore);
    }

    private void NotificaOsservatori(IPizza pizza)
    {
        foreach (var osservatore in _osservatori)
        {
            osservatore.Aggiorna(pizza);
        }
    }

    public void StampaOrdini()
    {
        foreach (var pizza in _ordini)
        {
            Console.WriteLine($"Pizza: {pizza.Descrizione()}, Costo: {pizza.Costo()}");
        }
    }
}


//Interfaccia Osservatore

public interface IObserverOrdine
{
    void Aggiorna(IPizza pizza);
}
//Osservatori Concreti

public class SistemLog : IObserverOrdine
{
    public void Aggiorna(IPizza pizza)
    {
        Console.WriteLine($"Nuova pizza creata: {pizza.Descrizione()}, Costo: {pizza.Costo()}");
    }
}

public class SistemMarketing : IObserverOrdine
{
    public void Aggiorna(IPizza pizza)
    {
        Console.WriteLine($"Invia promozione per: {pizza.Descrizione()}");
    }
}


class Program
{
    static void Main(string[] args)
    {

        var gestioneOrdine = GestioneOrdine.Istanza;
        gestioneOrdine.RegistraOsservatore(new SistemLog());
        gestioneOrdine.RegistraOsservatore(new SistemMarketing());
      
        IPizza pizza = PizzaFactory.CreaPizza("Diavola");
      
        pizza = new ConOlive(pizza);
        pizza = new ConMozzarellaExtra(pizza);
        
        IMetodoCottura metodoCottura = new FornoLegna();
        Console.WriteLine(metodoCottura.Cuoci(pizza.Descrizione()));
        Console.WriteLine("...................................................");
        gestioneOrdine.AggiungiOrdine(pizza);
        Console.WriteLine("...................................................");
        gestioneOrdine.StampaOrdini();
    }
}


