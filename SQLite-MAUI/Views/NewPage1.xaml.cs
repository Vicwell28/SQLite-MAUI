using SQLite_MAUI.Repositories.Todo;

namespace SQLite_MAUI.Views;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
		this.BindingContext = new TodoItemDatabase();
	}
}