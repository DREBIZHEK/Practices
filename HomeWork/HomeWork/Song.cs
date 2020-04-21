using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
	public class Song: IComparable<Song>
	{
		private string artist { get; }
		private string songName { get; }

		public void Show()
		{
			Console.WriteLine("Исполнитель:{0} \nПесня:{1}", artist, songName);
		}

		public int CompareTo(Song other)
		{
			return String.Compare(this.artist, other.artist);
		}
		public string ShowName()
		{
			return (songName);
		}

		public string ShowArtistName()
		{
			return (artist);
		}

		public Song()
		{

		}
		public Song(string aName, string sName)
		{
			artist = aName;
			songName = sName;
		}

	}
}
