using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_6
{
    public class Employee : EventArgs
    {
        private string name;
        private Store worksAt;

        public string Name { get => this.name; set { this.name = value; } }
        public Store WorksAt { get => this.worksAt; set { this.worksAt = value; } }

        public Employee(string name)
        {
            this.name = name;
        }

        public void ManageQty(Product p, int qty)
        {
            for (int i = 0; i < this.worksAt.ListOfProducts.Count; i++)
            {
                if (this.worksAt.ListOfProducts[i].Equals(p))
                {
                    this.worksAt.OnUpdateQuantity(i, qty);
                    return;
                }
            }
           
        }

        internal void ManageListOfProducts(object source, PropertyChangedEventArgs e)
        {
            var store = (Store)source;
            if (e.PropertyName == "ListOfProducts")
            {
                Console.WriteLine($"The {e.PropertyName} for {store.STORE_NAME} has been changed by {this.GetType()}!");
            }
        }

        public virtual void GetAppointed(object source, EventArgs e)
        {
            var store = (Store)source;
            Console.WriteLine($"{this.Name} just got appointed to {store.STORE_NAME}");
            this.worksAt = store;
        }
    }
}
