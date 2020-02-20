using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	abstract public class TelephoneBook
	{
		protected string Address;
		protected string TelephoneNumber;
		protected string Name;
		abstract public void Show();
		abstract public bool Valid(string Value);

	}
}
