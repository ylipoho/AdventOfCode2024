namespace AdventOfCode2024.src
{
    internal class Day10
    {
        static int[][] Map = [];

        public static int GetTrailheadsScoreSum(int taskPart)
        {
            Map = FileReader
                    .ReadLines("10")
                    .Select(line => line
                                    .Select(x => x - '0')
                                    .ToArray())
                    .ToArray();

            List<List<(int X, int Y)>> ninePoints = [];


            for (int i = 0; i < Map.Length; i++)
            {
                for (int j = 0; j < Map[i].Length; j++)
                {
                    if (Map[i][j] == 0)
                    {
                        ninePoints.Add(FindWayToNinePoint(i, j));
                    }
                }
            }

            return taskPart == 1
                ? ninePoints.Select(x => x.GroupBy(x => x).Count()).Sum()
                : ninePoints.Select(x => x.Count).Sum();
        }

        static List<(int, int)> FindWayToNinePoint(int x, int y)
        {
            if (Map[x][y] == 9)
            {
                return [(x, y)];
            }

            List<(int, int)> result = [];

            foreach (var (X, Y) in FindNeighbours(x, y))
            {
                if (Map[x][y] + 1 == Map[X][Y])
                {
                    result.AddRange(FindWayToNinePoint(X, Y));
                }
            }

            return result;
        }

        static List<(int X, int Y)> FindNeighbours(int x, int y)
        {
            List<(int X, int Y)> neighbours = [];

            if (x > 0)
            {
                neighbours.Add((x - 1, y));
            }

            if (y > 0)
            {
                neighbours.Add((x, y - 1));
            }

            if (x < Map.Length - 1)
            {
                neighbours.Add((x + 1, y));
            }

            if (y < Map[0].Length - 1)
            {
                neighbours.Add((x, y + 1));
            }

            return neighbours;
        }
    }
}
