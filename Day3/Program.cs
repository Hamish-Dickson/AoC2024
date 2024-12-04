using System.Text.RegularExpressions;

namespace Day3
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
            string input = File.ReadAllText("input.txt");
            int result = 0;

            MatchCollection validInstructions = Regex.Matches(input, @"[m][u][l][(][0-9]*[,][0-9]*[)]");

            foreach (Match possibleInstruction in validInstructions)
            {
                string instruction = possibleInstruction.Value;
                instruction = instruction.Replace("mul(", "");
                instruction = instruction.Replace(")", "");
                
                string[] split = instruction.Split(',');
                int firstNum = int.Parse(split[0]);
                int secondNum = int.Parse(split[1]);
                
                result += firstNum * secondNum;
            }
            Console.WriteLine("Puzzle part 1: " + result);
        }

        private static void Part2()
        {
            string input = File.ReadAllText("input.txt");
            int result = 0;

            MatchCollection validInstructions = Regex.Matches(input, @"[m][u][l][(][0-9]*[,][0-9]*[)]");

            foreach (Match possibleInstruction in validInstructions)
            {
                string instruction = possibleInstruction.Value;

                int instructionIndex = input.IndexOf(instruction, StringComparison.InvariantCulture);
                string partialInput = input.Remove(instructionIndex, input.Length - instructionIndex);
                
                int doIndex = partialInput.LastIndexOf("do()", StringComparison.InvariantCulture);
                int dontIndex = partialInput.LastIndexOf("don't()", StringComparison.InvariantCulture);

                if (dontIndex > doIndex)
                {
                    continue;
                }
                
                instruction = instruction.Replace("mul(", "");
                instruction = instruction.Replace(")", "");
                
                string[] split = instruction.Split(',');
                int firstNum = int.Parse(split[0]);
                int secondNum = int.Parse(split[1]);
                
                result += firstNum * secondNum;
            }
            Console.WriteLine("Puzzle part 2: " + result);            
        }
    }
}
