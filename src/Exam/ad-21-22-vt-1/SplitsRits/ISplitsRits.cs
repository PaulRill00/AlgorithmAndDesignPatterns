namespace AD
{
    public partial interface IMyLinkedList<T>
    {
        public (MyLinkedList<T>, MyLinkedList<T>) Splits();

        public void Rits(MyLinkedList<T> list1, MyLinkedList<T> list2);

    }
}
