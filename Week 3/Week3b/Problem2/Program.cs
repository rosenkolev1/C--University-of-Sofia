// See https://aka.ms/new-console-template for more information

using Problem2;

internal class Program
{
    private static void Main(string[] args)
    {
        ComputeCos computeCos = new();// by default accuracy is 0.001
        computeCos.Accuracy = 0.000001;
        double x = 1.4;

        Console.Write("Enter x[grad]: ");
        x = Convert.ToDouble(Console.ReadLine());
        
        // conver grad to radians
        x = x * Math.PI / 180.0;

        Console.WriteLine($"Approximate Cos({x}) = {computeCos.Cosine(x)}");
        Console.WriteLine($"Accurate Cos({x}) = {Math.Cos(x)}");
    }
}