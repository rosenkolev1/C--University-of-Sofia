namespace Problem1
{
    public class Program
    {
        private static void Main(string[] args)
        {
            // snippet cw
            Console.WriteLine("Helllo .NET");
            Account account = new Account();
            Invoice invoice = new Invoice();
            Console.WriteLine(invoice);
            Invoice invoice1 = new Invoice("Desription","0001",10, 1000);
            Console.WriteLine(invoice1);
        }
    }
}