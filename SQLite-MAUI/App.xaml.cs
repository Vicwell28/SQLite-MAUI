using SQLite_MAUI.Models;
using SQLite_MAUI.Repositories;
using SQLite_MAUI.Views;

namespace SQLite_MAUI;

public partial class App : Application
{
	//public static CustomerRepository CustomerRepo { get; private set; }
	public static BaseRepository<Customer> CustomerRepo { get; private set; }
	public static BaseRepository<Order> OrdersRepo { get; private set; }
	public static BaseRepository<Passport> PassportsRepo { get; private set; }

	public App(
		)
	{
		InitializeComponent();


		MainPage = new NewPage1();
	}
}