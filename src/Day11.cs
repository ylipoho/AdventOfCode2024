namespace AdventOfCode2024.src
{
    internal static class Day11
    {
        public static long GetStonesCount(int iterationCount)
        {
            var stones = FileReader.ReadLine("11").Split(' ').Select(stone => long.Parse(stone));
            Dictionary<long, long> stonesInfo = [];

            foreach (var item in stones)
            {
                stonesInfo[item] = stonesInfo.TryGetValue(item, out long value) 
                                    ? value + 1 
                                    : 1;
            }

            for (int i = 0; i < iterationCount; i++)
            {
                Dictionary<long, long> bufferStoneInfo = [];

                foreach (var (stone, stoneCount) in stonesInfo)
                {
                    if (stoneCount == 0)
                    {
                        continue;
                    }

                    if (stone == 0)
                    {
                        AddStones(1, stoneCount, bufferStoneInfo);
                        continue;
                    }

                    string stoneString = stone.ToString();

                    if (stoneString.Length % 2 == 0)
                    {
                        AddStones(long.Parse(stoneString[..(stoneString.Length / 2)]), stoneCount, bufferStoneInfo);
                        AddStones(long.Parse(stoneString[(stoneString.Length / 2)..]), stoneCount, bufferStoneInfo);
                        continue;
                    }

                    AddStones(stone * 2024, stoneCount, bufferStoneInfo);
                }

                stonesInfo = bufferStoneInfo;
            }

            return stonesInfo.Values.Aggregate((x, y) => x + y);
        }

        static void AddStones(long stone, long stoneCount, Dictionary<long, long> bufferInfo)
        {
            if (bufferInfo.ContainsKey(stone))
            {
                bufferInfo[stone] += stoneCount;
            }
            else
            {
                bufferInfo[stone] = stoneCount;
            }
        }
    }
}
