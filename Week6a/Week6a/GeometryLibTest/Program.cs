// See https://aka.ms/new-console-template for more information
using GeometryLib;

class Program
{
    static void Main(string[] args)
    {
        Point point = new Point(new int[] { 100, 200 });
        Console.WriteLine(point);
        Rectangle rectangle = new Rectangle(10, 20, point);
        Console.WriteLine(rectangle);
        Rectangle copy = new Rectangle(rectangle);
        Console.WriteLine(copy);
        Rectangle rectangle1 = new Rectangle(101, 200, point);
        List<Rectangle> list = new List<Rectangle>() { copy, rectangle1, rectangle}; ;
        Console.WriteLine();
        Console.WriteLine(string.Join("\n",list));
        Console.WriteLine();
        var sorted = Rectangle.SortBy(list, Rectangle.Diagonal);
        foreach (var item in sorted)
        {
            Console.WriteLine(item);
        }


    }
}