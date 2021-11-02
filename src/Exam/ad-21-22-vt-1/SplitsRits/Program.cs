using System;
using System.Collections.Generic;

namespace AD
{
    public class Program
    {
        static MyLinkedList<T> BuildList<T>(T[] items)
        {
            MyLinkedList<T> list = new MyLinkedList<T>();
            foreach (T item in items)
                list.AddFirst(item);
            return list;
        }

        static void SplitsAndPrint<T>(T[] items)
        {
            MyLinkedList<T> a, b;
            MyLinkedList<T> l = BuildList(items);

            (a, b) = l.Splits();

            Console.WriteLine($"{l} => ( {a}, {b} )");
        }

        static void TestSplits()
        {
            SplitsAndPrint(new int[] { });
            SplitsAndPrint(new int[] { 5 });
            SplitsAndPrint(new int[] { 5, 4 });
            SplitsAndPrint(new int[] { 5, 4, 3 });
            SplitsAndPrint(new int[] { 5, 4, 3, 2 });
            SplitsAndPrint(new int[] { 5, 4, 3, 2, 1 }); 
        }

        static void RitsAndPrint<T>(T[] items1, T[] items2)
        {
            MyLinkedList<T> l = new MyLinkedList<T>();
            MyLinkedList<T> a = BuildList(items1);
            MyLinkedList<T> b = BuildList(items2);

            l.Rits(a, b);

            Console.WriteLine($"( {a}, {b} ) => {l}");
        }

        static void TestRits()
        {
            RitsAndPrint(new int[] { }, new int[] { });
            RitsAndPrint(new int[] { 5, 3, 1 }, new int[] { 4, 2});
            RitsAndPrint(new int[] { 8, 7, 6, 5, 3, 1 }, new int[] { 4, 2 });
            RitsAndPrint(new int[] { 5, 4, 3, 2, 1 }, new int[] { });
            RitsAndPrint(new int[] { }, new int[] { 5, 4, 3, 2, 1 });
        }

        static void Main(string[] args)
        {
            TestSplits();
            Console.WriteLine();
            TestRits();
        }
    }
}
