﻿namespace AD
{
    public class Opgave1
    {
        public static long FacRecursive(int n)
        {
            if (n == 0) return 1;
            return n * FacRecursive(n - 1);
        }

        public static long FacIterative(int n)
        {
            long total = n;
            for (var i = 1; i < n; i++)
            {
                total *= i;
            }
            return total;
        }

        public static void Run()
        {
            //------------------------------------------------------------
            // The factorial of 21 is too high to fit in a "long". That's
            // why from n=21, the result is negative
            //------------------------------------------------------------
            int MAX = 22;

            System.Console.WriteLine("Iteratief:");
            for (int n = 1; n < MAX; n++)
            {
                System.Console.WriteLine("          {0,2}! = {1,20}", n, FacIterative(n));
            }
            System.Console.WriteLine("Recursief:");
            for (int n = 1; n < MAX; n++)
            {
                System.Console.WriteLine("          {0,2}! = {1,20}", n, FacRecursive(n));
            }

        }
    }
}
