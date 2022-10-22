// See https://aka.ms/new-console-template for more information

//Zada4a 1

using System.Text;

int FindMedian(int a, int b, int c)
{
    if (a >= b) // x b x a x
    {
        if (c <= b) return b;
        else if (c >= a) return a;

        return c;
    }
    else // x a x b x
    {
        if (c <= a) return a;
        else if (c >= b) return b;

        return c;
    }
}

//int a, b, c;
//a = 10;
//b = 9;
//c = 8;
//Console.WriteLine($"The median of {a}, {b}, {c} is: {FindMedian(a, b, c)}");

//Zada4a 2
int EncryptNumber(int num)
{
    if (num < 1000 || num > 9999) throw new ArgumentOutOfRangeException();

    int newNum = 0;

    int[] newNumDigits = new int[4];

    for (int i = 4; i >= 1; i--)
    {
        int digit = num % 10;
        num /= 10;
        digit = (digit + 7) % 10;

        int digitPos = 0;
        if (i == 1) digitPos = 1;
        else if (i == 2) digitPos = 0;
        else if (i == 3) digitPos = 3;
        else digitPos = 2;

        newNum += (int)(Math.Pow(10, digitPos)) * digit;
    }

    return newNum;
}

int DecryptNumber(int num)
{
    var digits = new int[4];
    int counter = 0;
    while (num > 0)
    {
        digits[counter++] = num % 10;
        num /= 10;
    }
    digits = digits.Reverse().ToArray();

    int decryptedNum = 0;

    for (int i = 0; i < 4; i++)
    {
        int digit = digits[i];
        if (digit >= 0 && digit <= 6) digit += 10;
        digit -= 7;

        int digitPos;
        if (i == 0) digitPos = 1;
        else if (i == 1) digitPos = 0;
        else if (i == 2) digitPos = 3;
        else digitPos = 2;

        decryptedNum += (int)(Math.Pow(10, digitPos)) * digit;
    }

    return decryptedNum;
}

//int number = 1529; //Encrypted is 9682
//Console.WriteLine($"Encrypting number: {number} --> {EncryptNumber(number)}");
//number = 7833; // Encrypted is 0045
//Console.WriteLine($"Encrypting number: {number} --> {EncryptNumber(number)}");

//int encryptedNumber = 9682; //Decrypted is 1529
//Console.WriteLine($"Decrypting number: {encryptedNumber} --> {DecryptNumber(encryptedNumber)}");
//encryptedNumber = 0045; // Decrypted is 7833
//Console.WriteLine($"Decrypting number: {encryptedNumber} --> {DecryptNumber(encryptedNumber)}");
//encryptedNumber = 100; // Decrypted is 3334
//Console.WriteLine($"Decrypting number: {encryptedNumber} --> {DecryptNumber(encryptedNumber)}");

//Zada4a 3

string SpaceDigits(int number)
{
    string numberString = string.Join(" ", number.ToString().ToArray());

    return numberString;
}

//int testNum = 1234567; // Decrypted is 3334
//Console.WriteLine($"Space digits of number: {testNum} --> {SpaceDigits(testNum)}");
