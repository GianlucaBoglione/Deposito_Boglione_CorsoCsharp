using System;
using System.Collections.Generic;

//Interfaccia IPiatto
//stringa Descrizione()
//string Prepara() – la preparazione dipenderà dalla strategia scelta
public interface IPiatto
{
    string Descrizione();
    string Prepara();
}
//Classi concrete di piatto base
//Pizza, Hamburger, Insalata
//Restituiscono la descrizione base del piatto

public class Pizza : IPiatto
{
    public string Descrizione()
    {
        return "Pizza";
    }
    public string Prepara()
    {
        return "Preparazoione pizza base.";
    }
}
public class Hamburger : IPiatto
{
    public string Descrizione()
    {
        return "Hamburger";
    }
    public string Prepara()
    {
        return "Preparazoione Hamburger base.";
    }
}
public class Insalata : IPiatto
{
    public string Descrizione()
    {
        return "Insalata";
    }
    public string Prepara()
    {
        return "Preparazoione Insalata base.";
    }
}

//Decoratore: IngredienteExtra (astratta)
//Contiene un IPiatto
//Eredita da IPiatto


public abstract class IngredienteExtra : IPiatto
{
    protected IPiatto piatto;

    public IngredienteExtra(IPiatto _piatto)
    {
        _piatto = piatto;
    }
    public abstract string Descrizione();
    public string Prepara()
    {
        return piatto.Prepara();
    }
}
//Esempi concreti: ConFormaggio, ConBacon, ConSalsa
public class ConFormaggio : IngredienteExtra
{
    public ConFormaggio(IPiatto piatto) : base(piatto) { }

    public override string Descrizione()
    {
        return piatto.Descrizione() + " con formaggio";
    } 
}
public class ConBacon : IngredienteExtra
{
    public ConBacon(IPiatto piatto) : base(piatto) { }

    public override string Descrizione()
    {
        return piatto.Descrizione() + " con Bacon";
    } 
}
public class ConSalsa : IngredienteExtra
{
    public ConSalsa(IPiatto piatto) : base(piatto) { }

    public override string Descrizione()
    {
        return piatto.Descrizione() + " con Salsa";
    } 
}



//Factory PiattoFactory (statica)
//Metodo: IPiatto Crea(string tipo)
//Crea piatti base in base all'input

public static class PiattoFactory
{
    public static IPiatto Crea(string tipo)
    {
        if (tipo == "pizza")
        {
            return new Pizza();
        }

        else if (tipo == "hamburger")
        {
            return new Hamburger();
        }

        else if (tipo == "insalata")
        {
            return new Insalata();
        }

        else
        {
            throw new ArgumentException("Tipo di piatto non valido.");
        }

    }
}


//Strategy: Interfaccia IPreparazioneStrategia
//Metodo: string Prepara(string descrizione)
//Strategie concrete: Fritto, AlForno, AllaGriglia
//Implementano metodi personalizzati di preparazione

public interface IPreparazioneStrategia
{
    string Prepara(string descrizione);
}
public class Fritto : IPreparazioneStrategia
{
    public string Prepara(string descrizione)
    {
        return $"{descrizione} sarà fritto.";
    }
}
public class AlForno : IPreparazioneStrategia
{
    public string Prepara(string descrizione)
    {
        return $"{descrizione} sarà al forno.";
    }
}
public class AllaGriglia : IPreparazioneStrategia
{
    public string Prepara(string descrizione)
    {
        return $"{descrizione} sarà alla griglia.";
    }
}


//Classe Chef Contiene un campo IPreparazioneStrategia
//Metodo PreparaPiatto(IPiatto) che delega la preparazione alla strategia

public class Chef
{
    private IPreparazioneStrategia _strategia;

    public void ImpostaStrategia(IPreparazioneStrategia strategia)
    {
        _strategia = strategia;
    }

    public string PreparaPiatto(IPiatto piatto)
    {
        return _strategia.Prepara(piatto.Descrizione());
    }
}
//Main:
//L'utente seleziona il tipo di piatto → viene creato dalla Factory
//L'utente aggiunge 0 o più ingredienti extra → tramite Decorator
//L'utente seleziona il tipo di cottura → viene applicata tramite Strategy
//Viene mostrata: la descrizione completa del piatto e la modalità di preparazione
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("scegli un piatto tra: Pizza, Hamburger, Insalata");
        string tipo = Console.ReadLine();
        IPiatto piatto = PiattoFactory.Crea(tipo);


        Console.WriteLine("\nVuoi aggiungere un ingrediente?");
        Console.WriteLine("1. Formaggio");
        Console.WriteLine("2. Bacon");
        Console.WriteLine("3. Salsa");
        string scelta = Console.ReadLine();
        switch (scelta)
        {
            case "1":
                piatto = new ConFormaggio(piatto);
                break;
            case "2":
                piatto = new ConBacon(piatto);
                break;
            case "3":
                piatto = new ConSalsa(piatto);
                break;
            default:
                Console.WriteLine("Scelta non valida.");
                break;
        }
        Console.WriteLine("\nScegli metodo di cottura:");
        Console.WriteLine("1. Fritto\n2. Al forno\n3. Alla griglia");
        string metodo = Console.ReadLine();

        Chef chef = new Chef();
        switch (metodo)
        {
            case "1": chef.ImpostaStrategia(new Fritto()); break;
            case "2": chef.ImpostaStrategia(new AlForno()); break;
            case "3": chef.ImpostaStrategia(new AllaGriglia()); break;
            default:
                Console.WriteLine("Metodo non valido");
                return;
        }

        Console.WriteLine("\nOrdine completo:");
        Console.WriteLine("Piatto: " + piatto.Descrizione());
        Console.WriteLine("Preparazione: " + chef.PreparaPiatto(piatto));

    }
}




















