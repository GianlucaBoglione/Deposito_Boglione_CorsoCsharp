using System;


public class Soldato
{
    private string nome;
    private string grado;
    private int anniDiServizio;

    public Soldato(string nome, string grado, int anniDiServizio)
    {
        this.nome = nome;
        this.grado = grado;
        this.anniDiServizio = anniDiServizio;
    }
    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }
    public string Grado
    {
        get { return grado; }
        set { grado = value; }
    }
    public int AngiDiServizio
    {
        get { return anniDiServizio; }
        set
        {
            if (value > 0)
            {
                anniDiServizio = value;
            }
            else
            {
                Console.WriteLine("Errore: gli anni di servizio devono essere maggiore di zero.");
            }
        }
    }
    public virtual void StampaInfo()
    {
        Console.WriteLine($"Nome Soldato: {nome}, grado: {grado}, anni di servizio: {anniDiServizio}");
    }

}
public class Fante : Soldato
{
    private string arma;

    public string Arma
    {
        get { return arma; }
        set { arma = value; }
    }

    public Fante(string nome, string grado, int anniDiServizio, string arma) : base(nome, grado, anniDiServizio)
    {
        this.Arma = arma;
        this.Grado = grado;
        this.AngiDiServizio = anniDiServizio;
    }

    public override void StampaInfo()
    {
        base.StampaInfo();
        Console.WriteLine($"Arma: {Arma}");
    }
}
public class Artigliere : Soldato
{
    private int calibro;

    public int Calibro
    {
        get { return calibro; }
        set { calibro = value; }
    }

    public Artigliere(string nome, string grado, int anniDiServizio, int calibro) : base(nome, grado, anniDiServizio)
    {
        this.calibro = calibro;
        this.Grado = grado;
        this.AngiDiServizio = anniDiServizio;
    }

    public override void StampaInfo()
    {
        base.StampaInfo();
        Console.WriteLine($"Calibro: {calibro}");
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        List<Soldato> Esercito = new List<Soldato>();

        int scelta;
        int anniDiServizioFante;
        int anniDiServizioArtigliere;

        do
        {
            Console.WriteLine("Gestione Esercito");
            Console.Write("Scegli un'opzione: ");
            Console.WriteLine("1. Aggiungi un Fante");
            Console.WriteLine("2. Aggiungi un Artigliere");
            Console.WriteLine("3. Visualizza tutti i soldati");
            Console.WriteLine("4. Esci");
            
            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.Write("Nome Fante: ");
                    string nomeFante = Console.ReadLine();
                    Console.Write("Grado Fante: ");
                    string gradoFante = Console.ReadLine();
                    Console.Write("Anni di Servizio Fante: ");
                    anniDiServizioFante = int.Parse(Console.ReadLine());
                    Console.Write("Arma Fante: ");
                    string armaFante = Console.ReadLine();

                    Fante nuovoFante = new Fante(nomeFante, gradoFante, anniDiServizioFante, armaFante);
                    Esercito.Add(nuovoFante);
                    Console.WriteLine("Fante aggiunto con successo!");
                    break;

                case 2:
                    Console.Write("Nome Artigliere: ");
                    string nomeArtigliere = Console.ReadLine();
                    Console.Write("Grado Artigliere: ");
                    string gradoArtigliere = Console.ReadLine();
                    Console.Write("Anni di Servizio Artigliere: ");
                    anniDiServizioArtigliere = int.Parse(Console.ReadLine());
                    Console.Write("Calibo Artigliere: ");
                    int caliboArtigliere = int.Parse(Console.ReadLine());

                    Artigliere nuovoArtigliere = new Artigliere(nomeArtigliere, gradoArtigliere, anniDiServizioArtigliere, caliboArtigliere);
                    Esercito.Add(nuovoArtigliere);
                    Console.WriteLine("Artigliere aggiunto con successo!");
                    break;

                case 3:
                    Console.WriteLine("Tutti i Soldati:");
                    if (Esercito.Count == 0)
                    {
                        Console.WriteLine("Nessun soldato presente nell'esercito.");
                    }
                    else
                    {
                        foreach (Soldato soldato in Esercito)
                        {
                            soldato.StampaInfo();
                        }
                    }
                    break;

                case 4:
                    Console.WriteLine("Uscita dal programma. Arrivederci!");
                    break;

                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }
        } while (scelta != 0);
    }
}


