namespace Day4
{
    internal static class Program
    {
        public static void Main()
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            int rowWidth = File.ReadLines("input.txt").First().Length;
            string input = File.ReadAllText("input.txt");

            int upBy1 = -rowWidth - 1;
            int downBy1 = rowWidth + 1;
            int leftBy1 = -1;
            int rightBy1 = 1;
            int diagonalDownRight = downBy1 + rightBy1;
            int diagonalDownLeft = downBy1 + leftBy1;
            int diagonalUpRight = upBy1 + rightBy1;
            int diagonalUpLeft = upBy1 + leftBy1;

            int result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];
                if (letter == 'X')
                {
                    CheckXmas(i);
                }
            }

            Console.WriteLine("Puzzle part 1: " + result);
            return;

            void CheckXmas(int startIndex)
            {
                if (CheckInput(startIndex, upBy1))
                {
                    result++;
                }

                if (CheckInput(startIndex, downBy1))
                {
                    result++;
                }

                if (CheckInput(startIndex, rightBy1))
                {
                    result++;
                }

                if (CheckInput(startIndex, leftBy1))
                {
                    result++;
                }

                if (CheckInput(startIndex, diagonalDownRight))
                {
                    result++;
                }
                
                if (CheckInput(startIndex, diagonalDownLeft))
                {
                    result++;
                }
                
                if (CheckInput(startIndex, diagonalUpRight))
                {
                    result++;
                }
                
                if (CheckInput(startIndex, diagonalUpLeft))
                {
                    result++;
                }
            }

            bool CheckInput(int startIndex, int offset)
            {
                return input.ElementAtOrDefault(startIndex + offset) == 'M' && input.ElementAtOrDefault(startIndex + offset * 2) == 'A' && input.ElementAtOrDefault(startIndex + offset * 3) == 'S';
            }
        }

        private static void Part2()
        {
            int rowWidth = File.ReadLines("input.txt").First().Length;
            string input = File.ReadAllText("input.txt");

            int upBy1 = -rowWidth - 1;
            int downBy1 = rowWidth + 1;
            int leftBy1 = -1;
            int rightBy1 = 1;
            int diagonalDownRight = downBy1 + rightBy1;
            int diagonalDownLeft = downBy1 + leftBy1;
            int diagonalUpRight = upBy1 + rightBy1;
            int diagonalUpLeft = upBy1 + leftBy1;

            int result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];
                if (letter == 'A')
                {
                    CheckXmas(i);
                }
            }

            Console.WriteLine("Puzzle part 2: " + result);
            return;

            void CheckXmas(int startIndex)
            {
                if (((input.ElementAtOrDefault(startIndex - diagonalUpLeft) == 'M' && input.ElementAtOrDefault(startIndex - diagonalDownRight) == 'S')
                    || (input.ElementAtOrDefault(startIndex - diagonalUpLeft) == 'S' && input.ElementAtOrDefault(startIndex - diagonalDownRight) == 'M'))
                    && ((input.ElementAtOrDefault(startIndex - diagonalUpRight) == 'M' && input.ElementAtOrDefault(startIndex - diagonalDownLeft) == 'S')
                        || (input.ElementAtOrDefault(startIndex - diagonalUpRight) == 'S' && input.ElementAtOrDefault(startIndex - diagonalDownLeft) == 'M')))
                {
                    result++;
                }
            }
        }
    }
}
