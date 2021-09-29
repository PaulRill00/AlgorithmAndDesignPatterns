namespace AD
{
    public partial class MyLinkedListNode<T>
    {
        public T data;
        public MyLinkedListNode<T> next;

        public MyLinkedListNode(T data)
        {
            this.data = data;
        }

        public void SetNext(MyLinkedListNode<T> next)
        {
            this.next = next;
        }

        public MyLinkedListNode<T> GetNext()
        {
            return this.next;
        }
    }
}
