namespace AdventOfCode2024.src
{
    internal class Day8
    {
        public static int GetAntinodeLocationsCount(int taskPart)
        {
            var lines = FileReader.ReadLines("8").ToList();
            List<(char Symbol, int X, int Y)> antennas = [];

            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] != '.')
                    {
                        antennas.Add((lines[i][j], i, j));
                    }
                }
            }

            return antennas
                        .GroupBy(x => x.Symbol)
                        .SelectMany(antenna => GetAntinodesLocations([.. antenna], lines.Count, taskPart))
                        .Distinct()
                        .Count();
        }

        static List<(int X, int Y)> GetAntinodesLocations(List<(char Symbol, int X, int Y)> antenna, int mapSize, int taskPart)
        {
            int antennaCount = antenna.Count;
            List<(int X, int Y)> antinodes = [];

            for (int i = 0; i < antennaCount; i++)
            {
                for (int j = i + 1; j < antennaCount; j++)
                {
                    int xDelta = antenna[i].X - antenna[j].X;
                    int yDelta = antenna[i].Y - antenna[j].Y;
                    int count = taskPart == 1
                                    ? 1
                                    : mapSize / Math.Min(Math.Abs(xDelta), Math.Abs(yDelta)) - 1;

                    for (int k = 0; k < count; k++)
                    {
                        int koeff = taskPart == 1 ? 1 : k;
                        (int X, int Y) checkPoint1 = (antenna[i].X + koeff * xDelta, antenna[i].Y + koeff * yDelta);
                        (int X, int Y) checkPoint2 = (antenna[j].X - koeff * xDelta, antenna[j].Y - koeff * yDelta);

                        if (checkPoint1.X > -1 && checkPoint1.X < mapSize
                            && checkPoint1.Y > -1 && checkPoint1.Y < mapSize)
                        {
                            antinodes.Add(checkPoint1);
                        }

                        if (checkPoint2.X > -1 && checkPoint2.X < mapSize
                            && checkPoint2.Y > -1 && checkPoint2.Y < mapSize)
                        {
                            antinodes.Add(checkPoint2);
                        }
                    }
                }
            }
            return antinodes;
        }
    }
}

