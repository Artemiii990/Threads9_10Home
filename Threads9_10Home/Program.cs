using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class PrimeGenerator
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введіть нижню межу (або натисніть Enter для 2):");
        string lowerBoundInput = Console.ReadLine();
        Console.WriteLine("Введіть верхню межу (або натисніть Enter для нескінченності):");
        string upperBoundInput = Console.ReadLine();

        int lowerBound;
        bool lowerBoundSuccess = int.TryParse(lowerBoundInput, out lowerBound);

        int upperBound;
        bool upperBoundSuccess = int.TryParse(upperBoundInput, out upperBound);


        if (!lowerBoundSuccess && !upperBoundSuccess)
        {
            lowerBound = 2;
            upperBound = int.MaxValue;
            
        }

         // Обробка випадків, коли межі не вказані
        if (string.IsNullOrEmpty(lowerBoundInput))
        {
            lowerBound = 2;
        }

        if (string.IsNullOrEmpty(upperBoundInput))
        {
            upperBound = int.MaxValue; 
        }



        // Важливо! Потрібно перевірити, чи нижня межа менша або дорівнює верхній.
        if (lowerBound > upperBound && upperBound != int.MaxValue)
        {
            Console.WriteLine("Нижня межа повинна бути меншою або дорівнювати верхній.");
            return;
        }



        Task.Run(() => GeneratePrimes(lowerBound, upperBound));

        Console.WriteLine("Генерація завершена. Натисніть будь-яку клавішу для виходу.");
        Console.ReadKey();
    }

    private static void GeneratePrimes(int lowerBound, int upperBound)
    {
        List<int> primes = new List<int>();
        for (int num = lowerBound; num <= upperBound; num++)
        {
            if (IsPrime(num))
            {
                primes.Add(num);
                Console.WriteLine(num);
            }
        }
    }

    private static bool IsPrime(int num)
    {
        if (num <= 1)
        {
            return false;
        }

        if (num <= 3)
        {
            return true;
        }

        if (num % 2 == 0 && num % 3 == 0)
        {
            return false;
        }

        for (int i = 5; i * i <= num; i = i + 6)
        {
            if (num % i == 0 || num % (i + 2) == 0)
                return false;
        }
        return true;
    }
}
