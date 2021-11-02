
namespace AD
{
    public partial class MyLinkedList<T> : IMyLinkedList<T>
    {
        public (MyLinkedList<T>, MyLinkedList<T>) Splits()
        {
            var left = new MyLinkedList<T>();
            var right = new MyLinkedList<T>();

            var count = 0;
            while (this.size > 0)
            {
                var tmp = this.GetFirst();
                this.RemoveFirst();

                // Determine if we want to add left or right
                if (count % 2 == 0)
                {
                    left.Insert(left.Size(), tmp);
                }
                else
                {
                    right.Insert(right.Size(), tmp);
                }

                count++;

            }

            return (left, right);
        }

        public void Rits(MyLinkedList<T> list1, MyLinkedList<T> list2)
        {
            var count = 0;
            while (list1.size > 0 || list2.size > 0)
            {
                var tmpList = count % 2 == 0 ? list1 : list2;

                // If the list is empty, use the other list
                if (tmpList.Size() == 0)
                {
                    tmpList = count % 2 == 0 ? list2 : list1;
                }

                var tmp = tmpList.GetFirst();
                tmpList.RemoveFirst();
                
                this.Insert(this.Size(), tmp);

                count++;
            }
        }
    }
}
