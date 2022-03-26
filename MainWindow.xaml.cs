using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_VendingMachine.ViewModels;

namespace WPF_VendingMachine
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private MachineViewModel machine = new MachineViewModel();
		public MainWindow()
		{
			InitializeComponent();
			DataContext = machine;
		}

		private void Purchase_Clicked(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			machine.Purchase(button.DataContext);
		}

		private void Insert25_Clicked(object sender, RoutedEventArgs e)
		{
			machine.InsertChange(0.25);
		}

		private void Insert50_Clicked(object sender, RoutedEventArgs e)
		{
			machine.InsertChange(0.50);
		}

		private void Insert75_Clicked(object sender, RoutedEventArgs e)
		{
			machine.InsertChange(0.75);
		}

		private void Refill_Clicked(object sender, RoutedEventArgs e)
		{
			machine.Refill();
		}

		private void Withdraw_Clicked(object sender, RoutedEventArgs e)
		{
			machine.CollectPayments();
		}

		private void Empty_Clicked(object sender, RoutedEventArgs e)
		{
			machine.Empty();
		}
	}
}
