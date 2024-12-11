using System.Text.RegularExpressions;

namespace AdventOfCode2024.src
{
    internal class Day3
    {
        public static int GetMultiplicationsSum_v1()
        {
            return FileReader.ReadLines("3")
                            .Select(line => Regex
                                            .Matches(line, @"(?<=mul\()\d+,\d+(?=\))")
                                            .Select(m => m.Value
                                                            .Split(',')
                                                            .Select(n => int.Parse(n))
                                                            .Aggregate((x, y) => x * y))
                                            .Sum())
                            .Sum();
        }

        public static int GetMultiplicationsSum_v2()
        {
            string line = string.Join(string.Empty, FileReader.ReadLines("3"));
            var matches = Regex.Matches(line, @"(?<=mul\()\d+,\d+(?=\))|do\(\)|don't\(\)");

            int sum = 0;
            bool isAvailable = true;

            foreach (Match match in matches.Cast<Match>())
            {
                if (match.Value == "do()")
                {
                    isAvailable = true;
                }
                else if (match.Value == "don't()")
                {
                    isAvailable = false;
                }
                else if (isAvailable)
                {
                    var numbers = match.Value.Split(',');
                    sum += int.Parse(numbers[0]) * int.Parse(numbers[1]);
                }
            }
            return sum;
        }
    }
}
