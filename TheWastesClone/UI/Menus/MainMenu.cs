using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWastesClone.UI.Menus
{
	class MainMenu : Menu
	{
		public MainMenu()
		{
			Items.Add(new MenuItem("Start a new game", (sender, e) =>
			{
				new CombatMenu().Open();
				Close();
			}));
			Items.Add(new MenuItem("Load a saved game"));
			Items.Add(new MenuItem("Options", (sender, e) =>
			{
				new OptionsMenu().Open();
			}));
			Items.Add(new MenuItem("Credits", (sender, e) =>
			{
				new Dialog("The Wastes Clone (version 0.1)\nCreated by DataTriny\nBased on the original game by Huw Millward").Open();
			}));
			Items.Add(new MenuItem("Exit", (sender, e) =>
			{
				Close();
			}));
		}
	}
}
