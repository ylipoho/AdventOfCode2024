namespace AdventOfCode2024.src
{
    internal class Day9
    {
        public static long GetFilesystemChecksum(int taskPart)
        {
            string line = FileReader.ReadLine("9");
            int digitCount = line.Length;
            List<string> resultLine = [];
            int id = 0;

            for (int i = 0; i < digitCount; i += 2)
            {
                resultLine.AddRange(Enumerable.Repeat($"{id++}", line[i] - '0'));

                if (i + 1 != digitCount)
                {
                    resultLine.AddRange(Enumerable.Repeat(".", line[i + 1] - '0'));
                }
            }

            resultLine = taskPart == 1
                        ? MoveFileblocks_v1(resultLine)
                        : MoveFileblocks_v2(resultLine, id - 1);

            return resultLine
                    .Select((value, index) => (value, index))
                    .Where(x => x.value != ".")
                    .Sum(x => long.Parse(x.value) * x.index);
        }

        public static List<string> MoveFileblocks_v1(List<string> result)
        {
            int firstDotIndex = 0;
            int lastNumberIndex = 0;

            while (firstDotIndex <= lastNumberIndex)
            {
                firstDotIndex = result.IndexOf(".");
                lastNumberIndex = result.Select((value, index) => (value, index)).Last(x => x.value != ".").index;

                if (firstDotIndex < lastNumberIndex)
                {
                    result[firstDotIndex] = result[lastNumberIndex];
                    result[lastNumberIndex] = ".";
                }
            }

            return result;
        }

        public static List<string> MoveFileblocks_v2(List<string> result, int id)
        {
            int firstDotIndex = 0;
            int[] lastNumberIndexes = [0];
            
            while (firstDotIndex <= lastNumberIndexes[0])
            {
                lastNumberIndexes = result
                                        .Select((value, index) => (value, index))
                                        .Where(x => x.value == $"{id}")
                                        .Select(x => x.index)
                                        .ToArray();

                firstDotIndex = result.IndexOf(".", firstDotIndex);
                id--;

                int index = FindIndexToReplaceNumber(result, firstDotIndex, lastNumberIndexes[0], lastNumberIndexes.Length);

                if (index != -1)
                {
                    for (int i = 0; i < lastNumberIndexes.Length; i++)
                    {
                        result[index + i] = result[lastNumberIndexes[i]];
                        result[lastNumberIndexes[i]] = ".";
                    }
                }
            }

            return result;
        }

        static int FindIndexToReplaceNumber(List<string> result, int firstDotIndex, int numberIndex, int numberLength)
        {
            for (int i = firstDotIndex; i < numberIndex; i++)
            {
                bool isCorrectPlace = true;

                for (int j = 0; j < numberLength; j++)
                {
                    if (result[i + j] != ".")
                    {
                        isCorrectPlace = false;
                        break;
                    }
                }

                if (isCorrectPlace)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
