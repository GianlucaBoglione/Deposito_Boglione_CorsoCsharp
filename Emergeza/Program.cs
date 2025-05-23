using System;

public class Operatore
{
    private string nome;
    private string turno;

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public string Turno
    {
        get { return turno; }
        set
        {
            if (turno == "giorno" || turno == "notte")
            {
                turno = value;
            }
            else
            {
                Console.WriteLine($"Errore: Il turno '{turno}' non è valido. Accetta solo 'giorno' o 'notte'.");
            }
        }
    }
    public virtual void EseguiCompito()
    {
        Console.WriteLine("Operatore generico inservizio.");
    }
}

public class OperatoreEmergenza : Operatore
{
    private int livelloUrgenza;

    public int LivelloUrgenza
    {
        get { return livelloUrgenza; }
        set
        {
            if (value >= 1 && value <= 5)
            {
                livelloUrgenza = value;
            }
            else
            {
                Console.WriteLine($"Errore: Il livello di urgenza '{value}' non è valido. Deve essere compreso tra 1 e 5.");

            }
        }
    }
    public override void EseguiCompito()
    {
        Console.WriteLine($"Gestione emergenza di livello {LivelloUrgenza} da parte di {Nome}.");
    }
}
public class OperatoreSicurezza : Operatore

{
    private string AreaSorveglianza { get; set; }


    public override void EseguiCompito()
    {
        Console.WriteLine($"Sorveglianza dell'area {AreaSorveglianza} da parte di {Nome}.");
    }
}
public class OperatoreLogistica : Operatore
{
    private int numeroConsegne;

    public int NumeroConsegne
    {
        get { return numeroConsegne; }
        set
        {
            if (value >= 0)
                numeroConsegne = value;
            else
                Console.WriteLine("Numero non valido.");
        }
    }

    public override void EseguiCompito()
    {
        Console.WriteLine($"Coordinamento di {NumeroConsegne} consegne da parte di {Nome}.");
    }
}



public class Program
{
    public static void Main(string[] args)
    {
        List<Operatore> lavoro = new List<Operatore>();        // creazione lista per i veicoli

        int scelta;

        do
        {
            Console.WriteLine("Gestione lavoro");
            Console.Write("Scegli un'opzione: ");
            Console.WriteLine("1. Aggiungi emergnza");
            Console.WriteLine("2. Aggiungi area di sicurezza");
            Console.WriteLine("3. Aggiungi logistica");
            Console.WriteLine("4. Esegui compiti");
            Console.WriteLine("5. Esegui Compiti");
            Console.WriteLine("6. Esci");
            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    OperatoreEmergenza eme1 = new OperatoreEmergenza();
                    Console.Write("Nome: ");
                    string NomeE = Console.ReadLine();
                    Console.Write("Turno (giorno/notte): ");
                    string TurnoE = Console.ReadLine();
                    Console.Write("Livello urgenza (1-5): ");
                    int LivelloUrgenza = int.Parse(Console.ReadLine());
                    lavoro.Add(eme1);
                    break;
                case 2:
                    OperatoreSicurezza sic1 = new OperatoreSicurezza();
                    Console.Write("Nome: ");
                    string NomeS = Console.ReadLine();
                    Console.Write("Turno (giorno/notte): ");
                    string TurnoS = Console.ReadLine();
                    Console.Write("AreaSorveglianza: ");
                    int AreaSicurezza = int.Parse(Console.ReadLine());
                    lavoro.Add(sic1);
                    break;
                case 3:
                    OperatoreLogistica log1 = new OperatoreLogistica();
                    Console.Write("Nome: ");
                    string NomeL = Console.ReadLine();
                    Console.Write("Turno (giorno/notte): ");
                    string TurnoL = Console.ReadLine();
                    Console.Write("Numero di consegne: ");
                    int NumeroConsegne = int.Parse(Console.ReadLine());
                    lavoro.Add(log1);
                    break;
                case 4:
                    foreach (Operatore op in lavoro)
                    {
                        Console.WriteLine($"Nome: {op.Nome}, Turno: {op.Turno}");
                    }
                    break;
                case 5:
                    foreach (Operatore o in lavoro)
                    {
                        o.EseguiCompito();
                    }
                    break;
                case 6:
                    break;
            }
        } while (scelta != 0);
    }
}
