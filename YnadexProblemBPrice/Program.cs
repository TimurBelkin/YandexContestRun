using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        var input = Console.ReadLine()
    ?.Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(it => Double.Parse(it))
    .ToList();

        Console.WriteLine(findFastWay(input[0], input[1], input[2], input[3], input[4], input[5]));

        /*
        Пример ввода и вывода числа n, где -10^9 < n < 10^9:
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(n);
        */

        
    }

    static double findFastWay(double shop, double market, double shopMarket, 
        double vEmpty, double vLoad, double vDoubleLoad)
    {
        if(shop > market + shopMarket)
        {
            shop = market + shopMarket;
        }

        if (market  > shop + shopMarket)
        {
            market = shop + shopMarket;
        }

        double homeWay = shop / vEmpty + shop / vLoad + market / vEmpty + market / vLoad;
        double shopMarkettWay = shop / vEmpty + shopMarket / vLoad + market / vDoubleLoad;
        double marketShoptWay = market / vEmpty + shopMarket / vLoad + shop / vDoubleLoad;

        double time = Math.Min(Math.Min(homeWay, shopMarkettWay), marketShoptWay);
        return time;
    }

}