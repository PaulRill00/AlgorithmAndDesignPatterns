using System;
using System.Collections.Generic;


namespace AD
{
    public partial class QuickSort : Sorter
    {
        private static int CUTOFF = 11;

        public override void Sort(List<int> list)
        {
            this.InternalSort(list, 0, list.Count - 1);
        }

        private void InternalSort(List<int> list, int low, int high)
        {
            if (high < low) return;
            if (high - low < CUTOFF)
            {
                new InsertionSort().Sort(list);
                return;
            }

            var mid = (int)Math.Floor((decimal)(low + high)) / 2;

            var values = new List<int>() { list[low], list[mid], list[high] };
            values.Sort();
            var pivot = values[1];
            var pivotIndex = list.FindIndex(x => x == pivot);

            // Put pivot at the end
            var highest = list[high];
            list[high] = pivot;
            list[pivotIndex] = highest;
            high--;

            var i = low;
            var j = high;

            while (i < j)
            {
                while (list[i] < pivot)
                {
                    i++;
                }

                while (list[j] > pivot)
                {
                    j--;
                }

                if (i < j)
                {
                    var mem = list[i];
                    list[i] = list[j];
                    list[j] = mem;
                }
            }

            var bound = list[i];
            list[i] = pivot;
            list[high + 1] = bound;

            InternalSort(list, low, j);
            InternalSort(list, i + 1, high + 1);
        }
    }
}
