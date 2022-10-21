using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Invoice
    {

		#region Data members
		private string  partDescription;
		private string  partNumber;
		private int     quantity;
		private decimal pricePerItem;

		#endregion

		#region Constructors
		public Invoice(string partDescription, string partNumber, int quantity, decimal pricePerItem)
		{
			PartDescription = partDescription;
			PartNumber = partNumber;
			Quantity = quantity;
			PricePerItem = pricePerItem;

		}

		public Invoice()
		{
			PartDescription = "unknown description";
			PartNumber = "unknown part number";
			Quantity = 0;
			PricePerItem = 1;
		}

		#endregion

		#region Properties

		public int Quantity
		{
			get { return quantity; }
			set { quantity = value >= 0 ? value : 0; }
		}
		public decimal PricePerItem
		{
			get { return pricePerItem; }
			set { pricePerItem = value > 0 ? value : 1; }
		}

		public string PartNumber
		{
			get { return partNumber; }
			set { partNumber = value != null ? value : "unknown part number"; }
		}

		public string PartDescription
		{
			get { return partDescription; }
			set { partDescription = value != null ? value : "unknown description"; }
		}

		#endregion
	

		/// <summary>
		/// Returns invoice tgotal amount
		/// </summary>
		/// <returns></returns>
		public decimal GetInvoiceAmount()
		{
			return quantity * pricePerItem;

        }

		public override string ToString()
		{
			return String.Format($"Invoice\nDescription: {partDescription}\n" +
                $"PartNumber: {partNumber}\n" +
                $"Quantity: {quantity}, PricePerItem: {pricePerItem:C}\n" +
                $"Total price: {GetInvoiceAmount():C}");
		}	
	}
}
