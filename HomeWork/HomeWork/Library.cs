using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
	public class Library
	{
		public List<Disc> discs = new List<Disc>();

		public void AddDisc(string disc)
		{
			string discName = disc;
			bool check = true;
			foreach (var dis in discs.ToArray())
			{
				if (dis.ShowName() == discName)
				{
					check = false;
					Console.WriteLine("Диск с таким названием уже существует");
					break;
				}
			}
			if (check)
			{
				Disc newDisc = new Disc(discName);
				discs.Add(newDisc);
				Console.WriteLine("Диск {0} добавлен", discName);
			}
		}

		public void RemoveDisc(string disc)
		{
			bool check = true;
			string discName = disc;
			foreach (var dis in discs.ToArray())
			{
				if (dis.ShowName() == discName)
				{
					discs.Remove(dis);
					Console.WriteLine("Диск {0} удален", discName);
					check = false;
					break;
				}
			}
			if (check)
			{
				Console.WriteLine("Такого диска не существует");
			}
			check = true;
		}

		public void Show()
		{
			Console.WriteLine("\nСписок дисков:");
			foreach (var disc in discs)
			{
				Console.WriteLine(disc.ShowName());
			}
		}

		public Library()
		{

		}


	}
}
