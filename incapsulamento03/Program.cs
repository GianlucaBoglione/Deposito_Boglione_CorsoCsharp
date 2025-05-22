using System;
using System.Security.Cryptography.X509Certificates;

public class VoloAereo
{
    private const int maxPosti = 150;
    private int postiOccupati;

    public string CodiceVolo { get; set; }

    public int PostiOccupati
    {
        get { return postiOccupati; }
    }
    public int postiLiberi
    {
        get { return maxPosti - postiOccupati; }
    }

    public void EffettuaPrenotazione(int numeroPosti)
    {
        if (numeroPosti <= postiLiberi && numeroPosti > 0)
        {
            postiOccupati += numeroPosti;
            Console.WriteLine($"posti disponibili: {postiOccupati}");
        }
        else
        {
            Console.WriteLine("operazione non corretta");
        }
    }
        public void AnnullaPrenotazione(int numeroPosti)
        {
            if (numeroPosti <= postiOccupati && numeroPosti > 0)
            {
                postiOccupati -= numeroPosti;
                Console.WriteLine($"Annullati; {postiOccupati} posti liberi: {postiLiberi}");
            }
            else
            {
            Console.WriteLine($"Impossibile annullare.");
            }
    }
    public void Visualizza()
    {
        Console.WriteLine($"codice: {CodiceVolo}, posto occupati: {postiOccupati}, posti liberi: {postiLiberi}");
    }
}



class Program
{
    public static void Main(string[] args)
    {
        VoloAereo volo1 = new VoloAereo();
        volo1.CodiceVolo = "MD025";

        int scelta;
        

        do
        {
            Console.WriteLine("[1] Effettua prenotazione");
            Console.WriteLine("[2] Annulla prenotazone");
            Console.WriteLine("[3] Visualizza");
            Console.WriteLine("[4] Esci");
            Console.Write("Scelta: ");
            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.Write("Quanti posti: ");
                    volo1.EffettuaPrenotazione(int.Parse(Console.ReadLine()));
                    volo1.Visualizza();
                    break;
                case 2:
                    Console.Write("Quanti posti: ");
                    volo1.AnnullaPrenotazione(int.Parse(Console.ReadLine()));
                    volo1.Visualizza();
                    break;
                case 3:
                    volo1.Visualizza();
                    break;
                case 4:
                    Console.WriteLine("Uscita...");
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        } while (scelta != 0); 
    }
}
