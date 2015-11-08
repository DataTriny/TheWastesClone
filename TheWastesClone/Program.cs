using IrrKlang;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWastesClone.UI.Menus;
using TheWastesClone.Utils;

namespace TheWastesClone
{
	class Program
	{
		public static bool Exitting { get; set; }
		public static Settings Settings { get; private set; }
		public static ISoundEngine SoundEngine { get; private set; }

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
			SoundEngine = new ISoundEngine(SoundOutputDriver.AutoDetect, SoundEngineOptionFlag.DefaultOptions | SoundEngineOptionFlag.PrintDebugInfoIntoDebugger);
			Settings = Settings.Load();
			new MainMenu().Open();
		}
	}
}
