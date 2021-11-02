using NUnit.Framework;

namespace AD
{
    [TestFixture]
    public partial class PQRemovePriorityTests
    {
        public static IPriorityQueue<int> CreateExamPriorityQueue(int[] items)
        {
            IPriorityQueue<int> q = DSBuilder.CreatePriorityQueueEmpty();

            for (int i = 0; i < items.Length; i++)
            {
                q.Add(items[i]);
            }

            return q;
        }

        public static bool IsPriorityQueue(IPriorityQueue<int> pq)
        {
            // We cannot look inside the interface,
            // however we can do a ToString and then check
            // the result of that. Just keep in mind to
            // check the proper indices!

            string[] pq_strings = TestUtils.TrimmedStringWithSingleSpaces(pq.ToString()).Split(" ");

            for (int i = 1; i < pq_strings.Length; i++)
            {
                int parent = (i + 1) / 2 - 1;

                if (System.Int32.Parse(pq_strings[i]) < System.Int32.Parse(pq_strings[parent]))
                    return false;
            }
            return true;
        }

        [TestCase(new int[] { 2, 4, 2, 7, 5, 2, 8, 6 }, 2, 5)]
        [TestCase(new int[] { }, 2, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 1, 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 6, 5)]
        [TestCase(new int[] { 5, 9, 6, 12, 15, 8 }, 12, 5)]
        [TestCase(new int[] { 2, 2, 4, 2, 5, 7, 8, 6 }, 2, 5)]
        [TestCase(new int[] { 2, 4, 2, 7, 5, 2, 8, 6 }, 9, 8)]
        public void PQRemovePriority_01_RemovePriority_01_SizeOk(
            int[] input,
            int priorityToRemove,
            int expected)
        {
            // Arrange
            IPriorityQueue<int> pq = CreateExamPriorityQueue(input);

            // Act
            int[] indices = pq.RemovePriority(priorityToRemove);
            int actual = pq.Size();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 4, 2, 7, 5, 2, 8, 6 }, 2, new int[] { 1, 3, 6 })]
        [TestCase(new int[] { }, 2, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 1, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 6, new int[] { 6 })]
        [TestCase(new int[] { 5, 9, 6, 12, 15, 8 }, 12, new int[] { 4 })]
        [TestCase(new int[] { 2, 2, 4, 2, 5, 7, 8, 6 }, 2, new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 2, 4, 2, 7, 5, 2, 8, 6 }, 9, new int[] { })]
        public void PQRemovePriority_01_RemovePriority_02_IndicesOk(
            int[] input,
            int priorityToRemove,
            int[] expected)
        {
            // Arrange
            IPriorityQueue<int> pq = CreateExamPriorityQueue(input);

            // Act
            int[] actual = pq.RemovePriority(priorityToRemove);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 4, 2, 7, 5, 2, 8, 6 }, 2, new int[] { 4, 5, 7, 8, 6 })]
        [TestCase(new int[] { }, 2, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 1, new int[] { 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 6, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 5, 9, 6, 12, 15, 8 }, 12, new int[] { 5, 9, 6, 15, 8 })]
        [TestCase(new int[] { 2, 2, 4, 2, 5, 7, 8, 6 }, 2, new int[] { 4, 5, 7, 8, 6 })]
        [TestCase(new int[] { 2, 4, 2, 7, 5, 2, 8, 6 }, 9, new int[] { 2, 4, 2, 7, 5, 2, 8, 6 })]
        public void PQRemovePriority_01_RemovePriority_03_PQContentsOk(
            int[] input,
            int priorityToRemove,
            int[] expected)
        {
            // Arrange
            IPriorityQueue<int> pq = CreateExamPriorityQueue(input);

            // Act
            pq.RemovePriority(priorityToRemove);
            System.Array.Sort(expected);
            int[] actual = new int[pq.Size()];
            int i = 0;
            while (pq.Size() > 0)
            {
                actual[i] = pq.Remove();
                i++;
            }

            // Assert
            Assert.AreEqual(string.Join(",", expected), string.Join(",", actual));
        }

        [TestCase(new int[] { 2, 4, 2, 7, 5, 2, 8, 6 }, 2)]
        [TestCase(new int[] { }, 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 6)]
        [TestCase(new int[] { 5, 9, 6, 12, 15, 8 }, 12)]
        [TestCase(new int[] { 2, 2, 4, 2, 5, 7, 8, 6 }, 2)]
        [TestCase(new int[] { 2, 4, 2, 7, 5, 2, 8, 6 }, 9)]
        public void PQRemovePriority_01_RemovePriority_04_PQIsStillPQ(
            int[] input,
            int priorityToRemove)
        {
            // Arrange
            IPriorityQueue<int> pq = CreateExamPriorityQueue(input);

            // Act
            pq.RemovePriority(priorityToRemove);

            // Assert
            Assert.IsTrue(IsPriorityQueue(pq), pq.ToString());
        }

    }
}
