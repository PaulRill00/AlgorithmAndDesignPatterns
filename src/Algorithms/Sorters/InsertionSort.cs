using System.Collections.Generic;


namespace AD
{
    public partial class InsertionSort : Sorter
    {
        public override void Sort(List<int> list, int lo, int hi)
        {
            for (var j = 1; j < list.Count; j++)
            {
                var key = list[j];
                var i = j - 1;

                while (i >= 0 && list[i] > key)
                {
                    list[i + 1] = list[i];
                    i--;
                }

                list[i + 1] = key;
            }

            Sort(list, 0, list.Count - 1);
        }
    }
}
