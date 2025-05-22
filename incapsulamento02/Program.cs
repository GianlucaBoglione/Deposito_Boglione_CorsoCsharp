using System;
using System.Collections.Generic;

public class PrenotazioneViaggio
{
    private int postiPrenotati = 0;
    public const int maxPosti = 20;

    public string Destinazione{ get; set; }
    //{
        //get { return Destinazione; }
        //set { Destinazione = value; }                 // Questo mi dava problemi ho scritto male o ho scritto una cavolata?
    //}
    public int PostiPrenotati
    {
        get { return postiPrenotati; }
    }
    public int PostiDisponibili
    {
        get { return maxPosti - postiPrenotati; }
    }

    public bool PrenotaPosti(int numeroDiPosti)
    {
        if (PostiDisponibili >= 0)
        {
            postiPrenotati += numeroDiPosti;
            Console.WriteLine($"Prenotati {numeroDiPosti} posti per {Destinazione}. Posti disponibili rimanenti: {PostiDisponibili}");
            return true;
        }
        else
        {
            Console.WriteLine($"Impossibile prenotare {numeroDiPosti} posti per {Destinazione}. Solo {PostiDisponibili} posti disponibili.");
            return false;
        }
    }
    public bool AnnullaPrenotazione(int numeroDiPosti)
    {
        if (numeroDiPosti <= 0)
        {
            Console.WriteLine($"Errore: Il numero di posti da annullare deve essere maggiore di zero. {numeroDiPosti}.");
            return false;
        }

        if (postiPrenotati >= numeroDiPosti)
        {
            postiPrenotati -= numeroDiPosti;
            Console.WriteLine($"Annullati {numeroDiPosti} posti per {Destinazione}. Posti disponibili rimanenti: {PostiDisponibili}");
            return true;
        }
        else
        {
            Console.WriteLine($"Impossibile annullare {numeroDiPosti} posti per {Destinazione}. Ci sono solo {postiPrenotati} posti prenotati.");
            return false;
        }
    }
    public void StampaStato()
    {
        Console.WriteLine($"Stato Prenotazione Viaggio:");
        Console.WriteLine($"Destinazione: {Destinazione}");
        Console.WriteLine($"Posti totali: {maxPosti}");
        Console.WriteLine($"Posti prenotati: {postiPrenotati}");
        Console.WriteLine($"Posti disponibili: {PostiDisponibili}");
    }

}

public class Programma
{
    public static void Main(string[] args)
    {
        PrenotazioneViaggio mioViaggio = new PrenotazioneViaggio();
        
        Console.Write("Inserisci la destinazione del viaggio: ");
        mioViaggio.Destinazione = Console.ReadLine();

        mioViaggio.PrenotaPosti(5);
        mioViaggio.AnnullaPrenotazione(3);
        mioViaggio.StampaStato();
        Console.ReadKey();
    }

}





/*



class Program
{
    public static void Main(string[] args)
    {
        int a = 10;
        int b = 22;
        int somma = a + b;
        Console.WriteLine(somma);
    }
}*/