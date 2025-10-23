using System;

namespace FizzBuzz;

internal class Program
{
    static void Main(string[] args)
    {
        int n = 20;
        List<string> res = FizzBuzz(n);

        foreach (string s in res)
        {
            Console.Write($"{s} ");
        }
    }

    public static List<string> FizzBuzz(int n)
    {
        List<string> res = new List<string>();

        for (int i = 1; i <= n; i++)
        {
            string s = "";

            if (i % 3 == 0)
            {
                s += "Fizz";
            }

            if (i % 5 == 0)
            {
                s += "Buzz";
            }

            if (s == "")
            {
                s += i.ToString();
            }

            res.Add(s);
        }

        return res;
    }
}