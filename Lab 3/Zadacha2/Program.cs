// See https://aka.ms/new-console-template for more information
Console.WriteLine("Compute Cos series");
double x; //input value
double cosValue; // cosine value
double accuracy ;
int counter;
double termOfSeries = 1.0;

x = 0.9;
accuracy = 0.0000101;
counter = 1;
cosValue = termOfSeries;

do
{
    termOfSeries = -termOfSeries * x * x / ((2 * counter) * (2 * counter - 1));
    cosValue += termOfSeries;
    counter++;

} while (Math.Abs(termOfSeries) > accuracy);

//This whole thing here is so that I can output the accuracy formatted with E-5 and
//also make it work for any arbitrarily selected accuracy without altering anything else
//Except it doesn't actually work sometimes because floating point operations are weird
//For example, an infinite loop happens with accuracy = 0.0000011
int countOfDigitsBehindFloatPoint = 0;
double accuracyCopy = accuracy;
while(!int.TryParse(accuracyCopy.ToString(), out int result))
{
    countOfDigitsBehindFloatPoint++;
    accuracyCopy *= 10;
}

string formatString = @"{0:0." + new string('#', countOfDigitsBehindFloatPoint) + "}";

Console.WriteLine($"Approx cos value = {cosValue}");
Console.WriteLine($"Accurate cos value = {Math.Cos(x)}");
Console.WriteLine($"Accuracy used for approx cos value = " + string.Format(formatString, accuracy));