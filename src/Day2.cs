namespace AdventOfCode2024.src
{
    internal class Day2
    {
        public static int GetSafeReportsNum_v1()
        {
            var lines = FileReader
                            .ReadLines("2")
                            .Select(l => l
                                        .Split(' ')
                                        .Select(n => int.Parse(n))
                                        .ToList());

            return lines.Count(l => AreConditionsMet(l));
        }

        public static int GetSafeReportsNum_v2()
        {
            var lines = FileReader
                            .ReadLines("2")
                            .Select(l => l
                                        .Split(' ')
                                        .Select(n => int.Parse(n))
                                        .ToList());

            int sum = 0;
            
            foreach (var line in lines)
            {
                int index = -1;

                while (index < line.Count)
                {
                    List<int> line2 = new(line);

                    if (index != -1)
                    {
                        line2.RemoveAt(index);
                    }

                    if (AreConditionsMet(line2))
                    {
                        sum++;
                        break;
                    }

                    index++;
                }
            }

            return sum;
        }

        static bool AreConditionsMet(List<int> line) => (IsLevelIncreasing(line) || IsLevelDecreasing(line))
                                                            && AreDifferencesAcceptable(line);

        static bool IsLevelIncreasing(List<int> line)
        {
            for (int i = 0; i < line.Count - 1; i++)
            {
                if (line[i] >= line[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        static bool IsLevelDecreasing(List<int> line)
        {
            for (int i = 0; i < line.Count - 1; i++)
            {
                if (line[i] <= line[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        static bool AreDifferencesAcceptable(List<int> line)
        {
            for (int i = 0; i < line.Count - 1; i++)
            {
                if (Math.Abs(line[i] - line[i + 1]) > 3)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
