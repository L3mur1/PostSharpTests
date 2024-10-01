using PostSharp.Patterns.Caching;
using PostSharp.Patterns.Caching.Backends;
using System;
using System.Threading;

namespace PostSharpTests
{
    public static class Program
    {
        public static void Main()
        {
            CachingServices.DefaultBackend = new MemoryCachingBackend();

            DisplayNumber(1);
            DisplayNumber(2);
            DisplayNumber(1);
            DisplayNumber(1);
        }

        [Cache]
        private static int GetNumber(int number)
        {
            Console.WriteLine($"{DateTime.UtcNow:HH:mm:ss.fff} Loading not catched number: {number}...");
            Thread.Sleep(2000);
            return number;
        }

        private static void DisplayNumber(int number)
        {
            var loadedNumber = GetNumber(number);
            Console.WriteLine($"{DateTime.UtcNow:HH:mm:ss.fff} Loaded number: {loadedNumber}");
        }
    }
}