namespace Problem2
{
    internal class Program
    {
        public static void BubbleSort(Comparable[] os, GreaterThan gt)
        {
            if (os.Length == 0) return;

            for (int i = 0; i < os.Length - 1; i++)
            {
                for (int k = 0; k < os.Length - 1; k++)
                {
                    if (!gt(os[k], os[k + 1]))
                    {
                        var t = os[k];
                        os[k] = os[k + 1];
                        os[k + 1] = t;
                    }
                }

            }
        }
         private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Point p1 = new();
            Point p2 = new(1,2,3);
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Comparable[] os = new Comparable[] { p1, p2 };
            BubbleSort(os, Point.Method);
            Console.WriteLine(os[0].SizeOf());
            Console.WriteLine(os[1].SizeOf());
        }
    }
}