using System;

class ContoCorrente
{
    // Campi privati
    private decimal saldo;
    private int numeroOperazioni;

    // Proprietà di sola lettura
    public decimal Saldo
    {
        get { return saldo; }
    }

    public int NumeroOperazioni
    {
        get { return numeroOperazioni; }
    }

    // Metodo per versare denaro
    public void Versa(decimal importo)
    {
        if (importo > 0)
        {
            saldo += importo;
            numeroOperazioni++;
            Console.WriteLine($"Versato: {importo}. Nuovo saldo: {saldo}.");
        }
        else
        {
            Console.WriteLine("Importo non valido per il versamento.");
        }
    }

    // Metodo per prelevare denaro
    public void Preleva(decimal importo)
    {
        if (importo > 0)
        {
            if (importo <= saldo)
            {
                saldo -= importo;
                numeroOperazioni++;
                Console.WriteLine($"Prelevato: {importo}. Nuovo saldo: {saldo}.");
            }
            else
            {
                Console.WriteLine("Saldo insufficiente per il prelievo.");
            }
        }
        else
        {
            Console.WriteLine("Importo non valido per il prelievo.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ContoCorrente conto = new ContoCorrente();
        int scelta;
        do
        {
            Console.WriteLine("Gestione Conto: ");
            Console.WriteLine("Scegli un'opzione: ");
            Console.WriteLine("1. Versa");
            Console.WriteLine("2. Preleva");
            Console.WriteLine("3. Visualizza");
            Console.WriteLine("4. Esci");

            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.Write("Inserisci l'importo da versare: ");
                    decimal importoV = decimal.Parse(Console.ReadLine());
                    if (importoV > 0)
                    {
                        conto.Versa(importoV);
                    }
                    else
                    {
                        Console.WriteLine("Importo non valido.");
                    }
                    break;
                case 2:
                    Console.Write("Inserisci l'importo da prelevare: ");
                    decimal importoP = decimal.Parse(Console.ReadLine());
                    if (importoP > 0)
                    {
                        conto.Preleva(importoP);
                    }
                    else
                    {
                        Console.WriteLine("Importo non valido.");
                    }
                    break;
                case 3:
                    Console.WriteLine($"Saldo attuale: {conto.Saldo}");
                    Console.WriteLine($"Numero di operazioni: {conto.NumeroOperazioni}");
                    break;

                case 4:
                    Console.WriteLine("Uscita in corso...");
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        } while (scelta != 0);
    }
}