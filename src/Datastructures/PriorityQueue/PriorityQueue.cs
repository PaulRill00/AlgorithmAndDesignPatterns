using System;
using System.Linq.Expressions;


namespace AD
{
    public partial class PriorityQueue<T> : IPriorityQueue<T>
        where T : IComparable<T>
    {
        public static int DEFAULT_CAPACITY = 100;
        public int size;   // Number of elements in heap
        public T[] array;  // The heap array

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public PriorityQueue()
        {
            this.Clear();
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------
        public int Size()
        {
            return this.size;
        }

        public void Clear()
        {
            this.size = 0;
            this.array = new T[DEFAULT_CAPACITY];
        }

        public void Add(T x)
        {
            if (size + 1 == array.Length)
            {
                DoubleArray();
            }

            var h = ++size;
            array[0] = x;

            for (; x.CompareTo(array[h / 2]) < 0; h /= 2)
            {
                array[h] = array[h / 2];
            }

            array[h] = x;
        }

        // Removes the smallest item in the priority queue
        public T Remove()
        {
            var temp = this.array[0];

            return temp;
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public void AddFreely(T x)
        {
            throw new System.NotImplementedException();
        }

        public void BuildHeap()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            if (size == 0) return "";

            var result = "";
            foreach (var comparable in this.array)
            {
                result += $"{comparable} ";
            }

            return result.Trim();
        }

        private void DoubleArray()
        {
            var temp = new T[size * 2];
            for (var i = 0; i < size; i++)
            {
                temp[i] = this.array[i];
            }

            this.array = temp;
        }

    }
}
