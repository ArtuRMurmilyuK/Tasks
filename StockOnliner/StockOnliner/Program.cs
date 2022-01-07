using System;

namespace StockOnliner
{
    internal class Program
    {
        static void Main()
        {
            StockExchangeMonitor stockExchangeMonitor = new StockExchangeMonitor();
            stockExchangeMonitor.PriceChangeHandler = ShowPrice;
            stockExchangeMonitor.Start();
        }

        public static void ShowPrice(int price)
        {
            Console.WriteLine($"New price is: {price}");
        }
    }
}
