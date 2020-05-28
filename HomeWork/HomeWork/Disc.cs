using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
	public class Disc
	{
		private string discName { get; }
		private int count = 0;
		public List<Song> songs = new List<Song>();
		public void AddSong(string artist, string song)
		{
			string artistName = artist;
			string songName = song;
			Song newSong = new Song(artistName, songName);
			songs.Add(newSong);
			count = songs.Count;
		}

		public string ShowName()
		{
			return (discName);
		}

		public void Show()
		{

			foreach (var song in songs)
			{
				Console.WriteLine("");
				song.Show();
			}
		}

		public void RemoveSong(string son)
		{
			bool check = false;
			string sonName = son;
			foreach (var dis in songs.ToArray())
			{
				if (dis.ShowName() == sonName)
				{
					check = true;
				}
				if (check)
				{
					songs.Remove(dis);
					Console.WriteLine("Песня {0 удалена}", sonName);
					break;
				}
			}
			if (!check)
			{
				Console.WriteLine("Такой песни не существует");
			}

		}

		public void SearchSong(string name)
		{
			bool check = false;
			string sonName = name;
			foreach (var dis in songs.ToArray())
			{
				if (dis.ShowArtistName() == sonName)
				{
					check = true;
				}
				if(check)
				{
					dis.Show();
					check = false;
				}
			}

		}

		public Disc(string name)
		{
			discName = name;
		}
		public Disc()
		{

		}

	}
}
