using System;
using System.Collections.Generic;

namespace AD
{
    public partial class MergeSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            InternalSort(list, 0, list.Count - 1);
        }

        public void InternalSort(List<int> list, int left, int right)
        {
            if (left >= right) return;

            var center = (int) Math.Ceiling((decimal) (left + right)) / 2;
            InternalSort(list, left, center);
            InternalSort(list, center + 1, right);
            Merge(list, left, center, right);
        }

        public void Merge(List<int> list, int left, int center, int right)
        {
            var n1 = center - left + 1;
            var n2 = right - center;

            var leftList = list.GetRange(left, n1);
            var rightList = list.GetRange(center + 1, n2);

            Console.WriteLine(leftList);

            leftList.Add(int.MaxValue);
            rightList.Add(int.MaxValue);

            var i = 0;
            var j = 0;

            int k;
            for (k = left; k < right; k++)
            {
                if (leftList[i] <= rightList[j])
                {
                    list[k] = leftList[i];
                    i++;
                }
                else
                {
                    list[k] = rightList[j];
                    j++;
                }
            }

            while (i < n1)
            {
                list[k] = leftList[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                list[k] = rightList[j];
                j++;
                k++;
            }
        }

    }
}
