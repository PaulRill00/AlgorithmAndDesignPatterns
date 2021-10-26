using System;

namespace AD
{
    public class MIBNode : IComparable<MIBNode>
    {
        public string oid;
        public string name;

        public MIBNode(string oid, string name)
        {
            this.oid = oid;
            this.name = name;
        }

        public int CompareTo(MIBNode other)
        {
            return oid.CompareTo(other.oid);
        }

        public override string ToString()
        {
            return $"{oid}: {name}";
        }

        public override bool Equals(object? obj)
        {
            var node = obj as MIBNode;
            return node != null && oid.Equals(node.oid);
        }
    }
}
