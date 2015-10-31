using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWastesClone.UI.Menus;

namespace TheWastesClone
{
	class Program
	{
		public static bool Exitting { get; set; }

		static void Main(string[] args)
		{
			if (File.Exists("Updater.exe"))
			{
				try
				{
					File.Delete("Updater.exe");
				}
				catch
				{
				}
			}
			new MainMenu().Open();
		}
	}
}
