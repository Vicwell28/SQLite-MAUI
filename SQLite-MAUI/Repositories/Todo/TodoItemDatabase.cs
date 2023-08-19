using Bogus.DataSets;
using SQLite;
using SQLite_MAUI.Models.TodoItem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SQLite_MAUI.Repositories.Todo
{
	public class TodoItemDatabase 
	{
		public ICommand GetItemsAsyncCommand { get; }
		public ICommand SaveItemAsyncCommand { get; }
		public ICommand DeleteItemAsyncCommand { get; }
		public ICommand UpdateItemAsyncCommand { get; }

		SQLiteAsyncConnection Database;

		public TodoItemDatabase()
		{
			GetItemsAsyncCommand = new Command(async () => await GetItemsAsyncClicked());
			SaveItemAsyncCommand = new Command(async () => await SaveItemAsyncClicked());
			DeleteItemAsyncCommand = new Command(async () => await DeleteItemAsyncClicked());
			UpdateItemAsyncCommand = new Command(async () => await UpdateItemAsyncClicked());
		}

		async Task Init()
		{
			if (Database != null)
				return;

			Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
			var result = await Database.CreateTableAsync<TodoItemModel>();
		}

		public async Task<List<TodoItemModel>> GetItemsAsync()
		{
			await Init();
			return await Database.Table<TodoItemModel>().ToListAsync();
		}

		public async Task<int> SaveItemAsync(TodoItemModel item)
		{
			await Init();
			return item.ID != 0 ? await Database.UpdateAsync(item) : await Database.InsertAsync(item);
		}

		public async Task<int> DeleteItemAsync(TodoItemModel item)
		{
			await Init();
			return await Database.DeleteAsync(item);
		}

		public async Task GetItemsAsyncClicked()
		{
			var items = await GetItemsAsync();

			Debug.WriteLine("Current items in database:");
			foreach (var item in items)
			{
				Debug.WriteLine($"ID: {item.ID}, Name: {item.Name}, Done: {item.Done}");
			}
		}

		public async Task SaveItemAsyncClicked()
		{
			var newItem = new TodoItemModel()
			{
				Name = "New Todo Item",
				Done = false
			};

			var rows = await SaveItemAsync(newItem);
			Debug.WriteLine($"Saved item with ID: {newItem.ID}");
			await GetItemsAsyncClicked();
		}

		public async Task DeleteItemAsyncClicked()
		{
			var items = await GetItemsAsync();

			if (items.Any())
			{
				var firstItem = items.First();
				var rows = await DeleteItemAsync(firstItem);

				Debug.WriteLine($"Deleted item with ID: {firstItem.ID}");
				await GetItemsAsyncClicked();
			}
			else
			{
				Debug.WriteLine("No items to delete.");
			}
		}

		public async Task UpdateItemAsyncClicked()
		{
			var items = await GetItemsAsync();

			if (items.Any())
			{
				var firstItem = items.First();
				firstItem.Name = "Updated Todo Item";
				firstItem.Done = true;

				var rows = await SaveItemAsync(firstItem);
				Debug.WriteLine($"Updated item with ID: {firstItem.ID}");
				await GetItemsAsyncClicked();
			}
			else
			{
				Debug.WriteLine("No items to update.");
			}
		}
	}
}
