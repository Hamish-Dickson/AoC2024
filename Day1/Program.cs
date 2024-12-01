
namespace Day1
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
            IEnumerable<string> lines = File.ReadLines("input.txt");

            List<int> firstList = [];
            List<int> secondList = [];

            foreach (string line in lines)
            {
                string[] parts = line.Split("   ");
                
                firstList.Add(int.Parse(parts[0]));
                secondList.Add(int.Parse(parts[1]));
            }

            firstList.Sort();
            secondList.Sort();

            int distance = 0;

            for (int i = 0; i < firstList.Count; i++)
            {
                distance += Math.Abs(firstList[i] - secondList[i]);
            }
            
            Console.WriteLine("Puzzle part 1: " + distance);
        }

        private static void Part2()
        {
            IEnumerable<string> lines = File.ReadLines("input.txt");
            Dictionary<int, int> counts = [];
            List<int> toCount = [];

            foreach (string line in lines)
            {
                string[] parts = line.Split("   ");
                counts.TryAdd(int.Parse(parts[0]), 0);
                toCount.Add(int.Parse(parts[1]));
            }

            foreach (int key in counts.Keys)
            {
                counts[key] = key * toCount.Count(x => x == key);
            }
            
            Console.WriteLine("Puzzle part 2: " + counts.Values.Sum());
        }
    }
}