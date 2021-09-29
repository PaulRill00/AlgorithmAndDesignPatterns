namespace AD
{
    public partial class MyLinkedList<T> : IMyLinkedList<T>
    {
        public MyLinkedListNode<T> first;
        private int size;

        public MyLinkedList()
        {
            this.first = null;
            this.size = 0;
        }

        public void AddFirst(T data)
        {
            var newNode = new MyLinkedListNode<T>(data);

            if (first != null)
            {
                newNode.SetNext(first);
            }

            first = newNode;
            size++;
        }

        public T GetFirst()
        {
            if (this.first == null)
            {
                throw new MyLinkedListEmptyException();
            }

            return this.first.data;
        }

        public void RemoveFirst()
        {
            if (this.first == null)
            {
                throw new MyLinkedListEmptyException();
            }

            this.first = this.first.next;
            size--;
            size = size < 0 ? 0 : size;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            this.first = null;
            this.size = 0;
        }

        public void Insert(int index, T data)
        {
            MyLinkedListNode<T> prev = null;
            var next = this.first;
            var currentIndex = 0;

            while (currentIndex < index && next != null)
            {
                currentIndex++;
                prev = next;
                next = next.GetNext();
            }

            if (currentIndex != index)
            {
                throw new MyLinkedListIndexOutOfRangeException();
            }

            var nextNode = new MyLinkedListNode<T>(data);

            prev?.SetNext(nextNode);
            nextNode.SetNext(next);

            if (index == 0)
            {
                this.first = nextNode;
            }

            this.size++;
        }

        public override string ToString()
        {
            var ret = "[";

            var next = this.first;
            while (next != null)
            {
                ret += next.data + ",";
                next = next.next;
            }

            ret = ret.Substring(0, ret.Length - 1) + "]";

            return ret == "]" ? "NIL" : ret;
        }
    }
}