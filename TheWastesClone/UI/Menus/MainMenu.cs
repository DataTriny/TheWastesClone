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
			Items.Add(new MenuItem("Start a new game"));
			Items.Add(new MenuItem("Load a saved game"));
			Items.Add(new MenuItem("Options"));
			Items.Add(new MenuItem("Credits"));
			Items.Add(new MenuItem("Exit"));
		}
	}
}
