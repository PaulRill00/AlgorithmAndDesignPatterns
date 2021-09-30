    namespace AD
{
    public partial class FirstChildNextSiblingNode<T> : IFirstChildNextSiblingNode<T>
    {
        public FirstChildNextSiblingNode<T> firstChild;
        public FirstChildNextSiblingNode<T> nextSibling;
        public T data;

        public FirstChildNextSiblingNode(T data, FirstChildNextSiblingNode<T> firstChild, FirstChildNextSiblingNode<T> nextSibling): this(data)
        {
            this.firstChild = firstChild;
            this.nextSibling = nextSibling;
        }

        public FirstChildNextSiblingNode(T data)
        {
            this.data = data;
        }

        public T GetData()
        {
            return this.data;
        }

        public FirstChildNextSiblingNode<T> GetFirstChild()
        {
            return this.firstChild;
        }

        public FirstChildNextSiblingNode<T> GetNextSibling()
        {
            return this.nextSibling;
        }

        public override string ToString()
        {
            var res = $"{data}";
            if (this.firstChild != null)
            {
                res += $",FC({this.firstChild})";
            }

            if (this.nextSibling != null)
            {
                res += $",NS({this.nextSibling})";
            }
            return res;
        }
    }
}