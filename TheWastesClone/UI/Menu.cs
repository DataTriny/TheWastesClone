using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWastesClone.UI
{
	class Menu : Screen
	{
		public List<MenuItem> Items { get; private set; }
		public int SelectedItem { get; protected set; }
		public string Title { get; protected set; }

		public override void Update()
		{
			
		}
	}
}
