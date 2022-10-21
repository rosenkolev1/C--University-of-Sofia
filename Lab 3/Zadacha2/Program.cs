// See https://aka.ms/new-console-template for more information
Console.WriteLine("Compute Cos series");
double x; //input value
double cosValue; // cosine value
double accuracy ;
int counter;
double termOfSeries = 1.0;

x = 0.9;
accuracy = 0.00001;
counter = 1;
cosValue = termOfSeries;

do
{
    termOfSeries = -termOfSeries * x * x / ((2 * counter) * (2 * counter - 1));
    cosValue += termOfSeries;
    counter++;

} while (Math.Abs(termOfSeries) > accuracy);

Console.WriteLine($"Approx cos value = {cosValue}");
Console.WriteLine($"Accurate cos value = {Math.Cos(x)}");