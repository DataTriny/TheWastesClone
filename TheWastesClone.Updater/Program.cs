using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheWastesClone.Updater
{
	class Program
	{
		static void Main(string[] args)
		{
			int id = 0;
			Process process = null;
			if (args.Length != 1 || !int.TryParse(args[0], out id))
			{
				Console.WriteLine("Unable to update.");
				Console.ReadKey(true);
				LaunchGame();
				return;
			}
			try
			{
				process = Process.GetProcessById(id);
				if (process != null)
					process.WaitForExit();
			}
			catch
			{
			}
			WebClient client = new WebClient();
			Console.WriteLine("Downloading update...");
			try
			{
				client.DownloadFile("https://dl.dropboxusercontent.com/u/100909891/TheWastesClone/Update.zip", Path.Combine(Application.StartupPath, "Update.zip"));
			}
			catch
			{
				File.Delete(Path.Combine(Application.StartupPath, "Update.zip"));
				Console.WriteLine("Unable to download the update.");
				Console.ReadKey(true);
				LaunchGame();
				return;
			}
			Console.WriteLine("Removing previous version...");
			File.Delete(Path.Combine(Application.StartupPath, "TheWastesClone.exe"));
			Directory.Delete(Path.Combine(Application.StartupPath, "Content"), true);
			Console.WriteLine("Extracting update...");
			ZipFile.ExtractToDirectory(Path.Combine(Application.StartupPath, "Update.zip"), Application.StartupPath);
			Console.WriteLine("Removing update...");
			File.Delete(Path.Combine(Application.StartupPath, "Update.zip"));
			Console.WriteLine("Launching the game...");
			LaunchGame();
		}

		private static void LaunchGame()
		{
			Process process = new Process();
			process.StartInfo.FileName = Path.Combine(Application.StartupPath, "TheWastesClone.exe");
			try
			{
				process.Start();
			}
			catch
			{
			}
		}
	}
}
