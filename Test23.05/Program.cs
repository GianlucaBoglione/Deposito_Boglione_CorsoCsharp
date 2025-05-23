using System;

// classe Base
public class Veicolo
{
    public string Marca { get; set; }
    public string Modello { get; set; }
    public int AnnoImmatricolazione { get; set; }

    public Veicolo(string marca, string modello, int annoImmatricolazione)
    {
        Marca = marca;
        Modello = modello;
        AnnoImmatricolazione = annoImmatricolazione;
    }
    public virtual void StampaInfo()
    {
        Console.WriteLine($"Marca: {Marca}, Modello: {Modello}, anno di immatricolazione: {AnnoImmatricolazione}  ");
    }
}

// classe derivata AutoAziendale
public class AutoAziendale : Veicolo
{
    // Proprietà aggiuntiva per AutoAziendale
    public string Targa { get; set; }
    public bool UsoPrivato
    {
        get { return UsoPrivato; }
        set
        {
            if (value = true)
            {
                UsoPrivato = true;
            }
            else
            {
                UsoPrivato = false;
            }
        }
    }
    public AutoAziendale(string marca, string modello, int annoImmatricolazione, string targa, bool usoPrivato)
        : base(marca, modello, annoImmatricolazione) // Chiama il costruttore della classe base
    {
        Targa = targa;
        UsoPrivato = usoPrivato;
    }

    // Override del metodo StampaInfo() per includere le informazioni specifiche dell'auto
    public override void StampaInfo()
    {
        base.StampaInfo(); 
        Console.WriteLine($"Tipo Veicolo: Auto Aziendale"); 
        Console.WriteLine($"Targa: {Targa}");
        Console.WriteLine($"Uso Privato Consentito: {(UsoPrivato)}");
    }
}


public class FurgoneAziendale : Veicolo
{
    // Proprietà aggiuntiva per FurgoneAziendale
    public int CapacitaCaricoKg { get; set; } // Capacità di carico in kg

    // Costruttore della classe FurgoneAziendale
    public FurgoneAziendale(string marca, string modello, int annoImmatricolazione, int capacitaCaricoKg)
        : base(marca, modello, annoImmatricolazione)
    {
        CapacitaCaricoKg = capacitaCaricoKg;
    }
        public override void StampaInfo()
    {
        base.StampaInfo(); 
        Console.WriteLine($"Tipo Veicolo: Furgone Aziendale"); 
        Console.WriteLine($"Capacità di Carico: {CapacitaCaricoKg} kg");
    }
    
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Veicolo> Veicoli = new List<Veicolo>();

        int scelta;

        do
        {
            Console.WriteLine("Gestione Veicoli: ");
            Console.WriteLine("Scegli un'opzione: ");
            Console.WriteLine("1. Aggiungi Auto Aziendale");
            Console.WriteLine("2. Aggiungi Furgone Aziendale");
            Console.WriteLine("3. Visualizza veicoli");
            Console.WriteLine("4. Esci");

            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    AutoAziendale auto = new AutoAziendale();
                    Console.WriteLine("Marca: ");
                    string marcaA = Console.ReadLine();
                    Console.WriteLine("Modello: ");
                    string modelloA = Console.ReadLine();
                    Console.WriteLine("Anno di immatricolazione: ");
                    int annoImmatricolazioneA = int.Parse(Console.ReadLine());
                    Veicoli.Add(auto);
                    break;

                case 2:
                    AutoAziendale furgone = new AutoAziendale();
                    Console.WriteLine("Marca: ");
                    string marcaF = Console.ReadLine();
                    Console.WriteLine("Modello: ");
                    string modelloF = Console.ReadLine();
                    Console.WriteLine("Anno di immatricolazione: ");
                    int annoImmatricolazioneF = int.Parse(Console.ReadLine());
                    Veicoli.Add(furgone);
                    break;
                case 3:
                    foreach (Veicolo veicolo in Veicoli)
                    {
                        veicolo.StampaInfo(); // Questo chiamerà il metodo StampaInfo() sovrascritto appropriato
                    }
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("scelta non valida");
                    break;
            }
        } while (scelta != 0);

    }
}
