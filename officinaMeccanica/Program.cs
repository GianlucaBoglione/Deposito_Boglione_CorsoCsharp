using System;
using Microsoft.Win32.SafeHandles;
public class Veicolo                    // Classe Base Veicolo
{
    public string Targa { get; set; }

    public Veicolo(string targa)
    {
        this.Targa = targa;
    }

    public virtual void Ripara()
    {
        Console.WriteLine($"Controllo sul veicolo targato {Targa}: eseguito.");
    }
}

public class Auto : Veicolo             // classe Auto
{
    public Auto(string targa) : base(targa)     // costruttore implementa targa
    { 
        this.Targa = targa;
    }

    public override void Ripara()               // override del metodo 'virtual Ripara' della classe Base
    {
        Console.WriteLine($"Auto targata: {Targa}, eseguito il controllo olio, freni e motore.");
    }
}

public class Moto : Veicolo
{

    public Moto(string targa) : base(targa)     // costruttore implementa targa
    {
        this.Targa = targa;
    }
    public override void Ripara()               // override del metodo 'virtual Ripara' della classe Base
    {
        Console.WriteLine($"Moto targta: {Targa}, eseguito il controllo olio, freni e motore.");
    }
}
public class Camion : Veicolo
{

    public Camion(string targa) : base(targa)       // costruttore implementa targa
    {
        this.Targa = targa;
    }

    public override void Ripara()               // override del metodo 'virtual Ripara' della classe Base
    {
        Console.WriteLine($"Camion targato {Targa}, eseguito il Controllo sospensioni, freni rinforzati e carico del camion.");
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        List<Veicolo> veicoli = new List<Veicolo>();        // creazione lista per i veicoli

        int scelta;

        do
        {
            Console.WriteLine("Gestione Officina");
            Console.Write("Scegli un'opzione: ");
            Console.WriteLine("1. Inserisci Auto");
            Console.WriteLine("2. Inserisci Moto");
            Console.WriteLine("3. Inserisci Camion");
            Console.WriteLine("4. Richiesta riparazioni");
            Console.WriteLine("5. Esci");
            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.Write("Inserisci targa auto: ");
                    string targaAuto = Console.ReadLine();
                    veicoli.Add(new Auto(targaAuto));
                    break;
                case 2:
                    Console.Write("Inserisci targa moto: ");
                    string targaMoto = Console.ReadLine();
                    veicoli.Add(new Auto(targaMoto));
                    break;
                case 3:
                    Console.Write("Inserisci targa camion: ");
                    string targaCamion = Console.ReadLine();
                    veicoli.Add(new Auto(targaCamion));
                    break;
                case 4:
                    Console.WriteLine("Riparazioni: ");
                    foreach (Veicolo veicolo in veicoli)
                    {
                        veicolo.Ripara();
                        Console.WriteLine("Controllo e Riparazioni eseguite.");
                    }
                    break;
                case 5:
                    Console.WriteLine("Arrivederci e grazie della visita.");
                    break;
                default:
                    Console.Write("Errore scelta non valida ");
                    break;
            }
        } while (scelta != 0);
    }
}





