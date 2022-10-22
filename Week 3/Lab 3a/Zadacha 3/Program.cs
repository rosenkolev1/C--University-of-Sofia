namespace Zadacha_3
{
    internal class Program
    {
        static void getCommonDivisors(int x, int y, out int leastCommonDivisor, out int greatesCommonDivisor)
        {
            leastCommonDivisor = 1;
            while (true)
            {
                if (x > y) x -= y;
                else if (x < y) y -= x;
                else break;
            }

            greatesCommonDivisor = x;
        }

        static double CalculateProbabilityOfDivisionByFour()
        {
            int totalValues = 0;
            int goodValues = 0;
            for (int digit1 = 1; digit1 <= 5; digit1++)
            {
                for (int digit2 = 4; digit2 <= 9; digit2++)
                {
                    for (int digit3 = 3; digit3 <= 8; digit3++)
                    {
                        for (int digit4 = 6; digit4 <= 9; digit4++)
                        {
                            for (int digit5 = 2; digit5 <= 8; digit5++)
                            {
                                int number = digit1 * 10000 + digit2 * 1000 + digit3 * 100 + digit4 * 10 + digit5;
                                if (number % 4 == 0) goodValues++;
                                totalValues++;
                            }
                        }
                    }
                }
            }

            double probability = (double)(goodValues) / totalValues;

            return probability;
        }

        static void Main(string[] args)
        {
            //int x = 68;
            //int y = 16;
            //getCommonDivisors(x, y, out int leastDivisor, out int greatestDivisor);
            //Console.WriteLine($"The least and greates common divisors of {x} and {y} are --> {leastDivisor} and {greatestDivisor}");

            Console.WriteLine($"The probability of Task 3.b is --> {CalculateProbabilityOfDivisionByFour():0.##}");
        }
    }
}