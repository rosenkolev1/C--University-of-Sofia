namespace _0MI0800065___Homework_1
{
    internal class TableTest
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the argument starting value: ");
            double argumentStartValue = double.Parse(Console.ReadLine());

            Console.Write("Enter the argument ending value: ");
            double argumentEndValue = double.Parse(Console.ReadLine());

            Console.Write("Enter the argument steps count: ");
            int argumentStepsCount = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if(argumentStartValue > argumentEndValue)
            {
                double copy = argumentStartValue;
                argumentStartValue = argumentEndValue;
                argumentEndValue = copy;
            }

            Table table = new Table(argumentStartValue, argumentEndValue, argumentStepsCount);

            table.MakeTable();
        }
    }
}