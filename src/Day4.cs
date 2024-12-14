namespace AdventOfCode2024.src
{
    internal class Day4
    {
        static string[] Map = [];

        public static int GetEntriesCount_v1()
        {
            Map = FileReader
                    .ReadLines("4")
                    .ToArray();

            int mapSize = Map.Length;
            int count = 0;

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (Map[i][j] == 'X')
                    {
                        count += ProcessXCell(i, j);
                    }
                }
            }

            return count;
        }

        static int ProcessXCell(int x, int y)
        {
            List<(int xCoeff, int yCoeff)> directions = [(-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1)];
            char[] letters = ['X', 'M', 'A', 'S'];
            int count = 0;
            int mapSize = Map.Length;

            foreach (var (xCoeff, yCoeff) in directions)
            {
                int xmasIndex = 0;
                int xLetter = x;
                int yLetter = y;

                do
                {
                    xmasIndex++;
                    xLetter = x + Math.Sign(xCoeff) * Math.Abs(xmasIndex);
                    yLetter = y + Math.Sign(yCoeff) * Math.Abs(xmasIndex);
                } while (xLetter >= 0 && xLetter < mapSize
                    && yLetter >= 0 && yLetter < mapSize
                    && xmasIndex < 4 && Map[xLetter][yLetter] == letters[xmasIndex]);

                if (xmasIndex == 4)
                {
                    count++;
                }
            }
            return count;
        }

        public static int GetEntriesCount_v2()
        {
            Map = FileReader
                    .ReadLines("4")
                    .ToArray();

            int count = 0;

            for (int i = 1; i < Map.Length - 1; i++)
            {
                 count += Map[i]
                            .Select((letter, index) => (letter, index))
                            .Count(cell => cell.letter == 'A' && IsXPattern(i, cell.index));
            }

            return count;
        }

        private static bool IsXPattern(int x, int y)
        {
            if (x == 0 || y == 0 || x >= Map.Length - 1 || y >= Map.Length - 1)
            {
                return false;
            }

            bool upM = Map[x - 1][y - 1] == 'M'
                        && Map[x - 1][y + 1] == 'M'
                        && Map[x + 1][y - 1] == 'S'
                        && Map[x + 1][y + 1] == 'S';

            bool downM = Map[x - 1][y - 1] == 'S'
                        && Map[x - 1][y + 1] == 'S'
                        && Map[x + 1][y - 1] == 'M'
                        && Map[x + 1][y + 1] == 'M';

            bool leftM = Map[x - 1][y - 1] == 'M'
                        && Map[x - 1][y + 1] == 'S'
                        && Map[x + 1][y - 1] == 'M'
                        && Map[x + 1][y + 1] == 'S';

            bool rightM = Map[x - 1][y - 1] == 'S'
                        && Map[x - 1][y + 1] == 'M'
                        && Map[x + 1][y - 1] == 'S'
                        && Map[x + 1][y + 1] == 'M';

            return upM || downM || leftM || rightM;
        }
    }
}
