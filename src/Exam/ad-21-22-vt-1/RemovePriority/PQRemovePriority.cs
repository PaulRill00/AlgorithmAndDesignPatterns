using System;
using System.Collections.Generic;

namespace AD
{
    public partial class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable<T>
    {
        public int[] RemovePriority(T t)
        {
            // Keep a copy of the array so we can clear the Priority Queue
            var tmp = (T[]) this.array.Clone();
            var tmpSize = this.size;
            this.Clear();

            var removedCount = 0;
            var removed = new int[tmpSize];
            
            // Loop over all elements, and filter the elements we want to remove
            for (var i = 1; i <= tmpSize; i++)
            {
                if (tmp[i].Equals(t))
                {
                    removed[removedCount++] = i;
                }
                else
                {
                    this.AddFreely(tmp[i]);
                }
            }   

            // Rebuild the Priority Queue
            this.BuildHeap();

            // Make sure only the actual size is returned
            var result = new int[removedCount];
            Array.Copy(removed, 0, result, 0, removedCount);

            return result;
        }
        
    }
}
