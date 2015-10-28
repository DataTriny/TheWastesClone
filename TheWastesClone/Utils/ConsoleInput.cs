using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWastesClone.Utils
{
	class ConsoleInput
	{
		private int cursorPos = 0;
		public event EventHandler<string> InputReceived;
		public event EventHandler<ConsoleKeyInfo> KeyPress;
		public string Text { get; set; }

		public ConsoleInput()
		{
			Text = string.Empty;
		}

		public void MoveCursor()
		{
			Console.CursorLeft -= Text.Length - cursorPos;
		}

		public void Update()
		{
			ConsoleKeyInfo keyInfo = Console.ReadKey(true);
			if (KeyPress != null)
				KeyPress(this, keyInfo);
			if (char.IsLetterOrDigit(keyInfo.KeyChar))
			{
				Text = Text.Substring(0, cursorPos) + keyInfo.KeyChar + Text.Substring(cursorPos);
				cursorPos++;
            }
			else if (keyInfo.Key == ConsoleKey.LeftArrow && cursorPos > 0)
				cursorPos--;
			else if (keyInfo.Key == ConsoleKey.RightArrow && cursorPos < Text.Length)
				cursorPos++;
			else if (keyInfo.Key == ConsoleKey.Backspace && cursorPos > 0)
			{
				Text = Text.Remove(cursorPos - 1, 1);
				cursorPos--;
            }
			else if (keyInfo.Key == ConsoleKey.Enter)
			{
				if (InputReceived != null)
					InputReceived(this, Text);
				Text = string.Empty;
				cursorPos = 0;
			}
		}
	}
}
