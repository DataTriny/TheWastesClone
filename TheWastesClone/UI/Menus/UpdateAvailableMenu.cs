using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TheWastesClone.UI.Menus
{
	class UpdateAvailableMenu : Menu
	{
		public UpdateAvailableMenu()
		{
			Items.Add(new MenuItem("Update", (sender, e) =>
			{
				WebClient client = new WebClient();
				try
				{
					client.DownloadFile("https://dl.dropboxusercontent.com/u/100909891/TheWastesClone/Updater.exe", "Updater.exe");
					Process process = new Process();
					process.StartInfo.Arguments = Process.GetCurrentProcess().Id.ToString();
					process.StartInfo.FileName = "Updater.exe";
					process.Start();
					Program.Exitting = true;
				}
				catch (Exception ex)
				{
					new Dialog("Unable to download update.\nPlease retry later.").Open();
					Close();
				}
			}));
			Items.Add(new MenuItem("Back", (sender, e) =>
			{
				Close();
			}));
		}
	}
}
