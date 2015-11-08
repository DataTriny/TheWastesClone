using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TheWastesClone.UI.Menus
{
	class OptionsMenu : Menu
	{
		public OptionsMenu()
		{
			Items.Add(new MenuItem("Music settings", (sender, e) =>
			{
				new MusicSettingsMenu().Open();
			}));
			Items.Add(new MenuItem("Check for update", (sender, e) =>
			{
				WebClient client = new WebClient();
				string latestVersion = string.Empty;
				try
				{
					latestVersion = client.DownloadString("https://dl.dropboxusercontent.com/u/100909891/TheWastesClone/Version.txt");
					if (latestVersion == Assembly.GetExecutingAssembly().GetName().Version.ToString())
						new Dialog("You already have the latest version.").Open();
					else
					{
						new UpdateAvailableMenu().Open();
					}
				}
				catch
				{
					new Dialog("Unable to check for update.\nPlease retry later.").Open();
				}
			}));
		}

		protected override void OnDraw(object sender, EventArgs e)
		{
			base.OnDraw(sender, e);
			Console.WriteLine(GetLine());
		}
	}
}
