namespace AdventOfCode2024.src
{
    internal class Day11
    {
        public static long GetStonesCount_v1()
        {
            List<long> stones = FileReader
                                .ReadLine("11")
                                .Split(' ')
                                .Select(x => long.Parse(x))
                                .ToList();

            return UpdateStones(stones, 0).Count;
        }

        static List<long> UpdateStones(List<long> stones, int iteration)
        {
            if (iteration == 25)
            {
                return stones;
            }

            List<long> newStones =  stones.Select(stone => ProcessStone(stone)).Aggregate((x, y) => [.. x, .. y]);
            
            return UpdateStones(newStones, iteration + 1);
        }

        static List<long> ProcessStone(long stone)
        {
            if (stone == 0)
            {
                return [1];
            }

            string stoneString = stone.ToString();

            if (stoneString.Length % 2 == 0)
            {
                return [long.Parse(stoneString[..(stoneString.Length / 2)]),
                        long.Parse(stoneString[(stoneString.Length / 2)..])];
            }

            return [stone * 2024];
        }
    }
}
