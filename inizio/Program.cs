/*using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // 1. Genera una lista di nomi casuali
        List<string> nomi = new List<string>();
        Random rand = new Random();
        string chars = "abcdefghijklmnopqrstuvwxyz";

        while (nomi.Count < 2000)
        {
            string nome = "";
            int lunghezza = rand.Next(5, 9);
            for (int i = 0; i < lunghezza; i++)
                nome += chars[rand.Next(chars.Length)];

            if (nome != "pippo" && !nomi.Contains(nome))
                nomi.Add(nome);
        }
        nomi.Add("pippo");
        nomi.Sort();
        int nomiMeta = 0;
        int massimo = nomi.Count();
        int minimo = 0;
        String nomeConFronto;
        bool pippoFound = false;
        int contatore = 0;

        while (pippoFound == false)
        {
            contatore++;
            nomiMeta = (massimo + minimo) / 2;
            nomeConFronto = nomi[nomiMeta];
            int result = string.Compare("pippo", nomeConFronto);
            if (result == 0)
            {
                pippoFound = true;
                Console.WriteLine($"Pippo trovato in : {contatore} ricerche");
            }
            if (result < 0)
            {
                massimo /= 2;
            }
            if (result > 0)
            {
                minimo = massimo / 2;

            }
        }
    }
}*/



















using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Genera una lista di nomi casuali
        List<string> nomi = new List<string>();
        Random rand = new Random();
        string chars = "abcdefghijklmnopqrstuvwxyz";

        while (nomi.Count < 2000)
        {
            string nome = "";
            int lunghezza = rand.Next(5, 9);
            for (int i = 0; i < lunghezza; i++)
                nome += chars[rand.Next(chars.Length)];

            if (nome != "pippo" && !nomi.Contains(nome))
                nomi.Add(nome);
        }

        // Aggiungiamo 'pippo' e ordiniamo la lista
        nomi.Add("pippo");
        nomi.Sort();

        // Inizializziamo i limiti per la ricerca binaria
        int sinistra = 0;
        int destra = nomi.Count - 1;
        int contatore = 0;
        bool trovato = false;

        while (sinistra <= destra)
        {
            contatore++;
            int centro = (sinistra + destra) / 2;
            string nomeConfronto = nomi[centro];
            int confronto = string.Compare("pippo", nomeConfronto);

            if (confronto == 0)
            {
                trovato = true;
                Console.WriteLine($"'pippo' trovato in {contatore} tentativi all'indice {centro}");
                break;
            }
            else if (confronto < 0)
            {
                destra = centro - 1;
            }
            else
            {
                sinistra = centro + 1;
            }
        }

        if (!trovato)
        {
            Console.WriteLine("'pippo' non è stato trovato nella lista.");
        }
    }
}

