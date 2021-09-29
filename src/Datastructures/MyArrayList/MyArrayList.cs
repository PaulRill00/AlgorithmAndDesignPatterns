using System.Linq;
using System.Text.Json;

namespace AD
{
    public partial class MyArrayList : IMyArrayList
    {
        private int[] data;
        private int size;

        public MyArrayList(int capacity)
        {
            data = new int[capacity];
            size = 0;
        }

        public void Add(int n)
        {
            if (size + 1 > Capacity())
            {
                throw new MyArrayListFullException();
            }

            data[size++] = n;
        }

        public int Get(int index)
        {
            if (index < 0 || index >= Size())
            {
                throw new MyArrayListIndexOutOfRangeException();
            }

            return data[index];
        }

        public void Set(int index, int n)
        {
            if (index < 0 || index >= Size())
            {
                throw new MyArrayListIndexOutOfRangeException();
            }

            data[index] = n;
        }

        public int Capacity()
        {
            return data.Length;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            data = new int[data.Length];
            size = 0;
        }

        public int CountOccurences(int n)
        {
            return data.Count(x => x == n);
        }

        public override string ToString()
        {
            var list = new int[size];

            for (var i = 0; i < size; i++)
            {
                list[i] = data[i];
            }

            return size == 0 ? "NIL" : JsonSerializer.Serialize(list);
        }
    }
}
