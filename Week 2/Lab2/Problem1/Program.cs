namespace Problem1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Account someAccount = new Account();
            Account accountCopy = someAccount;

            accountCopy.Deposit(100);
            Console.WriteLine($"The account's current balance: {someAccount.Balance:0.00}");

            accountCopy.Withdraw(50);
            Console.WriteLine($"The account's current balance: {someAccount.Balance:0.00}");
        }
    }
}