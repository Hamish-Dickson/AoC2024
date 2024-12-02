namespace Day2
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
            int safe = 0;

            foreach (string line in lines)
            {
                if (CheckSafe(line))
                {
                    safe++;
                }
                continue;

                bool CheckSafe(string s)
                {
                    List<int> levels = s.Split(" ").Select(int.Parse).ToList();

                    bool isSafe = true;
                    
                    bool isAscending = levels.Last() > levels.First();

                    for (int i = 0; i < levels.Count - 1; i++)
                    {
                        int thisLevel = levels[i];
                        int nextLevel = levels[i + 1];
                        if (isAscending)
                        {
                            if (thisLevel > nextLevel)
                            {
                                isSafe = false;
                                break;
                            }
                        }
                        else
                        {
                            if (thisLevel < nextLevel)
                            {
                                isSafe = false;
                                break;
                            }
                        }
                        int step = Math.Abs(thisLevel - nextLevel);
                        if (step is < 1 or > 3)
                        {
                            isSafe = false;
                        }
                    }
                    return isSafe;
                }
            }

            Console.WriteLine("Puzzle part 1: " + safe);
        }

        private static void Part2()
        {
            IEnumerable<string> lines = File.ReadLines("input.txt");
            int safe = 0;

            foreach (string line in lines)
            {
                List<int> levels = line.Split(" ").Select(int.Parse).ToList();
                
                if (CheckSafe(levels))
                {
                    safe++;
                }
                else
                {
                    for (int i = 0; i < levels.Count; i++)
                    {
                        List<int> modifiedLevels = new(levels);
                        modifiedLevels.RemoveAt(i);
                        if (CheckSafe(modifiedLevels))
                        {
                            safe++;
                            break;
                        }
                    }
                }
                continue;

                bool CheckSafe(List<int> levels)
                {
                    bool isSafe = true;
                    
                    bool isAscending = levels.Last() > levels.First();

                    for (int i = 0; i < levels.Count - 1; i++)
                    {
                        int thisLevel = levels[i];
                        int nextLevel = levels[i + 1];
                        if (isAscending)
                        {
                            if (thisLevel > nextLevel)
                            {
                                isSafe = false;
                                break;
                            }
                        }
                        else
                        {
                            if (thisLevel < nextLevel)
                            {
                                isSafe = false;
                                break;
                            }
                        }
                        int step = Math.Abs(thisLevel - nextLevel);
                        if (step is < 1 or > 3)
                        {
                            isSafe = false;
                        }
                    }
                    return isSafe;
                }
            }

            Console.WriteLine("Puzzle part 2: " + safe);
        }
    }
}