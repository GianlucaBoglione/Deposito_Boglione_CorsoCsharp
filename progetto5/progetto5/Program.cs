using System;

public class Macchina
{
    public string Motore;
    public float VelocitaMac;
    public int SospensioniMax;
    public int NrModifiche;

    public Macchina(string Motore, float VelocitaMac, int SospensioniMax, int NrModifiche)
    {
        this.Motore = Motore;
        this.VelocitaMac = VelocitaMac;
        this.SospensioniMax = SospensioniMax;
        this.NrModifiche = NrModifiche;
    }
        public void AumentaVelocita()
    {
        VelocitaMac += 10;
        NrModifiche++;
    }

    public void CambiaMotore(string nuovoMotore)
    {
        Motore = nuovoMotore;
        NrModifiche++;
    }

    public void AumentaSospensioni()
    {
        SospensioniMax += 1;
        NrModifiche++;
    }

    public void StampaCaratteristiche(string nomeUtente)
    {
        Console.WriteLine($"Utente: {nomeUtente}");
        Console.WriteLine($"Motore: {Motore}");
        Console.WriteLine($"Velocità: {VelocitaMac}");
        Console.WriteLine($"Sospensioni: {SospensioniMax}");
        Console.WriteLine($"Numero Modifiche: {NrModifiche}");
    }
}
public class Utente
{
    public string Nome;
    public int Credito;

    public Utente(string nome, int credito)
    {
        Nome = nome;
        Credito = credito;
    }
}

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("inserisci nome utente: ");
        string Utente = Console.ReadLine();
        Console.WriteLine("inserisci i crediti: ");
        int credito = int.Parse(Console.WriteLine());

        Utente utente1 = new Utente(nome, 3);

        for (int i = 0; i < utente1; i--) {
            
        }
    }





}








