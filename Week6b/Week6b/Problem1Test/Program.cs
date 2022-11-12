// See https://aka.ms/new-console-template for more information
using Problem1;
using Problem1Test;

Console.WriteLine("Hello, World!");
//static void Main(string[] args)

Point point = new Point();
Console.WriteLine("Points ...");
Console.WriteLine(point);
point['x'] = 10;
Console.WriteLine(point);
var pointB = new Point(point);
Console.WriteLine(pointB);

Rectangle rectangle1 = new Rectangle();
Console.WriteLine(rectangle1);
rectangle1['x'] = 100;
rectangle1['w'] = 50;
Console.WriteLine(rectangle1);

Rectangle rectangle2 = new Rectangle();
Console.WriteLine(rectangle2);
rectangle2['x'] = 200;
rectangle2['w'] = 250;
Console.WriteLine(rectangle2);

List<Rectangle> list = new List<Rectangle>() { rectangle1, rectangle2 };

var sorted = Rectangle.SortBy(list, Rectangle.Diagonal);
foreach (var item in sorted)
{
    Console.WriteLine(item);
    Console.WriteLine(Rectangle.Diagonal(item));
}

Console.WriteLine("Extension methods ....");

Console.WriteLine($"Rectangle : {rectangle1}\n" +
                  $"Perimeter : {rectangle1.Perimeter():F2}");

