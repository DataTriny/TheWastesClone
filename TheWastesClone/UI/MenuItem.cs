using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWastesClone.UI
{
	class MenuItem
	{
		public event EventHandler<int> Draw;
		public string Title { get; set; }
		public event EventHandler<EventArgs> Validate;

		public MenuItem(string title)
			: this(title, null)
		{
		}

		public MenuItem(string title, EventHandler<EventArgs> onValidate)
		{
			Title = title;
			if (onValidate != null)
				Validate += onValidate;
		}

		public void OnDraw(object sender, int itemIndex)
		{
			if (Draw != null)
				Draw(sender, itemIndex);
			else
				Console.WriteLine(itemIndex.ToString() + ") " + Title);
		}

		public void OnValidate(object sender)
		{
			if (Validate != null)
				Validate(sender, new EventArgs());
		}
	}
}
