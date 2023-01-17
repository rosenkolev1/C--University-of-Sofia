using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Homework_6
{
    public class Store : INotifyPropertyChanged
    {
        static int count = 1;
        List<Product> listOfProducts;
        private Employee worker;
        private Manager manager;

        public readonly string STORE_NAME = $"Store {count}";

        public event EventHandler<Employee>? Appoint;
        public event PropertyChangedEventHandler? PropertyChanged;

        public Store()
        {
            this.listOfProducts = new List<Product>();
            this.worker = null;
            this.manager = null;

        }

        public void OnAppointment(Employee employee)
        {
            if (employee.GetType() == typeof(Manager))
            {
                this.manager = (Manager)employee;
                this.PropertyChanged += this.manager.ManageProductQuantity;
            }
            else
            {
                this.worker = employee;
                
            }

            this.Appoint += employee.GetAppointed;
            this.PropertyChanged += employee.ManageListOfProducts;
            this.Appoint?.Invoke(this, employee);
            this.Appoint -= employee.GetAppointed;
        }

        public void OnUpdateQuantity(int index, int newQty)
        {
            Console.WriteLine($"{this.listOfProducts[index]} --> {newQty}");

            this.listOfProducts[index].Quantity = newQty;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProductQuantity"));
        }

        public List<Product> ListOfProducts 
        {   
            get => this.listOfProducts;
            set 
            {
                this.listOfProducts.Clear();

                foreach (var product in value)
                {
                    this.listOfProducts.Add(new Product(product));
                }

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListOfProducts"));
            }
        }

        public Employee Worker { get; set; }
    }
}
