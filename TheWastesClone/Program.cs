using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWastesClone.UI.Menus;

namespace TheWastesClone
{
	class Program
	{
		static void Main(string[] args)
		{
			MainMenu menu = new MainMenu();
			menu.Open();
			Console.ReadKey(true);
		}
	}
}
