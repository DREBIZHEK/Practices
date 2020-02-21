using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	abstract public class TelephoneBook : IComparable<TelephoneBook>
	{
		protected string Address;
		protected string TelephoneNumber;
		protected string Name;

		abstract public void Show();
		abstract public bool Valid(string Value);

		private double ConvertTelephoneNumber(string TelephoneNumber)
		{
			char[] separators = { '+', '-', '(', ')', ' '};
			string[] splitString = TelephoneNumber.Split(separators);
			string convertedTelephoneNumber = "";
			foreach(string path in splitString)
			{
				convertedTelephoneNumber += path;
			}
			return double.Parse(convertedTelephoneNumber);
		}

		public int CompareTo(TelephoneBook other)
		{
			if (this.TelephoneNumber == other.TelephoneNumber)
			{
				return 0;
			}
			else
			{
				if (ConvertTelephoneNumber(this.TelephoneNumber) < ConvertTelephoneNumber(other.TelephoneNumber))
				{
					return 1;
				}

				else
				{
					return -1;
				}
			}
		}
	}
}
