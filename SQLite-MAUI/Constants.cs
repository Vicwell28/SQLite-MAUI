using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_MAUI
{
	public static class Constants
	{
		public const string DatabaseFilename = "TodoSQLite.db3";

		public const 
			 SQLiteOpenFlags Flags =
			 SQLiteOpenFlags.ReadWrite |
			 SQLiteOpenFlags.Create |
			 SQLiteOpenFlags.SharedCache;

		public static string DatabasePath
		{
			get
			{
				Debug.WriteLine("ESTE ES EL PATH"); 
				Debug.WriteLine(FileSystem.AppDataDirectory); 
				return Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
			}
		}
	}
}
