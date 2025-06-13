using System;
using System.Collections;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

class Program
{
    static void Main()
    {
        string connStr = "server=localhost; user=root; password=1234; port=3306; database=negozio;";
        using MySqlConnection conn = new MySqlConnection(connStr);

        try
        {
            conn.Open();
            Console.WriteLine("Connessione riuscita!");

            bool esci = false;

            while (!esci)
            {
                Console.WriteLine("Benvenuto nel negozio: [1] Registrati  [2] Accedi  [3] Esci");
                Console.Write("Scegli un'opzione: ");
                string scelta = Console.ReadLine() ?? "";

                switch (scelta)
                {
                    case "1":
                        Registrazione(conn);
                        break;
                    case "2":
                        Accesso(conn);
                        break;
                    case "3":
                        esci = true;
                        break;
                    default:
                        Console.WriteLine("Opzione non valida.");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Errore: " + ex.Message);
        }
    }

    private static void Registrazione(MySqlConnection conn)
    {
        Console.Write("Crea il tuo username: ");
        string username = Console.ReadLine() ?? "Campo oblogatorio";

        Console.Write("Crea la tua password: ");
        string password = Console.ReadLine() ?? "Campo oblogatorio";

        Console.Write("Inserisci il tuo numero di telefono: ");
        string telefono = Console.ReadLine() ?? "Campo oblogatorio";

        Console.Write("Inserisci il tuo indirizzo: ");
        string indirizzo = Console.ReadLine() ?? "Campo oblogatorio";

        string query = "INSERT INTO utenti (username, password, telefono, indirizzo, ruolo) VALUES (@username, @password, @telefono, @indirizzo, 'u')";
        using MySqlCommand cmd = new MySqlCommand(query, conn);

        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@password", password);
        cmd.Parameters.AddWithValue("@telefono", telefono);
        cmd.Parameters.AddWithValue("@indirizzo", indirizzo);

        try
        {
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                Console.WriteLine("Registrazione completata con successo.");
            else
                Console.WriteLine("Registrazione fallita.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Errore durante la registrazione: " + ex.Message);
        }
    }

    public static void Accesso(MySqlConnection conn)
    {
        Console.Write("Inserisci username: ");
        string username = Console.ReadLine() ?? "Campo oblogatorio";

        Console.Write("Inserisci password: ");
        string password = Console.ReadLine() ?? "Campo oblogatorio";

        string query = "SELECT * FROM utenti WHERE username = @username AND password = @password";
        using MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@password", password);

        try
        {
            using MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string ruolo = reader["ruolo"].ToString() ?? "Campo oblogatorio";
                reader.Close();

                Console.WriteLine($"Accesso riuscito con utente: {username}");
                if (ruolo == "u")
                    MenuUtente(conn, username);
                else if (ruolo == "a")
                    MenuAdmin(conn, username);
                else
                    Console.WriteLine("Ruolo utente non riconosciuto.");
            }
            else
            {
                Console.WriteLine("Username o Password errati.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Errore durante l'accesso: " + ex.Message);
        }
    }

    private static void MenuUtente(MySqlConnection conn, string username)
    {
        bool logout = false;
        List<int> carrello = new List<int>();

        Console.WriteLine($"Benvenuto, {username}!");

        while (!logout)
        {
            Console.WriteLine("\nCosa vuoi fare?");
            Console.WriteLine("[1] Visualizza viaggi");
            Console.WriteLine("[2] Aggiungi viaggio al carrello");
            Console.WriteLine("[3] Visualizza carrello");
            Console.WriteLine("[4] Effettua ordine");
            Console.WriteLine("[0] Logout");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine() ?? "Campo oblogatorio";

            switch (scelta)
            {
                case "1":
                    VisualizzaViaggi(conn);
                    break;
                case "2":
                    AggiungiViaggioAlCarrello(conn, carrello);
                    break;
                case "3":
                    VisualizzaCarrello(conn, carrello);
                    break;
                case "4":
                    EffettuaOrdine(conn, carrello, username);
                    break;
                case "0":
                    Console.WriteLine("Logout effettuato.");
                    logout = true;
                    break;
                default:
                    Console.WriteLine("Operazione non valida.");
                    break;
            }
        }
    }

    private static void MenuAdmin(MySqlConnection conn, string username)
    {
        bool logout = false;

        Console.WriteLine($"Benvenuto admin, {username}!");

        while (!logout)
        {
            Console.WriteLine("\nCosa vuoi fare?");
            Console.WriteLine("[1] Visualizza viaggi");
            Console.WriteLine("[2] Aggiungi viaggio");
            Console.WriteLine("[3] Modifica viaggio");
            Console.WriteLine("[4] Elimina viaggio");
            Console.WriteLine("[5] Visualizza prenotazioni");
            Console.WriteLine("[0] Logout");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine() ?? "";

            switch (scelta)
            {
                case "1":
                    VisualizzaViaggi(conn);
                    break;
                case "2":
                    AggiungiViaggio(conn);
                    break;
                case "3":
                    ModificaViaggio(conn);
                    break;
                case "4":
                    EliminaViaggio(conn);
                    break;
                case "5":
                    VisualizzaPrenotazioni(conn);
                    break;
                case "0":
                    Console.WriteLine("Logout effettuato.");
                    logout = true;
                    break;
                default:
                    Console.WriteLine("Operazione non valida.");
                    break;
            }
        }
    }

 private static void VisualizzaViaggi(MySqlConnection conn)
    {
        string query = "SELECT viaggio_id, nome_viaggio, descrizione, prezzo FROM viaggio";
        using MySqlCommand cmd = new MySqlCommand(query, conn);

        try
        {
            using MySqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\n-- Viaggi disponibili --");
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["viaggio_id"]} | Nome: {reader["nome_viaggio"]} | Prezzo: {reader["prezzo"]} | Descrizione: {reader["descrizione"]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Errore nella visualizzazione viaggi: " + ex.Message);
        }
    }

    private static void AggiungiViaggio(MySqlConnection conn)
    {
        Console.Write("Nome viaggio: ");
        string nome = Console.ReadLine() ?? "";

        Console.Write("Descrizione: ");
        string descrizione = Console.ReadLine() ?? "";

        Console.Write("Prezzo: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal prezzo))
        {
            Console.WriteLine("Prezzo non valido.");
            return;
        }

        string query = "INSERT INTO viaggio (nome_viaggio, descrizione, prezzo) VALUES (@nome, @descrizione, @prezzo)";
        using MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@nome", nome);
        cmd.Parameters.AddWithValue("@descrizione", descrizione);
        cmd.Parameters.AddWithValue("@prezzo", prezzo);

        try
        {
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                Console.WriteLine("Viaggio aggiunto con successo.");
            else
                Console.WriteLine("Errore durante l'inserimento del viaggio.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Errore: " + ex.Message);
        }
    }

    private static void ModificaViaggio(MySqlConnection conn)
    {
        Console.Write("ID del viaggio da modificare: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID non valido.");
            return;
        }

        Console.Write("Nuovo nome viaggio: ");
        string nome = Console.ReadLine() ?? "";

        Console.Write("Nuova descrizione: ");
        string descrizione = Console.ReadLine() ?? "";

        Console.Write("Nuovo prezzo: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal prezzo))
        {
            Console.WriteLine("Prezzo non valido.");
            return;
        }

        string query = "UPDATE viaggio SET nome_viaggio = @nome, descrizione = @descrizione, prezzo = @prezzo WHERE viaggio_id = @id";
        using MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@nome", nome);
        cmd.Parameters.AddWithValue("@descrizione", descrizione);
        cmd.Parameters.AddWithValue("@prezzo", prezzo);
        cmd.Parameters.AddWithValue("@id", id);

        try
        {
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                Console.WriteLine("Viaggio modificato con successo.");
            else
                Console.WriteLine("Nessun viaggio trovato con questo ID.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Errore: " + ex.Message);
        }
    }

    private static void EliminaViaggio(MySqlConnection conn)
    {
        Console.Write("ID del viaggio da eliminare: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID non valido.");
            return;
        }

        string query = "DELETE FROM viaggio WHERE viaggio_id = @id";
        using MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@id", id);

        try
        {
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                Console.WriteLine("Viaggio eliminato con successo.");
            else
                Console.WriteLine("Nessun viaggio trovato con questo ID.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Errore: " + ex.Message);
        }
    }

}





































































