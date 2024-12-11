namespace AdventOfCode2024.src
{
    public static class FileReader
    {
        private static readonly string FilePath = @"..\..\..\resources\Day{0}-Input.txt";

        public static IEnumerable<string> ReadLines(string id)
        {
            return File.ReadAllLines(string.Format(FilePath, id));
        }

        public static string ReadLine(string id)
        {
            return File.ReadAllText(string.Format(FilePath, id));
        }
    }
}
