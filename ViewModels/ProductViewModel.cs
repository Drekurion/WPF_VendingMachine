using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_VendingMachine.Models;

namespace WPF_VendingMachine.ViewModels
{
	public class ProductViewModel : ObservableObject
	{
		//Model the product view model represents
		private VendingItem model;
		//Maximum number of items allowed in this view model
		private const int maxQuantity = 10;
		//Current quantity in the view model
		private int quantity;

		public int Id
		{
			get => model.Id;
		}

		public int Quantity
		{
			get => quantity;
			private set
			{
				quantity = value;
				OnPropertyChanged("OutOfStockMessage");
				OnPropertyChanged("InventoryDisplay");
				OnPropertyChanged("Quantity");
			}
		}

		//Formatted display message of this product quantity
		//Ex: "Regular Soda: 5"
		public string InventoryDisplay
		{
			get => model.Name + ": " + quantity;
		}

		//Return a copy of this model values
		public VendingItem Information
		{
			get => model;
		}

		//Determine if we need to display "Out of stock" message
		public Visibility OutOfStockMessage
		{
			get
			{
				if(Quantity > 0)
				{
					return Visibility.Hidden;
				}
				return Visibility.Visible;
			}
		}

		public ProductViewModel(int id, string name, double price)
		{
			model = new VendingItem(id, name, price);
			Quantity = 0;
		}

		public int Refill()
		{
			var amount = maxQuantity - Quantity;
			Quantity += amount;
			return amount;
		}

		public int Empty()
		{
			var amount = Quantity;
			Quantity = 0;
			return amount;
		}

		public bool Dispense()
		{
			if(Quantity > 0)
			{
				Quantity--;
				return true;
			}
			return false;
		}
	}
}
