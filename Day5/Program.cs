namespace Day5
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
            int result = 0;
            HashSet<KeyValuePair<int, int>> orderRules = [];
            
            IEnumerable<string> orders = File.ReadLines("order.txt");
            foreach (string order in orders)
            {
                string[] orderParts = order.Split('|');
                orderRules.Add(new KeyValuePair<int, int>(int.Parse(orderParts[0]), int.Parse(orderParts[1])));
            }
            
            IEnumerable<string> prints = File.ReadLines("prints.txt");

            foreach (string print in prints)
            {
                CheckPrintsIsValid(print);
            }

            Console.WriteLine("Puzzle part 1: " + result);
            return;

            void CheckPrintsIsValid(string input)
            {
                string[] printParts = input.Split(',');
                bool valid = true;
                for (int i = 0; i < printParts.Length; i++)
                {
                    string part = printParts[i];
                    if (!CheckValid(part, printParts[(i + 1)..]))
                    {
                        valid = false;
                        break;
                    }
                }

                if (valid)
                {
                    result += int.Parse(printParts[(printParts.Length - 1) / 2]);
                }

                return;

                bool CheckValid(string part, string[] followingParts)
                {
                    int partToCheck = int.Parse(part);
                    int[] numbers = followingParts.Select(int.Parse).ToArray();
                    return !orderRules.Any(x => x.Value == partToCheck && numbers.Contains(x.Key));
                }
            }
        }

        private static void Part2()
        {
            int result = 0;
            HashSet<KeyValuePair<int, int>> orderRules = [];
            
            IEnumerable<string> orders = File.ReadLines("order.txt");
            foreach (string order in orders)
            {
                string[] orderParts = order.Split('|');
                orderRules.Add(new KeyValuePair<int, int>(int.Parse(orderParts[0]), int.Parse(orderParts[1])));
            }
            
            string[] prints = File.ReadLines("prints.txt").ToArray();
            IEnumerable<string> invalidPrints = prints.Where(print => !CheckPrintsIsValid(print));
            foreach (string x in invalidPrints)
            {
                ValidateAndCalculatePrint(x);
                continue;
                void ValidateAndCalculatePrint(string print)
                {
                    List<string> printParts = print.Split(',').ToList();
                    KeyValuePair<int, int>[] applicableRules = orderRules.Where(pair => printParts.Select(int.Parse).Contains(pair.Value)).ToArray();

                    printParts.Sort(delegate(string x, string y)
                    {
                        if (applicableRules.Any(val => val.Key == int.Parse(x) && val.Value == int.Parse(y)))
                        {
                            return 1;
                        }

                        return -1;
                    });
                    
                    result += int.Parse(printParts[(printParts.Count - 1) / 2]);
                }
            }
            
            Console.WriteLine("Puzzle part 2: " + result);

            return;

            bool CheckPrintsIsValid(string input)
            {
                string[] printParts = input.Split(',');
                bool valid = true;
                for (int i = 0; i < printParts.Length; i++)
                {
                    string part = printParts[i];
                    if (!CheckValid(part, printParts[(i + 1)..]))
                    {
                        valid = false;
                        break;
                    }
                }

                return valid;

                bool CheckValid(string part, string[] followingParts)
                {
                    int partToCheck = int.Parse(part);
                    int[] numbers = followingParts.Select(int.Parse).ToArray();
                    return !orderRules.Any(x => x.Value == partToCheck && numbers.Contains(x.Key));
                }
            }
        }
    }
}
