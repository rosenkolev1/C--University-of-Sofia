// See https://aka.ms/new-console-template for more information
using Problem1;
using System.Security.Cryptography;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = "VB code";
            var s2 = "C# code";
            IConvertible convertible = new ProgramHelper();
            Console.WriteLine("Test A & B");
            Console.WriteLine(convertible.ConvertToCSharp(s1));
            Console.WriteLine(convertible.ConvertToVB2015(s2));

            Console.WriteLine("Test C  ");
            ICodeChecker codeChecker = new ProgramHelper();
            Console.WriteLine(codeChecker.ConvertToCSharp(s1));
            Console.WriteLine(codeChecker.ConvertToVB2015(s2));
            var compare = codeChecker.CodeCheckSyntax(s1, s2);
            Console.WriteLine($"Checked syntax {s1} and {s2} => {compare}");

            Console.WriteLine("Test D  ");
            IConvertible codeHelperChecker = new ProgramConverter();
            
            Console.WriteLine(codeHelperChecker.ConvertToCSharp(s1));
            Console.WriteLine(codeHelperChecker.ConvertToVB2015(s2));

            ProgramHelper programConverter = new ();
            ProgramConverter   programHelper = programConverter;
            IConvertible ic = programHelper;

            Console.WriteLine(ic.ConvertToCSharp(s1));
            Console.WriteLine(ic.ConvertToVB2015(s2));
        }

    }
}

