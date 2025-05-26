using System;
using System.Collections.Generic;

public abstract class DispositivoElettronico
{
    private string _modello; // Corretto il nome del campo privato per evitare conflitti

    public string Modello { get; set; }

    // Costruttore della classe base
    public DispositivoElettronico(string modello)
    {
        Modello = modello;
    }

    // Metodi astratti che devono essere implementati dalle classi derivate
    public abstract void Accendi();
    public abstract void Spegni();
    public virtual void MostraInfo()
    {
        Console.WriteLine($"Modello: {Modello}");
    }
}
public class Computer : DispositivoElettronico
{
    public Computer(string modello) : base(modello) { }

// metodo implementato 
    public override void Accendi()
    {
        Console.WriteLine("Il computer si avvia.....");
    }
    // metodo implementato 
    public override void Spegni()
    {
        Console.WriteLine("Il computer si spenge");
    }
    public override void MostraInfo()
    {
        Console.WriteLine($"Modello: {Modello}");
    }
}

public class Stampante : DispositivoElettronico
{
    public Stampante(string modello) : base(modello) { }
    
    // metodo implementato 
    public override void Accendi()
    {
        Console.WriteLine("La stampante si accende.");
    }
    // metodo implementato 
    public override void Spegni()
    {
        Console.WriteLine("La stampante va in standby");
    }
    public override void MostraInfo()
    {
        Console.WriteLine($"Modello: {Modello}");
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        List<DispositivoElettronico> dispElettronico = new List<DispositivoElettronico>();

        bool continua = true;
        // inizio menu 
        while (continua)
        {
            Console.WriteLine("Scegli una delle opzioni: ");
            Console.WriteLine("[1] Aggiungi computer");
            Console.WriteLine("[2] Aggiungi Stampante");
            Console.WriteLine("[3] Mostra informazioni");
            Console.WriteLine("[4] Esci");

            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci il modello del computer: ");
                    string modelloC = Console.ReadLine();
                    dispElettronico.Add(new Computer(modelloC));
                    break;
                case 2:
                    Console.WriteLine("Inserisci il modello della stampante: ");
                    string modelloS = Console.ReadLine();
                    dispElettronico.Add(new Stampante(modelloS));
                    break;
                case 3:
                    foreach (DispositivoElettronico dispositivo in dispElettronico)
                    {
                        dispositivo.MostraInfo();
                        dispositivo.Accendi();
                        dispositivo.Spegni();
                    }
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Scelta non valida ");
                    break;
            }
        }
    }
}

