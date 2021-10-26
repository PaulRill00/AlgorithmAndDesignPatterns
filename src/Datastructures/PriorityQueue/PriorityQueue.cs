using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices;


namespace AD
{
    public partial class PriorityQueue<T> : IPriorityQueue<T>
        where T : IComparable<T>
    {
        public static int DEFAULT_CAPACITY = 100;
        public int size;
        public T[] array;

        public PriorityQueue()
        {
            this.Clear();
        }

        public int Size()
        {
            return this.size;
        }

        public void Clear()
        {
            this.size = 0;
            this.array = new T[DEFAULT_CAPACITY];
            this.array[0] = default;
        }

        public void Add(T x)
        {
            if (size + 1 == array.Length)
            {
                DoubleArray();
            }

            array[++size] = x;
            PerculateUp(size);
        }

        // Removes the smallest item in the priority queue
        public T Remove()
        {
            if (this.size == 0)
            {
                throw new PriorityQueueEmptyException();
            }

            var temp = array[1];
            array[1] = array[size];
            array[size] = default;
            size--;

            PerculateDown(1);

            return temp;
        }


        public void AddFreely(T x)
        {
            array[++size] = x;
        }

        public void BuildHeap()
        {
            for (var i = size / 2; i > 0; i--)
            {
                PerculateDown(i);
            }
        }

        public override string ToString()
        {
            if (size == 0) return "";

            var result = "";
            for(var i = 1; i <= size; i++)
            {
                var comparable = array[i];
                result += $"{comparable} ";
            }

            return result.Trim();
        }

        private void DoubleArray()
        {
            var temp = new T[size * 2];
            for (var i = 0; i <= size; i++)
            {
                temp[i] = this.array[i];
            }

            this.array = temp;
        }

        private void PerculateUp(int i)
        {
            while (i > 0)
            {
                var parentI = i / 2;
                if (parentI < 1) break;

                if (array[parentI].CompareTo(array[i]) > 0)
                {
                    var temp = array[parentI];
                    array[parentI] = array[i];
                    array[i] = temp;
                    i = parentI;
                }else
                {
                    break;
                }
            }
        }

        private void PerculateDown(int i)
        {
            var x = array[i];

            while (i <= size)
            {
                var leftI = 2 * i;
                var rightI = 2 * i + 1;

                // check childless
                if (leftI > size && rightI > size) break;

                var leftGreater = array[i].CompareTo(array[leftI]) > 0 && leftI <= size;
                var rightGreater = array[i].CompareTo(array[rightI]) > 0 && rightI <= size;

                if (!leftGreater && !rightGreater) break;

                if (rightI > size || array[leftI].CompareTo(array[rightI]) < 0)
                {
                    var temp = array[leftI];
                    array[leftI] = x;
                    array[i] = temp;
                    i = leftI;
                }
                else
                {
                    var temp = array[rightI];
                    array[rightI] = x;
                    array[i] = temp;
                    i = rightI;
                }
            }
        }
    }
}
