using AdventOfCode2024.src;

namespace AdventOfCode2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($" 1.1: {Day1.GetDistancesSum_v1() == 2196996}");
            Console.WriteLine($" 1.2: {Day1.GetSimilarityScoresSum_v2() == 23655822}");
            Console.WriteLine($" 2.1: {Day2.GetSafeReportsNum_v1() == 585}");
            Console.WriteLine($" 2.2: {Day2.GetSafeReportsNum_v2() == 626}");
            Console.WriteLine($" 3.1: {Day3.GetMultiplicationsSum_v1() == 183788984}");
            Console.WriteLine($" 3.2: {Day3.GetMultiplicationsSum_v2() == 62098619}");
            Console.WriteLine($" 4.1: {Day4.GetEntriesCount_v1() == 2549}");
            Console.WriteLine($" 4.2: {Day4.GetEntriesCount_v2() == 2003}");
            Console.WriteLine($" 5.1: {Day5.GetMiddleElementsSum(taskPart: 1) == 6267}");
            Console.WriteLine($" 5.2: {Day5.GetMiddleElementsSum(taskPart: 2) == 5184}");
            Console.WriteLine($" 6.1: {Day6.GetVisitedPositionsCount_v1() == 5329}");
            Console.WriteLine($" 6.2: {Day6.GetObstructionPositionsCount_v2() == 2162}");
            Console.WriteLine($" 7.1: {Day7.GetTotalCalibrationResult(taskPart: 1) == 1430271835320}");
            Console.WriteLine($" 7.2: {Day7.GetTotalCalibrationResult(taskPart: 2) == 456565678667482}");
            Console.WriteLine($" 8.1: {Day8.GetAntinodeLocationsCount(taskPart: 1) == 311}");
            Console.WriteLine($" 8.2: {Day8.GetAntinodeLocationsCount(taskPart: 2) == 1115}");
            Console.WriteLine($" 9.1: {Day9.GetFilesystemChecksum(taskPart: 1) == 6258319840548}");
            Console.WriteLine($" 9.2: {Day9.GetFilesystemChecksum(taskPart: 2) == 6286182965311}");
            Console.WriteLine($"10.1: {Day10.GetTrailheadsScoreSum(taskPart: 1) == 501}");
            Console.WriteLine($"10.2: {Day10.GetTrailheadsScoreSum(taskPart: 2) == 1017}");
        }
    }
}
