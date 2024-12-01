﻿using AdventOfCode2024.src;

namespace AdventOfCode2024
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine($"1.1: {Day1.GetDistancesSum_v1()}");
			Console.WriteLine($"1.2: {Day1.GetSimilarityScoresSum_v2()}");
			Console.WriteLine($"2.1: {Day2.GetSafeReportsNum_v1()}");
			Console.WriteLine($"2.2: {Day2.GetSafeReportsNum_v2()}");
		}
	}
}
