namespace Problem1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sVB = "Vb code";
            var cSharp = " C# code";
            Console.WriteLine("Test A & B\n");
            // Im[plementation of interface with explicit name qualification
            IConvertible convertible = new ProgramHelper();
            Console.WriteLine(convertible.ConvertToCSharp(sVB));
            Console.WriteLine(convertible.ConvertToVB2015(cSharp));

            // general access to interface implementation
            ProgramHelper ph = new ProgramHelper();
            ph.ConvertToCSharp(sVB);


            if (ph is IConvertible ic)
            {
                Console.WriteLine("Test is operator ......");
                Console.WriteLine(ic.ConvertToCSharp(sVB));
                Console.WriteLine(ic.ConvertToVB2015(cSharp));
            }

            var phAsa = ph as ICodeChecker ?? new ProgramHelper();
            {
                Console.WriteLine("Test as operator ......");
                Console.WriteLine(phAsa.ConvertToCSharp(sVB));
                Console.WriteLine(phAsa.ConvertToVB2015(cSharp));
                Console.WriteLine($"Test syntax: {phAsa.CodeCheckSyntax(sVB,cSharp)}");
            }

            Console.WriteLine("Test D\n");
            Console.WriteLine("Test D  ....IConvertible\n");
            ProgramHelper2 ph2 = new ProgramHelper2();
            IConvertible convertible2 = new ProgramHelper2();
            Console.WriteLine(convertible2.ConvertToCSharp(sVB));
            Console.WriteLine(convertible2.ConvertToVB2015(cSharp));
            Console.WriteLine("Test D  ....ICodeChecker\n");
            ICodeChecker ic2 = new ProgramHelper2();
            Console.WriteLine(ic2.ConvertToCSharp(sVB));
            Console.WriteLine(ic2.ConvertToVB2015(cSharp));
            Console.WriteLine($"Test syntax: {ic2.CodeCheckSyntax(sVB, cSharp)}");

            ProgramConverter programConverter = new ProgramConverter();
            Console.WriteLine("Test D  ....IConvertible from ProgramConverter\n");
            
            IConvertible convertible3 = programConverter;
            Console.WriteLine(convertible3.ConvertToCSharp(sVB));
            Console.WriteLine(convertible3.ConvertToVB2015(cSharp));
            Console.WriteLine();
            IConvertible convertible4 = new ProgramHelper3();
            Console.WriteLine(convertible4.ConvertToCSharp(sVB));
            Console.WriteLine(convertible4.ConvertToVB2015(cSharp));
            Console.WriteLine();
            ProgramConverter pc = new ProgramHelper3();
            IConvertible convertible5 = pc;
            Console.WriteLine(convertible5.ConvertToCSharp(sVB));
            Console.WriteLine(convertible5.ConvertToVB2015(cSharp));




        }
    }
}