using System;
using System.Runtime.CompilerServices;

class Program
{
    public static void main(String[] args)
    {
        int[] voti = new int[5];
        int valoreMax = voti[0];
        int valoreMin = voti[0];
        int somma = 0;
        
        for (int i = 0; i < voti.Length; i++)
        {
            Console.WriteLine($"inserisci ul voto {i + 1}: ");
            voti[i] = int.Parse(Console.ReadLine());
        }
        
        for (int i = 0; i < voti.Length; i++)
        {
            somma += voti[i];
            valoreMax = voti[i];
            valoreMin = voti[i];
        }
        float media = somma / voti.Length;

        Console.WriteLine($"la meida è: {media}");
        Console.WriteLine($"il valore massimo è: {valoreMax}");
        Console.WriteLine($"il valore minimo è: {valoreMin}");
    }

}

/*

int votiMax = voti[0];
int votiMin = voti[0];
int somma = 0;
double media 
















*/