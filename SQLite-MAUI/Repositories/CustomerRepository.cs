using SQLite;
using SQLite_MAUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_MAUI.Repositories
{
	public class CustomerRepository
	{
		SQLiteConnection connection { set; get; }
		string StatusMessage { set; get; }

		public CustomerRepository() 
		{
			this.connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags); 
			this.connection.CreateTable<Customer>();
		}

		public void AddOrUpdate(Customer customer)
		{
			int result = 0;
			try
			{
				if (customer.Id != 0)
				{
					result =
						 connection.Update(customer);
					StatusMessage =
						 $"{result} row(s) updated";
				}
				else
				{
					result = connection.Insert(customer);
					StatusMessage =
						 $"{result} row(s) added";
				}

			}
			catch (Exception ex)
			{
				StatusMessage =
					 $"Error: {ex.Message}";
			}
		}

		public List<Customer> GetAll()
		{
			try
			{
				return connection.Table<Customer>().ToList();
			}
			catch (Exception ex)
			{
				StatusMessage =
					 $"Error: {ex.Message}";
			}
			return null;
		}

		public List<Customer> GetAll(Expression<Func<Customer, bool>> predicate)
		{
			try
			{
				return connection.Table<Customer>().Where(predicate).ToList();
			}
			catch (Exception ex)
			{
				StatusMessage =
					 $"Error: {ex.Message}";
			}
			return null;
		}

		public List<Customer> GetAll2()
		{
			try
			{
				return connection.Query<Customer>("SELECT * FROM Customers").ToList();
			}
			catch (Exception ex)
			{
				StatusMessage =
					 $"Error: {ex.Message}";
			}
			return null;
		}

		public Customer Get(int id)
		{
			try
			{
				return
					 connection.Table<Customer>()
					 .FirstOrDefault(x => x.Id == id);
			}
			catch (Exception ex)
			{
				StatusMessage =
					 $"Error: {ex.Message}";
			}
			return null;
		}

		public void Delete(int customerId)
		{
			try
			{
				var customer =
					 Get(customerId);
				connection.Delete(customer);
			}
			catch (Exception ex)
			{
				StatusMessage =
					 $"Error: {ex.Message}";
			}
		}
	}
}