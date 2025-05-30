using System;
using System.Collections.Generic;



//Interfaccia IStrategiaOperazione Metodo: double Calcola(double a, double b)
public interface IStrategiaOperazione
{
    double Calcola(double a, double b);
}

//Strategie concrete: 
//SommaStrategia
//SottrazioneStrategia
//MoltiplicazioneStrategia
//DivisioneStrategia
//Ognuna implementa IStrategiaOperazione con la rispettiva logica.
public class SommaStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        return a + b;
    }
}
public class SottrazioneStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        return a - b;
    }
}
public class MoltiplicazioneStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        return a * b;
    }
}
public class DivisioneStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Divisione per zero non permessa.");
        }
        return a / b;
    }
}

//Classe Calcolatrice
//Ha un campo IStrategiaOperazione strategia
//Metodo EseguiOperazione(double a, double b) che delega il calcolo alla strategia impostata
//Metodo ImpostaStrategia(IStrategiaOperazione nuovaStrategia) per cambiare dinamicamente ilcomportamento

public class Calcolatrince 
{
    private IStrategiaOperazione strategia;

    public void ImpostaStrategia(IStrategiaOperazione nuovaStrategia)
    {
        strategia = nuovaStrategia;
    }
    public double EseguiOperazione(double a, double b)
    {
        if (strategia == null)
        {
            throw new InvalidOperationException("Strategia non impostata.");
        }
        return strategia.Calcola(a, b);
    }
}

//Nel Main:
//Chiedi all'utente due numeri
//Fai scegliere l'operazione
//In base alla scelta, imposta la strategia corrispondente nella calcolatrice
//Esegui il calcolo e mostra il risultato

class Program
{
    static void Main()
    {
        var calcolatrice = new Calcolatrince();

        Console.WriteLine("Inserisci il primo numero: ");
        double numero1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci il primo numero: ");
        double numero2 = double.Parse(Console.ReadLine());

        Console.WriteLine("Scegli una operazione");
        Console.WriteLine("1 - Somma");
        Console.WriteLine("2 - Sottrazione");
        Console.WriteLine("3 - Moltiplicazione");
        Console.WriteLine("4 - Divisione");
        Console.Write("Scelta: ");
        string scelta = Console.ReadLine();

        switch (scelta)
        {
            case "1":
                calcolatrice.ImpostaStrategia(new SommaStrategia());
                break;
            case "2":
                calcolatrice.ImpostaStrategia(new SottrazioneStrategia());
                break;
            case "3":
                calcolatrice.ImpostaStrategia(new MoltiplicazioneStrategia());
                break;
            case "4":
                calcolatrice.ImpostaStrategia(new DivisioneStrategia());
                break;
            default:
                break;
        }
        double risultato = calcolatrice.EseguiOperazione(numero1, numero2);
        Console.WriteLine($"Risultato: {risultato}");
    }
}
