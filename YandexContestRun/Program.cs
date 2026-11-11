using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var masses = Console.ReadLine()?
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(it => int.Parse(it))
            .Take(n)
            .ToList();

        if(masses is null)
        {
            Console.WriteLine(0);
            return;
        }

        int fun = ComputeFun(masses);

        Console.WriteLine(fun);

        //Console.WriteLine(n);
        //masses.ForEach(Console.WriteLine);
    }

    public static int ComputeFun(List<int> masses)
    {
        int minEven = masses[0], maxOdd = masses[1];
        int indEven = 0, indOdd = 1;
        for (int i = 0; i < masses.Count(); ++i)
        {
            if (i % 2 == 0)
            {
                if (masses[i] < minEven)
                {
                    minEven = masses[i];
                    indEven = i;
                }
            }
            else
            {
                if (masses[i] > maxOdd)
                {
                    maxOdd = masses[i];
                    indOdd = i;
                }
            }
        }

        if (minEven < maxOdd)
        {
            int evenTemp = masses[indEven];
            masses[indEven] = masses[indOdd];
            masses[indOdd] = evenTemp;
        }

        int fun = 0;
        int sign = 1;
        foreach (var mass in masses)
        {
            fun += mass * sign;
            sign *= -1;
        }

        return fun;
    }
}