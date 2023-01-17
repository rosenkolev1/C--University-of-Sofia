using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Homework_6
{
    public class Manager : Employee
    {
        public Manager(string name) 
            : base(name)
        {
        }

        internal void ManageProductQuantity(object source, PropertyChangedEventArgs e)
        {
            var store = (Store)source;
            if (e.PropertyName == "ProductQuantity")
            {
                Console.WriteLine($"The {e.PropertyName} property has been changed loll!");
            }
        }

        public override void GetAppointed(object source, EventArgs e)
        {
            Console.WriteLine("Manager just got appointed");
            this.WorksAt = (Store)source;
        }
    }
}
