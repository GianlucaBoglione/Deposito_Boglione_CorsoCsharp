using System;
using System.Collections.Generic;

//Interfaccia ITorta Metodo string Descrizione()
public interface ITorta
{
    string Descrizione();
}
//Classi concrete (base torta):
//TortaCioccolato → descrizione: "Torta al cioccolato"
//TortaVaniglia → descrizione: "Torta alla vaniglia"
//TortaFrutta → descrizione: "Torta alla frutta"
public class TortaCioccolato : ITorta
{
    public string Descrizione()
    {
        return "Torta al cioccolato";
    }
}
public class TortaVaniglia : ITorta
{
    public string Descrizione()
    {
        return "Torta alla vaniglia";
    }
}
public class TortaFrutta : ITorta
{
    public string Descrizione()
    {
        return "Torta alla frutta";
    }
}

//Classe astratta DecoratoreTorta
//Implementa ITorta
//Contiene un campo protetto ITorta baseTorta
//Metodo Descrizione() che viene sovrascritto nei decoratori
public abstract class DecoratoreTorta : ITorta
{
    protected ITorta tortaBase;

    public DecoratoreTorta(ITorta torta)
    {
        tortaBase = torta;
    }
    public abstract string Descrizione();

}

//Decoratori concreti:
//ConPanna, ConFragole, ConGlassa
//Ogni decoratore aggiunge un ingrediente alla descrizione:
//Esempio: "Torta alla vaniglia + panna + fragole"
public class ConPanna : DecoratoreTorta
{
    public ConPanna(ITorta torta) : base(torta) { }

    public override string Descrizione()
    {
        return tortaBase.Descrizione() + " con panna";
    }
}
public class ConFragole : DecoratoreTorta
{
    public ConFragole(ITorta torta) : base(torta) { }

    public override string Descrizione()
    {
        return tortaBase.Descrizione() + " con fragole";
    }
}
public class ConGlassa : DecoratoreTorta

{
    public ConGlassa(ITorta torta) : base(torta) { }

    public override string Descrizione()
    {
        return tortaBase.Descrizione() + " con glassa";
    }
}

//Classe statica TortaFactory
//Metodo: ITorta CreaTortaBase(string tipo)
//"cioccolato" → nuovo TortaCioccolato()
//"vaniglia" → nuovo TortaVaniglia()
//"frutta" → nuovo TortaFrutta()

public static class TortaFactory
{
    public static ITorta CreaTortaBase(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "cioccolato":
                return new TortaCioccolato();
            case "TortaVaniglia":
                return new TortaVaniglia();
            case "TortaFrutta":
                return new TortaFrutta();
            default:
                throw new ArgumentException("Tipo di torta non valido");
        }
    }
}

//Nel Main:L'utente sceglie una torta base (usando la Factory)
//Poi può aggiungere uno o più ingredienti extra (es. panna, glassa)
//Alla fine viene mostrata la descrizione completa con tutti gli ingredienti aggiunti

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Scelgi una base tra: cioccolato, vaniglia, frutta");
        string tipo = Console.ReadLine();

        ITorta torta = TortaFactory.CreaTortaBase(tipo);

        Console.WriteLine("Scelgi una aggiunta extra (panna, fragole, glassa)");
        string aggiunta = Console.ReadLine();

        switch (aggiunta)
        {
            case "panna":
                torta = new ConPanna(torta);
                break;
            case "fragole":
                torta = new ConFragole(torta);
                break;
            case "glassa":
                torta = new ConGlassa(torta);
                break;
            default:
                Console.WriteLine("scelta non valida.");
                break;
        }
        Console.WriteLine("torta con modifiche: " + torta.Descrizione());
    }
}