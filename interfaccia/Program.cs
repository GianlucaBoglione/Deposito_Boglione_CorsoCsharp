using System;
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
        Console.WriteLine("Metodo: carta di credito");
    }
}
 public class PagamentoPayPal : IPagamento
    {
        private string EmailUtente{ get; set; }

        public PagamentoPayPal(string emailUtente)
        {
            this.EmailUtente = emailUtente;
        }

        public void EseguiPagamento(decimal importo)
        {
            Console.WriteLine($"Importo: {importo} euro, Pagato con carta (circuito: {EmailUtente})");
        }

        public void MostraMetodo()
        {
            Console.WriteLine("Metodo: carta di credito");
        }
    }
public class PagamentoContanti : IPagamento
{
        public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Importo: {importo} euro, Pagato con PayPal)");
    }

    public void MostraMetodo()
    {
        Console.WriteLine("Metodo: PayPal");
    }
    
}
public class Program
{
    public static void Main(string[] args)
    {
        List<IPagamento> pagamento = new List<IPagamento>();

        decimal importo = 0;
        bool continua = true;
        // inizio menu 
        while (continua)
        {
            Console.WriteLine("Scegli il metodo di pagamento: ");
            Console.WriteLine("[1] Pagamento con carta di credito");
            Console.WriteLine("[2] pagamento con payPal");
            Console.WriteLine("[3] Pagamento in contanti");
            Console.WriteLine("[4] Visualizza");
            Console.WriteLine("[5] Esci");

            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1: // Pagamento con Carta di Credito
                    Console.Write("Inserisci il circuito della carta (es. Visa, MasterCard): ");
                    string circuitoCarta = Console.ReadLine();
                    PagamentoCarta carta = new PagamentoCarta(circuitoCarta);
                    pagamento.Add(carta);
                    Console.WriteLine("Metodo 'Pagamento con Carta' aggiunto.");
                    break;
                case 2: // Pagamento con PayPal
                    Console.Write("Inserisci l'email dell'account PayPal: ");
                    string emailPayPal = Console.ReadLine();
                    PagamentoPayPal paypal = new PagamentoPayPal(emailPayPal);
                    pagamento.Add(paypal);
                    Console.WriteLine("Metodo 'Pagamento con PayPal' aggiunto.");
                    break;

                case 3: // Pagamento in Contanti
                    PagamentoContanti contanti = new PagamentoContanti();
                    pagamento.Add(contanti);
                    Console.WriteLine("Metodo 'Pagamento in Contanti' aggiunto.");
                    break;
                case 4: // visualizzazione 
                    foreach (IPagamento metodo in pagamento)
                    {
                        metodo.MostraMetodo();
                        metodo.EseguiPagamento(importo);
                    }
                    break;
                    case 5:
                        continua = false;
                        Console.WriteLine("Uscita dal programma. Arrivederci!");
                        break;

                default: // Scelta non valida
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            } while (continua) ;
        }

    }
}
    