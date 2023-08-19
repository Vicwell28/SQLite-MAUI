using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_MAUI.Models
{
	public class Passport : TableData
	{
		public DateTime ExpirationDate { get; set; }

		//[ForeignKey(typeof(Customer))]
		[ManyToMany(typeof(Customer))]
		public int CustomerId { get; set; }
	}
}