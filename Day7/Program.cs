namespace Day7
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
            string[] lines = File.ReadAllLines("input.txt");
            HashSet <(long total, int[] tests)> inputValues = [];
            List<long> testVals = [];
            foreach (string line in lines)
            {
                string[] splits = line.Split(':');
                string[] nums = splits[1].Trim().Split(" ");
                List<int> toAdd = [];
                toAdd.AddRange(nums.Select(int.Parse));
                inputValues.Add((long.Parse(splits[0]), toAdd.ToArray()));
            }

            foreach ((long total, int[] tests) value in inputValues)
            {
                if (SolutionValid(value.tests, value.total, 0, value.tests[0]))
                {
                    testVals.Add(value.total);
                }
                continue;

                static bool SolutionValid(int[] numbers, long target, int index,  long currentValue)
                {
                    if (index == numbers.Length - 1)
                    {
                        return currentValue == target;
                    }

                    int nextNumber = numbers[index + 1];

                    if (SolutionValid(numbers, target, index + 1, currentValue + nextNumber))
                    {
                        return true;
                    }

                    if (SolutionValid(numbers, target, index + 1, currentValue * nextNumber))
                    {
                        return true;
                    }

                    return false;
                }
            }
            
            Console.WriteLine("Puzzle part 1: " + testVals.Sum());
        }
        
        private static void Part2()
        {
            string[] lines = File.ReadAllLines("input.txt");
            HashSet <(long total, int[] tests)> inputValues = [];
            List<long> testVals = [];
            foreach (string line in lines)
            {
                string[] splits = line.Split(':');
                string[] nums = splits[1].Trim().Split(" ");
                List<int> toAdd = [];
                toAdd.AddRange(nums.Select(int.Parse));
                inputValues.Add((long.Parse(splits[0]), toAdd.ToArray()));
            }

            foreach ((long total, int[] tests) value in inputValues)
            {
                if (SolutionValid(value.tests, value.total, 0, value.tests[0]))
                {
                    testVals.Add(value.total);
                }
                continue;

                static bool SolutionValid(int[] numbers, long target, int index,  long currentValue)
                {
                    if (index == numbers.Length - 1)
                    {
                        return currentValue == target;
                    }

                    int nextNumber = numbers[index + 1];

                    if (SolutionValid(numbers, target, index + 1, currentValue + nextNumber))
                    {
                        return true;
                    }

                    if (SolutionValid(numbers, target, index + 1, currentValue * nextNumber))
                    {
                        return true;
                    }
                    
                    long concatenatedValue = long.Parse("" + currentValue + nextNumber);
                    if (SolutionValid(numbers, target, index + 1, concatenatedValue))
                    {
                        return true;
                    }

                    return false;
                }
            }
            
            Console.WriteLine("Puzzle part 2: " + testVals.Sum());
        }
    }
}