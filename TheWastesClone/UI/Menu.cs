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

		public Menu()
		{
			Items = new List<MenuItem>();
		}

		public override void Update()
		{
			Console.Clear();
			for (int i = 0; i < Items.Count; i++)
				Items[i].OnDraw(this, i + 1);
			Console.Write(Input.Text);
			Input.MoveCursor();
			Input.Update();
		}
	}
}
