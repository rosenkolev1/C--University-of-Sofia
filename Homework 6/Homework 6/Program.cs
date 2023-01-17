namespace Homework_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store1 = new Store();
            Employee worker1 = new Employee("Employee 1");
            Manager manager1 = new Manager("Manager 1");

            store1.OnAppointment(worker1);
            store1.OnAppointment(manager1);

            List<Product> products1 = new List<Product>
            {
                new Product("Banana", 5),
                new Product("Apple", 10),
                new Product("Pear", 7)
            };

            store1.ListOfProducts = products1;
            products1.RemoveRange(0, 2);

            Console.WriteLine(string.Join(" ", store1.ListOfProducts));

            worker1.ManageQty(new Product("Banana", 5), 30);
            manager1.ManageQty(new Product("Banana", 3), 30);
            manager1.ManageQty(new Product("Pear", 7), 100);
        }
    }
}