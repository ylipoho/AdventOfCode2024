namespace AdventOfCode2024.src
{
    public static class Day1
    {
        public static int GetDistancesSum_v1()
        {
            var (firstList, secondList) = PrepareNumberLists();

            return firstList
                        .Zip(secondList)
                        .Select(x => Math.Abs(x.First - x.Second))
                        .Sum();
        }

        public static int GetSimilarityScoresSum_v2()
        {
            var (firstList, secondList) = PrepareNumberLists();

            return firstList
                        .Select(first => first * secondList.Count(second => second == first))
                        .Sum();
        }

        private static (IEnumerable<int>, IEnumerable<int>) PrepareNumberLists()
        {
            var lines = FileReader.ReadLines("1");
            var numbers = lines.Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries));

            return (numbers.Select(x => int.Parse(x[0])).Order(),
                    numbers.Select(x => int.Parse(x[1])).Order());
        }
    }
}
