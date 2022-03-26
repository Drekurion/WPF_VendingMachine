using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_VendingMachine.ViewModels
{
	public class PaymentViewModel : ObservableObject
	{
		//Customer information
		private double total;
		private double inserted;
		private double change;

		//Machine information
		private double bankTotal;

		public double Total
		{
			get => total;
			set
			{
				total = value;
				OnPropertyChanged("Total");
			}
		}

		public double Inserted
		{
			get => inserted;
			set
			{
				inserted = value;
				OnPropertyChanged("Inserted");
			}
		}

		public double Change
		{
			get => change;
			set
			{
				change = value;
				OnPropertyChanged("Change");
			}
		}

		public double BankTotal
		{
			get => bankTotal;
			set
			{
				bankTotal = value;
				OnPropertyChanged("BankTotal");
			}
		}
		
		public PaymentViewModel()
		{
			Total = 0;
			Inserted = 0;
			Change = 0;
			BankTotal = 0;
		}

		//Insert monetary value
		public void Insert(double value)
		{
			Inserted += value;
		}

		//Set the total the requested item costs
		public void SelectedPrice(double value)
		{
			Total = value;
		}

		//Confirm the payment can be made
		public bool Confirm()
		{
			if(Inserted >= Total)
			{
				return true;
			}
			return false;
		}

		public void Pay()
		{
			Change = Total - Inserted;
			BankTotal += Total;
			Inserted = 0;
			Total = 0;
		}

		public void Collect()
		{
			Console.WriteLine("Collected Payments: $" + BankTotal);
			BankTotal = 0;
		}
	}
}
