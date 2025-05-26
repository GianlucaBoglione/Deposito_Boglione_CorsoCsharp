using System;
using System.Collections.Generic; // necessario per usare List<>

public interface IPagamento
{
    void EseguiPagamento(decimal importo);
    void MostraMetodo();
}

public class PagamentoCarta : IPagamento
{
    private string circuito;

    public string Circuito { get; set; }

    public PagamentoCarta(string circuito)
    {
        this.circuito = circuito;
    }

    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Importo: {importo} euro, Pagato con carta (circuito: {circuito})");
    }

    public void MostraMetodo()
    {
        Console.WriteLine("Metodo: Carta di credito");
    }
}

public class PagamentoPayPal : IPagamento
{
    private string EmailUtente { get; set; }

    public PagamentoPayPal(string emailUtente)
    {
        this.EmailUtente = emailUtente;
    }

    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Importo: {importo} euro, Pagato con PayPal (email: {EmailUtente})"); // correzione testo
    }

    public void MostraMetodo()
    {
        Console.WriteLine("Metodo: PayPal"); // correzione metodo
    }
}

public class PagamentoContanti : IPagamento
{
    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Importo: {importo} euro, Pagato in contanti"); // correzione testo
    }

    public void MostraMetodo()
    {
        Console.WriteLine("Metodo: Contanti"); // correzione metodo
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<IPagamento> pagamento = new List<IPagamento>();
        bool continua = true;

        while (continua)
        {
            Console.WriteLine("Scegli il metodo di pagamento: ");
            Console.WriteLine("[1] Pagamento con carta di credito");
            Console.WriteLine("[2] Pagamento con PayPal");
            Console.WriteLine("[3] Pagamento in contanti");
            Console.WriteLine("[4] Visualizza");
            Console.WriteLine("[5] Esci");

            int scelta;
            if (!int.TryParse(Console.ReadLine(), out scelta))
            {
                Console.WriteLine("Inserisci un numero valido.");
                continue;
            }

            switch (scelta)
            {
                case 1:
                    Console.Write("Inserisci il circuito della carta (es. Visa, MasterCard): ");
                    string circuitoCarta = Console.ReadLine();
                    PagamentoCarta carta = new PagamentoCarta(circuitoCarta);
                    pagamento.Add(carta);
                    Console.Write("Inserisci l'importo da pagare: ");
                    decimal importoCarta = decimal.Parse(Console.ReadLine());
                    carta.EseguiPagamento(importoCarta);
                    break;

                case 2:
                    Console.Write("Inserisci l'email dell'account PayPal: ");
                    string emailPayPal = Console.ReadLine();
                    PagamentoPayPal paypal = new PagamentoPayPal(emailPayPal);
                    pagamento.Add(paypal);
                    Console.Write("Inserisci l'importo da pagare: ");
                    decimal importoPaypal = decimal.Parse(Console.ReadLine());
                    paypal.EseguiPagamento(importoPaypal);
                    break;

                case 3:
                    PagamentoContanti contanti = new PagamentoContanti();
                    pagamento.Add(contanti);
                    Console.Write("Inserisci l'importo da pagare: ");
                    decimal importoContanti = decimal.Parse(Console.ReadLine());
                    contanti.EseguiPagamento(importoContanti);
                    break;

                case 4:
                    Console.WriteLine("\nRiepilogo metodi e pagamenti:");
                    foreach (IPagamento metodo in pagamento)
                    {
                        metodo.MostraMetodo();
                        metodo.EseguiPagamento(0); // puoi decidere se mostrare solo i metodi o associare importi reali
                    }
                    break;

                case 5:
                    continua = false;
                    Console.WriteLine("Uscita dal programma. Arrivederci!");
                    break;

                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }
        }
    }
}
