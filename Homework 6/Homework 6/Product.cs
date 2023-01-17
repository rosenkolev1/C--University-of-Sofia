using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_6
{
    public class Product
    {
        private string description;
        private int quantity;

        public string Description { get => this.description; set { this.description = value; } }
        public int Quantity { get => this.quantity; set { this.quantity = value; } }

        public Product(String description, int quantity)
        {
            this.description = description;
            this.quantity = quantity;
        }

        public Product(Product other)
        {
            this.description = other.description;
            this.quantity = other.quantity;
        }

        public override string ToString()
        {
            return $"{this.Description}: {this.Quantity}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return this == null;
            if (obj.GetType() != typeof(Product)) return false;

            Product castObj = (Product) obj;
            
            return this.description == castObj.description && this.quantity == castObj.quantity;
        }
    }
}
