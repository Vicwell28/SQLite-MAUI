using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_MAUI.Models
{
	public class TableData
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
	}
}