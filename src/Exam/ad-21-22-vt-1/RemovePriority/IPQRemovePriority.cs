namespace AD
{
    public partial interface IPriorityQueue<T>
        where T : System.IComparable<T>
    {
        public int[] RemovePriority(T t);
    }
}
