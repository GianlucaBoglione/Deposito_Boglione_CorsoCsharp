using System;
using System.Collections;

class Veicolo
{
    protected string Marca;
    protected string Modello;

    public Veicolo(string marca, string modello)
    {
        Marca = marca;
        Modello = modello;
    }

    public virtual void StampaInfo()
    {
        Console.WriteLine($"[Auto] marca: {Marca}, modello: {Modello}  ");
    }
}
class Auto : Veicolo
{
    public int NumeroPorte;

    public Auto(string marca, string modello, int numeroPorte) : base(marca, modello)
    {
        NumeroPorte = numeroPorte;
    }
}
class Moto : Veicolo
{
    public string TipoManubrio;

    public Moto(string marca, string modello, string tipoManubrio) : base(marca, modello)
    {
        TipoManubrio = tipoManubrio;
    }
    public override void StampaInfo()
    {
        Console.WriteLine($"[Moto] marca: {Marca}, modello: {Modello}, tipo di manubrio: {TipoManubrio} ");
    }
}



public class Programma
{
    public static void Main(string[] args)
    {
        List<Veicolo> garage = new List<Veicolo>();
        bool esci = false;

        while (!esci)
        {
            Console.WriteLine("Benvenuto.");
            Console.WriteLine("1.Inserisci un nuovo veicolo:");
            Console.WriteLine("2.Visualizza veicoli.");
            Console.WriteLine("3. Esci");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    InserisciVeicolo(garage);
                    break;

                case "2":
                    VisualizzaVeicoli(garage);
                    break;

                case "3":
                    esci = true;
                    break;

                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }

        }
        Console.WriteLine("Programma terminato.");

    }


    static void InserisciVeicolo(List<Veicolo> garage)
    {
        Console.WriteLine("Benvenuto.");
        Console.WriteLine("inserisci un veicolo: ");
        Console.WriteLine("1. Auto");
        Console.WriteLine("2. Moto");
        Console.WriteLine("3. Esci");
        Console.WriteLine("Scelta: ");
        string tipo = Console.ReadLine();

        Console.WriteLine("Marca: ");
        string marca = Console.ReadLine();

        Console.WriteLine("Modello: ");
        string modello = Console.ReadLine();


        if (tipo == "1")
        {
            Console.WriteLine("inserisci il numero di porte: ");
            int numeroPorte = int.Parse(Console.ReadLine());

            Auto nuovaAuto = new Auto(marca, modello, numeroPorte);
            garage.Add(nuovaAuto);
            Console.WriteLine("Auto aggiunta al garage.");
        }
        else if (tipo == "2")
        {
            Console.WriteLine("inserisci il tipo di manubrio: ");
            string tipoManubrio = Console.ReadLine();

            Moto nuovaMoto = new Moto(marca, modello, tipoManubrio);
            garage.Add(nuovaMoto);
        }
        else
        {
            Console.WriteLine("Scelta non  valida");
        }
    }
    static void VisualizzaVeicoli(List<Veicolo> garage)
    {
        Console.WriteLine("Veicoli nel garage");
        if (garage.Count == 0)
        {
            Console.WriteLine("garage vuoto.");
            return;
        }
        foreach (var veicolo in garage)
        {
            veicolo.StampaInfo();
        }

    }


}



