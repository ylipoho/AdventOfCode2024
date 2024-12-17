namespace AdventOfCode2024.src
{
    internal class Day5
    {
        public static int GetMiddleElementsSum(int taskPart)
        {
            var lines = FileReader.ReadLines("5");
            var rules = lines.Where(line => line.Contains('|'))
                            .Select(line => line.Split('|'));
            var updatesLines = lines.Where(line => line.Contains(','));
            int sum = 0;

            if (taskPart == 1)
            {
                foreach (string line in updatesLines.Where(line => IsLineCorrect(line, rules)))
                {
                    var numbers = line.Split(',');
                    sum += int.Parse(numbers[numbers.Length / 2]);
                }
            }
            else
            {
                foreach (string line in updatesLines.Where(line => !IsLineCorrect(line, rules)))
                {
                    var numbers = line.Split(',');
                    Array.Sort(numbers, (first, second) => IsRuleBroken(first, second, rules) ? 1 : -1); 
                    sum += int.Parse(numbers[numbers.Length / 2]);
                }
            }

            return sum;
        }

        static bool IsRuleBroken(string first, string second, IEnumerable<string[]> rules) =>
                        rules.Any(rule => $"{rule.First()}|{rule.Last()}" == $"{second}|{first}");

        static bool IsLineCorrect(string line, IEnumerable<string[]> rules)
        {
            foreach (var rule in rules)
            {
                int leftPageIndex = line.IndexOf(rule[0]);
                int rightPageIndex = line.IndexOf(rule[1]);

                if (rightPageIndex > -1 && (leftPageIndex > rightPageIndex))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
