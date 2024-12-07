namespace AdventOfCode2024.src
{
    internal class Day7
    {
        public static long GetTotalCalibrationResult(int taskPart)
        {
            var lines = FileReader.ReadFile("7")
                             .Select(line => line.Split(": "));
            long result = 0;

            foreach (var sumAndOperands in lines)
            {
                long currentSum = long.Parse(sumAndOperands[0]);
                var currentOperands = sumAndOperands[1]
                                                .Split(' ')
                                                .Select(long.Parse).ToList();
                long operatorCombinationNumber = taskPart == 1
                    ? Convert.ToInt64(new string('1', currentOperands.Count - 1), 2)
                    : TernaryToDecimal(new string('2', currentOperands.Count - 1));

                for (int i = 0; i <= operatorCombinationNumber; i++)
                {
                    string operatorCombinations = taskPart == 1
                                                    ? Convert.ToString(i, 2).PadLeft(currentOperands.Count - 1, '0')
                                                    : DecimalToTernary(i).PadLeft(currentOperands.Count - 1, '0');
                    long sum = currentOperands[0];

                    for (int j = 0; j < currentOperands.Count - 1; j++)
                    {
                        // 0 is +, 1 is *, 2 is ||
                        switch (operatorCombinations[j])
                        {
                            case '0':
                                sum += currentOperands[j + 1];
                                break;
                            case '1':
                                sum *= currentOperands[j + 1];
                                break;
                            case '2':
                                sum = long.Parse($"{sum}{currentOperands[j + 1]}");
                                break;
                        }
                    }

                    if (sum == currentSum)
                    {
                        result += sum;
                        break;
                    }
                }
            }

            return result;
        }

        static long TernaryToDecimal(string ternaryNumber)
        {
            int exponent = 0;
            long result = 0;

            for (int i = ternaryNumber.Length - 1; i >= 0; i--)
            {
                long ternaryDigit = Convert.ToInt64(ternaryNumber[i].ToString());
                result += ternaryDigit * Convert.ToInt64(Math.Pow(3, exponent));
                exponent++;
            }

            return result;
        }

        static string DecimalToTernary(int decimalNumber)
        {
            string ternaryNumber = string.Empty;

            while (decimalNumber > 0)
            {
                ternaryNumber = (decimalNumber % 3) + ternaryNumber;
                decimalNumber /= 3;
            }

            return ternaryNumber;
        }
    }
}
