using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public class Organization : TelephoneBook
	{
		private string Fax;
		private string ContactPerson;

		public Organization() { }

		public Organization(string Name, string Address, string TelephoneNumber, string Fax, string ContactPerson)
		{
			this.Name = Name;
			this.Address = Address;
			this.TelephoneNumber = TelephoneNumber;
			this.Fax = Fax;
			this.ContactPerson = ContactPerson;

		}
		public override void Show()
		{
			Console.WriteLine("Organization Name: {0}", Name);
			Console.WriteLine("Address: {0}", Address);
			Console.WriteLine("Telephone Number: {0}", TelephoneNumber);
			Console.WriteLine("Fax: {0}", Fax);
			Console.WriteLine("Contact Person: {0}", ContactPerson);
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
