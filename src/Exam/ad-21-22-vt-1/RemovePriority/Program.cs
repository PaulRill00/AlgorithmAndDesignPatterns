using System;

namespace AD
{
    class Program
    {
        //
        //          2
        //        /   \
        //      4       2
        //     / \     / \
        //    7   5   2   8
        //   / 
        //  6 
        //
        public static PriorityQueue<int> CreateExamPriorityQueueModerate()
        {
            PriorityQueue<int> q = new PriorityQueue<int>();

            var items = new int[] { 2, 4, 2, 7, 5, 2, 8, 6 };
            for (int i = 0; i < items.Length; i++)
            {
                q.Add(items[i]);
            }

            return q;
        }

        static void Main(string[] args)
        {
            PriorityQueue<int> pq = CreateExamPriorityQueueModerate();
            int[] indexes = pq.RemovePriority(2);

            Console.WriteLine($"[{String.Join(",", indexes)}]");
        }
    }
}
