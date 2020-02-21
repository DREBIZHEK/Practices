using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			const string Path = "D:/sharp/18/ConsoleApp1/Telephones.txt";
			using (StreamReader FileIn = new StreamReader(Path, Encoding.GetEncoding(1251)))
			{
				TelephoneBook[] array = new TelephoneBook[16];
				for (int i = 0; i < array.Length; i++)
				{
					string type = FileIn.ReadLine();
					if (type == "Person")
					{
						string Name = FileIn.ReadLine();
						string Address = FileIn.ReadLine();
						string TelephoneNumber = FileIn.ReadLine();
						array[i] = new Person(Name, Address, TelephoneNumber);

					}
					else
					{
						if (type == "Organization")
						{
							string OrgName = FileIn.ReadLine();
							string Address = FileIn.ReadLine();
							string TelephoneNumber = FileIn.ReadLine();
							string Fax = FileIn.ReadLine();
							string ContactPerson = FileIn.ReadLine();
							array[i] = new Organization(OrgName, Address, TelephoneNumber, Fax, ContactPerson);
						}
						else
						{
							string LastName = FileIn.ReadLine();
							string Address = FileIn.ReadLine();
							string TelephoneNumber = FileIn.ReadLine();
							string DateOfBirth = FileIn.ReadLine();
							array[i] = new Friend(LastName, Address, TelephoneNumber, DateOfBirth);
						}
					}
					type = FileIn.ReadLine();
				}
				foreach (TelephoneBook telephoneBook in array)
				{
					telephoneBook.Show();
				}
				Array.Sort(array);
				Console.WriteLine("------------------------------------------------------\nОтсортированный список:\n------------------------------------------------------\n");
				foreach (TelephoneBook telephoneBook in array)
				{
					telephoneBook.Show();
				}
				string Search = "";
				while (Search != "EXIT")
				{
					int ValidCount = 0;
					Console.Write("Введите искомую фамилию или название организации:");
					Search = Console.ReadLine();
					Console.WriteLine("");
					if (Search.Length > 0)
					{
						Console.WriteLine("------------------------------------------------------\nРезультаты поиска:\n------------------------------------------------------");
						foreach (TelephoneBook telephoneBook in array)
						{
							if (telephoneBook.Valid(Search))
							{
								telephoneBook.Show();
								ValidCount++;
							}
						}
						if (ValidCount == 0)
						{
							Console.WriteLine("Нет результатов\n");
						}
					}
				}
			}
		}
	}
}
