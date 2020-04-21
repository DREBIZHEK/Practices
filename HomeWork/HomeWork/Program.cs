using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HomeWork;

namespace ConsoleApp32
{
	class Program
	{
		static void Main(string[] args)
		{
			Library library = new Library();
			Console.WriteLine("Список команд:");
			Console.WriteLine("Add Disc - добавить новый диск");
			Console.WriteLine("Add Song - добавить новую песню");
			Console.WriteLine("Remove Disc - удалить диск");
			Console.WriteLine("Remove Song - удалить песню");
			Console.WriteLine("Show Disc - показать все диски");
			Console.WriteLine("Show Songs - показать все песни на диске");
			Console.WriteLine("Show All Songs - показать все песни");
			Console.WriteLine("Sort Songs  - отсортировать песни на диске");
			Console.WriteLine("Exit - закрыть");
			string comand = "";
			string anyName;
			while (comand != "exit")
			{
				comand = Console.ReadLine();
				comand = comand.ToLower();
				if (comand == "add disc")
				{
					Console.WriteLine("Введите название диска:");
					anyName = Console.ReadLine();
					library.AddDisc(anyName);
					Console.WriteLine("Диск {0} добавлен", anyName);
				}

				if (comand == "add song")
				{
					library.Show();
					Console.WriteLine("Введите название диска для добавления песни:");
					anyName = Console.ReadLine();
					foreach(var disc in library.discs)
					{
						if (disc.ShowName() == anyName)
						{
							Console.WriteLine("Введите имя артиста");
							string aName = Console.ReadLine();
							Console.WriteLine("Введите название песни");
							string sName = Console.ReadLine();
							disc.AddSong(aName, sName);
							Console.WriteLine("Песня {0} добавлена", sName);
						}
					}
				}

				if(comand == "remove disc")
				{
					library.Show();
					Console.WriteLine("Введите название диска для удаления:");
					anyName = Console.ReadLine();
					library.RemoveDisc(anyName);
					Console.WriteLine("Диск {0} удален", anyName);
				}

				if (comand == "remove song")
				{
					library.Show();
					Console.WriteLine("Введите название диска с которого вы хотите удалить песню:");
					anyName = Console.ReadLine();
					foreach (var disc in library.discs)
					{
						if (disc.ShowName() == anyName)
						{
							Console.WriteLine("\nСписок песен:");
							disc.Show();
							Console.WriteLine("Введите название песни которую хотите удалить");
							anyName = Console.ReadLine();
							foreach (var song in library.discs)
							{
								song.RemoveSong(anyName);
							}

						}
					}

				}

				if (comand == "show disc")
				{
					library.Show();
				}

				if (comand == "show songs")
				{
					library.Show();
					Console.WriteLine("Введите название диска для просмотра песен:");
					anyName = Console.ReadLine();
					foreach (var disc in library.discs)
					{
						if (disc.ShowName() == anyName)
						{
							Console.WriteLine("\nСписок песен:");
							disc.Show();
						}
					}
				}

				if (comand == "show all songs")
				{
					foreach (var disc in library.discs)
					{
						Console.WriteLine("\nСписок песен:");
						disc.Show();
					}
				}

				if (comand == "sort songs")
				{
					library.Show();
					Console.WriteLine("Введите название диска для сортировки песен:");
					anyName = Console.ReadLine();
					foreach (var disc in library.discs)
					{
						if (disc.ShowName() == anyName)
						{
							disc.songs.Sort();
							Console.WriteLine("\nСписок песен:");
							disc.Show();
						}
					}
				}
			}

		}
	}
}
