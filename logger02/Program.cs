﻿using System;
using System.Collections.Generic;

public sealed class Logger
{
    private static Logger istanza;

    private List<string> loggers = new List<string>();

    public static Logger GetIstanza()
    {
        if (istanza == null)
        {
            istanza = new Logger();
        }
        return istanza;
    }
    public void ScriviMessaggio(string messaggio)
    {
        loggers.Add(messaggio);
    }

    public void Visualizza()
    {
        foreach (var log in loggers)
        {
            Console.WriteLine(log);
        }
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Logger log1 = Logger.GetIstanza();
        Logger log2 = Logger.GetIstanza();

        log1.ScriviMessaggio("Sistema avviato");
        log1.ScriviMessaggio("Programma terminato.");

        log1.Visualizza();
        log2.Visualizza();

        Console.WriteLine("Le due istanze sono uguali? " + (log1 == log2));
        Console.WriteLine("Programma terminato.");
    }
}







/*

﻿using System;

//Creazione del singleton Logger
public sealed class Logger
{
    //Creazione dell'istanza
    private static Logger _instance;

    //Campi del logger utente password e lista dei messaggi dell'utente
    private List<string> listaLog;
    private string _utente, _password;

    //Costruttore che inizializza la lista vuota
    private Logger()
    {
        listaLog = new List<string>();
    }

    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Logger();
        }
        return _instance;
    }
    public void CreaUtEPsw(string utente, string password)
    {
        _utente = utente;
        _password = password;
    }

    public void Log(string message)
    {
        listaLog.Add(message);
    }

    public void MostraLog()
    {
        foreach (string m in listaLog)
        {
            Console.Write("-");
            Console.WriteLine(m);
        }
    }
}

public class Program
{
    public static void Main()
    {
        //Primo richiamo di get instance viene creato il primo logger
        Logger log1 = Logger.GetInstance();

        //imposto l'utente e la password
        Console.WriteLine("Inserisci il nome utente:");
        string utente = Console.ReadLine();

        Console.WriteLine("Inserisci la password:");
        string password = Console.ReadLine();
        log1.CreaUtEPsw(utente, password);

        //Prende in input i due messaggi
        Console.WriteLine("Inserisci il messaggio del log1: ");
        log1.Log(Console.ReadLine());

        Logger log2 = Logger.GetInstance();
        Console.WriteLine("Inserisci messaggio del log2: ");
        log2.Log(Console.ReadLine());

        //Utilizza mostralog sulle due variabili per verificare che in realtà sono la stessa cosa e hanno la stessa lista
        log1.MostraLog();
        log2.MostraLog();

        //Esegue il controllo booleano
        Console.WriteLine(log1 == log2);

    }

}
*/


