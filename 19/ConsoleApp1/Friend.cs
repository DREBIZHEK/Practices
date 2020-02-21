using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Friend : TelephoneBook
	{
		private string DateOfBirth;
		
		public Friend() { }

		public Friend(string Name, string Address, string TelephoneNumber, string DateOfBirth)
		{
			this.Name = Name;
			this.Address = Address;
			this.TelephoneNumber = TelephoneNumber;
			this.DateOfBirth = DateOfBirth;
		}

		public override void Show()
		{
			Console.WriteLine("Name: {0}", Name);
			Console.WriteLine("Address: {0}", Address);
			Console.WriteLine("Telephone Number: {0}", TelephoneNumber);
			Console.WriteLine("Date of birth: {0}", DateOfBirth);
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
