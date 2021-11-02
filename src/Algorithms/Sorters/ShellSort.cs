using System;
using System.Collections.Generic;


namespace AD
{
    public partial class ShellSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            for (var interval = list.Count / 2; interval > 0; interval /= 2)
            {
                for (var i = interval; i < list.Count; i++)
                {
                    var temp = list[i];
                    var j = i;
                    for (; j >= interval && list[j - interval] > temp; j -= interval)
                    {
                        list[j] = list[j - interval];
                    }

                    list[j] = temp;
                }
            }
        }
    }
}
