using static AdventOfCode2024.src.MatrixDirection;

namespace AdventOfCode2024.src
{
    internal class Day12
    {
        static char[][] Map = [];

        public static int GetFencePrice(int taskPart)
        {
            Map = FileReader
                        .ReadLines("12")
                        .Select(line => line.ToArray())
                        .ToArray();

            int price = 0;

            for (int i = 0; i < Map.Length; i++)
            {
                for (int j = 0; j < Map.Length; j++)
                {
                    // '+' - elements checked in current group
                    // '.' - previously checked groups
                    if (Map[i][j] != '.')
                    {
                        List<(int X, int Y)> currentGroup = GetGroupCoords((i, j));
                        int fenceCount = taskPart == 1
                                            ? currentGroup.Sum(cell => GetFenceInfoForCell(cell.X, cell.Y).Count(x => x))
                                            : GetFenceCount_v2(currentGroup);
                        price += currentGroup.Count * fenceCount;
                        ClearGroup(currentGroup);
                    }
                }
            }

            return price;
        }
        
        static List<(int X, int Y)> GetGroupCoords((int X, int Y) currentPoint, Direction startDirection = Direction.Down)
        {
            int directionCount = 4;
            char currentSymbol = Map[currentPoint.X][currentPoint.Y];
            Map[currentPoint.X][currentPoint.Y] = '+';
            List<(int, int)> group = [currentPoint];

            for (int i = 0; i < directionCount; i++)
            {
                (int nextX, int nextY) = GetNextPositionByDirection((currentPoint.X, currentPoint.Y), startDirection);

                if (AreCoordsValid((nextX, nextY)) && currentSymbol == Map[nextX][nextY])
                {
                    group.AddRange(GetGroupCoords((nextX, nextY), startDirection));
                }

                startDirection = ChangeDirection(startDirection);
            }

            return group;
        }

        static bool[] GetFenceInfoForCell(int x, int y)
        {
            return new List<(int X, int Y)>()
            {
                GetNextPositionByDirection((x, y), Direction.Down),
                GetNextPositionByDirection((x, y), Direction.Left),
                GetNextPositionByDirection((x, y), Direction.Up),
                GetNextPositionByDirection((x, y), Direction.Right)
            }
            .Select(item =>
                        !AreCoordsValid((item.X, item.Y))
                        || Map[item.X][item.Y] != Map[x][y])
            .ToArray();
        }

        static int GetFenceCount_v2(List<(int X, int Y)> group)
        {
            if (group.Count == 1)
            {
                return 4;
            }

            int cornerCount = 0;

            foreach ((int X, int Y) in group)
            {
                // convex corners
                var fenceInfo = GetFenceInfoForCell(X, Y);
                cornerCount += fenceInfo.Count(x => x) == 2
                    && ((fenceInfo[0] == fenceInfo[2]) || (fenceInfo[1] == fenceInfo[3]))
                    ? 0
                    : Math.Max(fenceInfo.Count(x => x) - 1, 0);

                // concave corners
                cornerCount += new List<(int x, int y)>() {(-1, -1), (-1, 1), (1, -1), (1, 1)}
                                .Count(coeffs => AreCoordsValid((X + coeffs.x, Y + coeffs.y))
                                                    && Map[X + coeffs.x][Y + coeffs.y] != '+'
                                                    && Map[X + coeffs.x][Y] == '+'
                                                    && Map[X][Y + coeffs.y] == '+');
            }

            return cornerCount;
        }

        static bool AreCoordsValid((int x, int y) coords) =>
                        coords.x >= 0 && coords.y >= 0 && coords.x < Map.Length && coords.y < Map.Length;

        static void ClearGroup(List<(int X, int Y)> currentGroup) => 
                        currentGroup.ForEach(cell => Map[cell.X][cell.Y] = '.');
    }
}
