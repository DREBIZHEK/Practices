using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public class Person : TelephoneBook
	{
		public Person() { }

		public Person(string Name, string Address, string TelephoneNumber)
		{
			this.Name = Name;
			this.Address = Address;
			this.TelephoneNumber = TelephoneNumber;

		}

		public override void Show()
		{
			Console.WriteLine("Name: {0}", Name);
			Console.WriteLine("Address: {0}", Address);
			Console.WriteLine("Telepgone Number: {0}", TelephoneNumber);
			Console.WriteLine();
		}

		public override bool Valid(string Value)
		{
			string CheckName = Name.ToLower();
			string CheckValue = Value.ToLower();
			return (CheckName.Contains(CheckValue));
		}
	}
}
