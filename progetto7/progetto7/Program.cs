class Program
{
    public static void main(String[] args)
    {
        List<string> listaSpesa = new List<string>();   // creo una lista per memorizzare i prootti

        Console.WriteLine("inserisci 5 prodotti: ");    // chiedo all'utente di inserire 5 prodotti
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"listaSpesa {i}: ");
            string prodotto = Console.ReadLine();
            listaSpesa.Add(prodotto);

        }
        Console.WriteLine("ecco la lista di prodotti: ");       // stampo i prodotti della lista
        foreach (var prodotto in listaSpesa)
        {
            Console.WriteLine(prodotto);
        }
    }
}

/*
listaSpesa.Add("ciocoria");
listaSpesa.Add("salame piccante");
listaSpesa.Add("ciocoria");
*/


