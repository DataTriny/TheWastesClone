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
		public event EventHandler<EventArgs> Closing;
		public event EventHandler<EventArgs> Drawing;
		protected ConsoleInput Input { get; private set; }
		private bool isOpen;
		public event EventHandler<EventArgs> Opening;

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

		public string GetCenteredText(string text)
		{
			StringBuilder sb = new StringBuilder();
			int margin = (Console.WindowWidth - text.Length - 1) / 2;
			for (int i = 0; i < margin; i++)
				sb.Append(" ");
			sb.Append(text);
			return sb.ToString();
		}

		public string GetLine()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < Console.WindowWidth - 1; i++)
				sb.Append("-");
			return sb.ToString();
		}

		protected virtual void OnClose(object sender, EventArgs e)
		{
			if (Closing != null)
				Closing(this, new EventArgs());
		}

		protected virtual void OnDraw(object sender, EventArgs e)
		{
			if (Drawing != null)
				Drawing(this, new EventArgs());
		}

		protected virtual void OnKeyPress(object sender, ConsoleKeyInfo keyInfo)
		{
		}

		protected virtual void OnOpen(object sender, EventArgs e)
		{
			if (Opening != null)
				Opening(this, new EventArgs());
		}

		protected virtual void OnTextEntered(object sender, string text)
		{
		}

		public void Open()
		{
			isOpen = true;
			OnOpen(this, new EventArgs());
			while (!Program.Exitting && isOpen)
			{
				Update();
			}
			OnClose(this, new EventArgs());
		}

		public abstract void Update();
	}
}
