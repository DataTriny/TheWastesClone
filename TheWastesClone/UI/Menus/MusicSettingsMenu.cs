using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWastesClone.UI.Menus
{
	class MusicSettingsMenu : Menu
	{
		public MusicSettingsMenu()
		{
			Items.Add(new MenuItem("Max", (sender, e) =>
			{
				Program.SoundEngine.SoundVolume = 1f;
				Close();
			}));
			Items.Add(new MenuItem("High", (sender, e) =>
			{
				Program.SoundEngine.SoundVolume = 0.75f;
				Close();
			}));
			Items.Add(new MenuItem("Normal", (sender, e) =>
			{
				Program.SoundEngine.SoundVolume = 0.5f;
				Close();
			}));
			Items.Add(new MenuItem("Low", (sender, e) =>
			{
				Program.SoundEngine.SoundVolume = 0.25f;
				Close();
			}));
			Items.Add(new MenuItem("Off", (sender, e) =>
			{
				Program.SoundEngine.SoundVolume = 0f;
				Close();
			}));
		}
	}
}
