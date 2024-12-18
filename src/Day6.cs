namespace AdventOfCode2024.src
{
    internal class Day6
    {
        enum Direction
        {
            Up,
            Right,
            Down,
            Left
        }

        public static int GetVisitedPositionsCount_v1()
        {
            char[][] map = FileReader
                                .ReadLines("6")
                                .Select(line => line.ToCharArray())
                                .ToArray();
            int mapSize = map.Length;
            int visitedCount = 0;
            var currentPosition = GetStartPosition(map);
            Direction currentDirection = Direction.Up;

            (int X, int Y) nextPosition = GetNextPositionByDirection(currentPosition, currentDirection);

            while (nextPosition.X > -1 && nextPosition.X < mapSize
                    && nextPosition.Y > -1 && nextPosition.Y < mapSize)
            {
                if (map[currentPosition.X][currentPosition.Y] == '.')
                {
                    map[currentPosition.X][currentPosition.Y] = 'X';
                    visitedCount++;
                }

                if (map[nextPosition.X][nextPosition.Y] == '#')
                {
                    currentDirection = ChangeDirection(currentDirection);
                }
                else
                {
                    currentPosition = nextPosition;
                }

                nextPosition = GetNextPositionByDirection(currentPosition, currentDirection);
            }

            return visitedCount + 2;
        }

        public static int GetObstructionPositionsCount_v2()
        {
            char[][] map = FileReader
                                .ReadLines("6")
                                .Select(line => line.ToCharArray())
                                .ToArray();
            int mapSize = map.Length;
            int obstructionCount = 0;
            var currentPosition = GetStartPosition(map);

            for (int x = 0; x < mapSize; x++)
            {
                for (int y = 0; y < mapSize; y++)
                {
                    (char saveChar, map[x][y]) = (map[x][y], '#');

                    if (saveChar != '#'
                        && GetTurnsInfo(mapSize, map, currentPosition)
                            .GroupBy(info => info)
                            .Where(info => info.Count() > 1)
                            .Any())
                    {
                        obstructionCount++;
                    }

                    map[x][y] = saveChar;
                }
            }

            return obstructionCount;
        }

        static List<(Direction direction, int x, int y)> GetTurnsInfo(int size, char[][] map, (int X, int Y) currentPosition)
        {
            List<(Direction direction, int x, int y)> turnsInfo = [];
            int maxStepsCount = map.Length * map.Length;
            Direction currentDirection = Direction.Up;
            int visitedCount = 1;

            (int X, int Y) nextPosition = GetNextPositionByDirection(currentPosition, currentDirection);

            while (nextPosition.X > -1 && nextPosition.X < size
                    && nextPosition.Y > -1 && nextPosition.Y < size
                    && visitedCount < maxStepsCount)
            {
                if (map[currentPosition.X][currentPosition.Y] == 'X'
                    || map[currentPosition.X][currentPosition.Y] == '.')
                {
                    visitedCount++;
                }

                if (map[nextPosition.X][nextPosition.Y] == '#')
                {
                    currentDirection = ChangeDirection(currentDirection);
                    turnsInfo.Add((currentDirection, currentPosition.X, currentPosition.Y));
                }
                else
                {
                    currentPosition = nextPosition;
                }

                nextPosition = GetNextPositionByDirection(currentPosition, currentDirection);
            }

            return turnsInfo;
        }

        static (int X, int Y) GetStartPosition(char[][] map)
        {
            var line = map.Select((value, index) => (value, index))
                        .First(x => Array.IndexOf(x.value, '^') > -1);

            return (line.index, Array.IndexOf(line.value, '^'));
        }

        static (int X, int Y) GetNextPositionByDirection((int X, int Y) position, Direction direction) => direction switch
        {
            Direction.Up => (position.X - 1, position.Y),
            Direction.Right => (position.X, position.Y + 1),
            Direction.Down => (position.X + 1, position.Y),
            Direction.Left => (position.X, position.Y - 1),
            _ => throw new ArgumentException("Invalid direction")
        };

        static Direction ChangeDirection(Direction direction) => direction switch
        {
            Direction.Up => Direction.Right,
            Direction.Right => Direction.Down,
            Direction.Down => Direction.Left,
            Direction.Left => Direction.Up,
            _ => throw new ArgumentException("Invalid direction")
        };
    }
}
