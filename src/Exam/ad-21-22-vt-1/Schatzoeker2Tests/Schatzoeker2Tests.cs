using NUnit.Framework;

namespace AD
{
    [TestFixture]
    public partial class SchatZoeker2Tests
    {
        [TestCase(0, 2, 2, 1, new int[] { 0, 1 }, new int[] { 1, 3 }, 11)]
        [TestCase(0, 3, 4, 1, new int[] { 0, 1, 2, 3 }, new int[] { 0, 3, 3, 0 }, 12)]
        [TestCase(0, 0, 0, 0, new int[] { 4 }, new int[] { 4 }, 0)]
        [TestCase(0, 4, 0, 0, new int[] { 4 }, new int[] { 4 }, 1)]
        [TestCase(0, 0, 4, 0, new int[] { 0, 1, 2, 3 }, new int[] { 0, 0, 0, 0 }, 4)]
        [TestCase(0, 0, 4, 0, new int[] { 0, 1, 2, 3 }, new int[] { 4, 3, 2, 1 }, 24)]
        [TestCase(0, 4, 4, 4, new int[] { 0, 1, 2, 3 }, new int[] { 3, 2, 1, 0 }, 24)]
        public void SchatZoeker2Test(int start_row, int start_col, int treasure_row, int treasure_col,
            int[] obstakel_row, int[] obstakel_col, int expected)
        {
            // Arrange
            char[,] arr = new char[5,5];
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    arr[i, j] = '.';
            arr[treasure_row, treasure_col] = 'X';
            for (int i = 0; i < obstakel_col.Length; i++)
                arr[obstakel_row[i], obstakel_col[i]] = '@';

            // Act
            int actual = Schatzoeker2.ZoekSchat(arr, start_row, start_col);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}