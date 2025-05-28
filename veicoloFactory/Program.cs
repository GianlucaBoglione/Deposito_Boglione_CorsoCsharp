using System;

public interface IVeicolo
{
    void Avvia();
    void MostraTipo();
}
public class Auto : IVeicolo
{
    public void Avvia()
    {
        Console.WriteLine("L'auto è stata avviata ");
    }
    public void MostraTipo()
    {
        Console.WriteLine($"Tipo di veicolo: {GetType()}");
    }
}
public class Moto : IVeicolo
{
    public void Avvia()
    {
        Console.WriteLine("La moto è stata avviata ");
    }
    public void MostraTipo()
    {
        Console.WriteLine($"Tipo di veicolo: {GetType()}");
    }
}
public class Camion : IVeicolo

{
    public void Avvia()
    {
        Console.WriteLine("Il camion è stato avviato ");
    }
    public void MostraTipo()
    {
        Console.WriteLine($"Tipo di veicolo: {GetType()}");
    }
}
public static class VeicoloFactory
{
    public static IVeicolo CreateVeicolo(string tipo)
    {
        switch (tipo)        // (tipo.toLower)
        {
            case "auto":
                return new Auto();
            case "moto":
                return new Moto();
            case "camion":
                return new Camion();
            default:
                return null;
        }
    }
}


public sealed class RegistroVeicoli
{
    private static RegistroVeicoli istanza;
    private List<IVeicolo> veicoliCreati = new List<IVeicolo>();

    private RegistroVeicoli()
    {
        veicoliCreati = new List<IVeicolo>();    
    }

    public RegistroVeicoli Istanza
    {
        get
        {
            if (istanza == null)
            {
                istanza = new RegistroVeicoli();
            }
            return istanza;
        }
    }

/*
public class RegistroVeicoli
{
    private static RegistroVeicoli istanza;
    private List<IVeicolo> veicoli;

    private RegistroVeicoli()
    {
        veicoli = new List<IVeicolo>();
    }

    public static RegistroVeicoli Instance
    {
        get
        {
            if (istanza == null)
                istanza = new RegistroVeicoli();
            return istanza;
        }
    }

    public void Registra(IVeicolo veicolo)
    {
        if (veicolo != null)
        {
            veicoli.Add(veicolo);
            Console.WriteLine("Veicolo registrato nel sistema.");
        }
    }
*/




















    public void Registra(IVeicolo veicolo)
    {
        veicoliCreati.Add(veicolo);
    }
    public void StampaTutti()
    {
        foreach (var veicolo in veicoliCreati)
        {
            Console.WriteLine(veicolo);
            veicolo.MostraTipo();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Scegli un veicolo: ");
        Console.WriteLine("[Auto]");
        Console.WriteLine("[Moto]");
        Console.WriteLine("[Camion]");
        string scelta = Console.ReadLine().ToLower();

        IVeicolo veicolo = VeicoloFactory.CreateVeicolo(scelta);

        veicolo.Avvia();
        veicolo.MostraTipo();
    
        RegistroVeicoli
    }
}















/*
using System;
using System.Collections.Generic;

// Interfaccia comune
public interface IVeicolo
{
    void Avvia();
    void MostraTipo();
}

// Classi concrete
public class Auto : IVeicolo
{
    public void Avvia() => Console.WriteLine("Avvio dell'auto");
    public void MostraTipo() => Console.WriteLine("Tipo: Auto");
}

public class Moto : IVeicolo
{
    public void Avvia() => Console.WriteLine("Avvio della moto");
    public void MostraTipo() => Console.WriteLine("Tipo: Moto");
}

public class Camion : IVeicolo
{
    public void Avvia() => Console.WriteLine("Avvio del camion");
    public void MostraTipo() => Console.WriteLine("Tipo: Camion");
}

// Factory per creare veicoli
public static class VeicoloFactory
{
    public static IVeicolo CreaVeicolo(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "auto": return new Auto();
            case "moto": return new Moto();
            case "camion": return new Camion();
            default:
                Console.WriteLine("Tipo non riconosciuto.");
                return null;
        }
    }
}

// Singleton per registrare veicoli
public class RegistroVeicoli
{
    private static RegistroVeicoli istanza;
    private List<IVeicolo> veicoli;

    private RegistroVeicoli()
    {
        veicoli = new List<IVeicolo>();
    }

    public static RegistroVeicoli Instance
    {
        get
        {
            if (istanza == null)
                istanza = new RegistroVeicoli();
            return istanza;
        }
    }

    public void Registra(IVeicolo veicolo)
    {
        if (veicolo != null)
        {
            veicoli.Add(veicolo);
            Console.WriteLine("Veicolo registrato nel sistema.");
        }
    }

    public void StampaTutti()
    {
        Console.WriteLine("\n--- VEICOLI REGISTRATI ---");
        foreach (var v in veicoli)
        {
            v.MostraTipo();
        }
    }
}

public class Program
{
    public static void Main()
    {
        bool continua = true;
        while (continua)
        {
            Console.WriteLine("\n1. Crea veicolo\n2. Mostra veicoli registrati\n0. Esci");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Write("Inserisci tipo veicolo (auto, moto, camion): ");
                    string tipo = Console.ReadLine();
                    IVeicolo nuovoVeicolo = VeicoloFactory.CreaVeicolo(tipo);
                    if (nuovoVeicolo != null)
                    {
                        nuovoVeicolo.Avvia();
                        RegistroVeicoli.Instance.Registra(nuovoVeicolo);
                    }
                    break;
                case "2":
                    RegistroVeicoli.Instance.StampaTutti();
                    break;
                case "0":
                    continua = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }

        Console.WriteLine("Programma terminato.");
    }
}
*/