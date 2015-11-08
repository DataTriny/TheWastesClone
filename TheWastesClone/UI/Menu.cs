using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWastesClone.UI
{
	class Menu : Screen
	{
		protected string Error { get; set; }
		public List<MenuItem> Items { get; private set; }
		public string Title { get; protected set; }

		public Menu()
		{
			Items = new List<MenuItem>();
		}

		protected override void OnDraw(object sender, EventArgs e)
		{
			for (int i = 0; i < Items.Count; i++)
				Items[i].OnDraw(this, i + 1);
			base.OnDraw(sender, e);
		}

		protected override void OnTextEntered(object sender, string text)
		{
			int selectedItem = 0;
			if (int.TryParse(text, out selectedItem) && selectedItem > 0 && selectedItem <= Items.Count)
			{
				Error = string.Empty;
				Items[selectedItem - 1].OnValidate(this);
			}
			else
				Error = "ERROR: Please enter a number between 1 and " + Items.Count + ".";
		}

		public override void Update()
		{
			Console.Clear();
			OnDraw(this, new EventArgs());
			Console.ForegroundColor = ConsoleColor.Red;
			if (!string.IsNullOrWhiteSpace(Error))
				Console.WriteLine("\n" + Error);
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("\n" + Input.Text);
			Input.MoveCursor();
			Input.Update();
		}
	}
}
