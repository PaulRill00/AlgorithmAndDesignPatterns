using NUnit.Framework;

namespace AD
{
    [TestFixture]
    public partial class SplitsRitsTests
    {
        [TestCase(new int[] { }, "NIL", "NIL")]
        [TestCase(new int[] { 5 }, "[5]", "NIL")]
        [TestCase(new int[] { 5, 4 }, "[4]", "[5]")]
        [TestCase(new int[] { 5, 4, 3 }, "[3,5]", "[4]")]
        [TestCase(new int[] { 5, 4, 3, 2 }, "[2,4]", "[3,5]")]
        [TestCase(new int[] { 5, 4, 3, 2, 1 }, "[1,3,5]", "[2,4]")]
        public void SplitsRits_01_Splits(int[] arr, string expected1, string expected2)
        {
            // Arrange
            MyLinkedList<int> l = new MyLinkedList<int>();
            MyLinkedList<int> a, b;

            foreach (int val in arr)
            {
                l.AddFirst(val);
            }

            // Act
            (a, b) = l.Splits();

            // Assert
            Assert.AreEqual(expected1, TestUtils.TrimmedStringWithoutSpaces(a.ToString()));
            Assert.AreEqual(expected2, TestUtils.TrimmedStringWithoutSpaces(b.ToString()));
        }


        [TestCase(new int[] { }, new int[] { }, "NIL")]
        [TestCase(new int[] { 5, 3, 1 }, new int[] { 4, 2 }, "[1,2,3,4,5]")]
        [TestCase(new int[] { 8, 7, 6, 5, 3, 1 }, new int[] { 4, 2 }, "[1,2,3,4,5,6,7,8]")]
        [TestCase(new int[] { 5, 4, 3, 2, 1 }, new int[] { }, "[1,2,3,4,5]")]
        [TestCase(new int[] { }, new int[] { 5, 4, 3, 2, 1 }, "[1,2,3,4,5]")]
        public void SplitsRits_02_Rits(int[] arr1, int[] arr2, string expected)
        {
            // Arrange
            MyLinkedList<int> a = new MyLinkedList<int>();
            MyLinkedList<int> b = new MyLinkedList<int>();
            MyLinkedList<int> l = new MyLinkedList<int>();

            foreach (int val in arr1)
            {
                a.AddFirst(val);
            }
            foreach (int val in arr2)
            {
                b.AddFirst(val);
            }

            // Act
            l.Rits(a, b);

            // Assert
            Assert.AreEqual(expected, TestUtils.TrimmedStringWithoutSpaces(l.ToString()));
        }
    }
}
