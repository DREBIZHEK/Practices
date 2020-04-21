using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
	public class Library
	{
		private int count = 0;
		public List<Disc> discs = new List<Disc>();

		public void AddDisc(string disc)
		{
			string discName = disc;
			Disc newDisc = new Disc(discName);
			discs.Add(newDisc);
			count = discs.Count;
		}

		public void RemoveDisc(string disc)
		{
			string discName = disc;
			foreach (var dis in discs.ToArray())
			{
				if (dis.ShowName() == discName)
				{
					discs.Remove(dis);
				}
			}
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
