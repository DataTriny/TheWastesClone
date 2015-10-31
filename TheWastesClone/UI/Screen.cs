using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWastesClone.Utils;

namespace TheWastesClone.UI
{
	abstract class Screen
	{
		protected ConsoleInput Input { get; private set; }
		private bool isOpen;

		public Screen()
		{
			Input = new Utils.ConsoleInput();
			Input.KeyPress += OnKeyPress;
			Input.TextEntered += OnTextEntered;
		}

		public void Close()
		{
			isOpen = false;
		}

		protected virtual void OnKeyPress(object sender, ConsoleKeyInfo keyInfo)
		{
		}

		protected virtual void OnTextEntered(object sender, string text)
		{
		}

		public void Open()
		{
			isOpen = true;
			while (!Program.Exitting && isOpen)
			{
				Update();
			}
		}

		public abstract void Update();
	}
}
