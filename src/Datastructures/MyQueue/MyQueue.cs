using System.Collections.Generic;

namespace AD
{
    public partial class MyQueue<T> : IMyQueue<T>
    {
        private MyLinkedList<T> list;

        public MyQueue()
        {
            list = new MyLinkedList<T>();
        }

        public bool IsEmpty()
        {
            return list.Size() == 0;
        }

        public void Enqueue(T data)
        {
            var size = list.Size();
            list.Insert(size, data);
        }

        public T GetFront()
        {
            try
            {
                return list.GetFirst();
            }
            catch (MyLinkedListEmptyException)
            {
                throw new MyQueueEmptyException();
            }
        }

        public T Dequeue()
        {
            try
            {
                var first = list.GetFirst();
                list.RemoveFirst();
                return first;
            }
            catch (MyLinkedListEmptyException)
            {
                throw new MyQueueEmptyException();
            }
        }

        public void Clear()
        {
            list.Clear();
        }

    }
}