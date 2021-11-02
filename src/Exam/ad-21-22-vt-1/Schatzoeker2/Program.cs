using System;

namespace AD
{
    public class Schatzoeker2
    {
        public static int ZoekSchat(char[,] arr, int row, int col)
        {
            switch (arr[row, col])
            {
                // Stop found
                case 'X':
                    return 0;
                
                // Go to next row
                case '@':
                    row++;
                    row %= arr.GetLength(0);
                    break;

                // Go to next col
                default:
                    col++;
                    col %= arr.GetLength(0);
                    break;
            }

            // Search again
            return ZoekSchat(arr, row, col) + 1;
        }

        static void Main(string[] args)
        {
            char[,] arr1 =
            {
                {'.', '@', '.', '.', '.' },
                {'.', '.', '.', '@', '.' },
                {'.', 'X', '.', '.', '.' },
                {'.', '.', '.', '.', '.' },
                {'.', '.', '.', '.', '.' },
            };
            char[,] arr2 =
            {
                {'@', '.', '.', '.', '.' },
                {'.', '.', '.', '@', '.' },
                {'.', '.', '.', '@', '.' },
                {'@', '.', '.', '.', '.' },
                {'.', 'X', '.', '.', '.' },
            };
            Console.WriteLine(ZoekSchat(arr1, 0, 2));
            Console.WriteLine(ZoekSchat(arr2, 0, 3));
        }
    }
}
