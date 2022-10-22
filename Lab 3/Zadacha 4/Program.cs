namespace Zadacha_4
{
    internal class Program
    {
        static void DisplayAllPythagoreanTriples()
        {
            for (int side1 = 1; side1 <= 30; side1++)
            {
                for (int side2 = side1; side2 <= 30; side2++)
                {
                    for (int side3 = side2; side3 <= 30; side3++)
                    {
                        if(side1 * side1 + side2 * side2 == side3*side3)
                        {
                            Console.WriteLine($"The sides ({side1}, {side2}, {side3}) are a Pythagorean triple");
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            DisplayAllPythagoreanTriples();
        }
    }
}