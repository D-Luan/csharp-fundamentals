using System;

namespace Test;

internal class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };

        foreach(int specificNumber in numbers)
        {
            Console.WriteLine($"Especific number: {specificNumber}");
        }
    }
}
