using System;

namespace Triangle
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var triangle = new Triangle(5);
            Console.WriteLine(triangle);
            Console.WriteLine(triangle.HighestSum());
        }
    }
}