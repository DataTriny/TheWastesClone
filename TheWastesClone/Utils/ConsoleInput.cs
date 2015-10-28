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
		private string input = string.Empty;
		public event EventHandler<string> InputReceived;
		public event EventHandler<ConsoleKeyInfo> KeyPress;

		public void Update()
		{
			ConsoleKeyInfo keyInfo = Console.ReadKey(true);
			if (KeyPress != null)
				KeyPress(this, keyInfo);
			if (char.IsLetterOrDigit(keyInfo.KeyChar))
			{
				input = input.Substring(0, cursorPos) + keyInfo.KeyChar + input.Substring(cursorPos);
				Console.Write(input.Substring(cursorPos));
				cursorPos++;
				Console.CursorLeft -= input.Substring(cursorPos).Length;
            }
			else if (keyInfo.Key == ConsoleKey.LeftArrow && cursorPos > 0)
			{
				cursorPos--;
				Console.CursorLeft--;
			}
			else if (keyInfo.Key == ConsoleKey.RightArrow && cursorPos < input.Length)
			{
				cursorPos++;
				Console.CursorLeft++;
			}
			else if (keyInfo.Key == ConsoleKey.Backspace && cursorPos > 0)
			{
				input = input.Remove(cursorPos - 1, 1);
				cursorPos--;
				Console.CursorLeft--;
				string text = input.Substring(cursorPos) + " ";
				//if (string.IsNullOrEmpty(text))
				//	text = " ";
				Console.Write(text);
				Console.CursorLeft -= text.Length;
            }
			else if (keyInfo.Key == ConsoleKey.Enter)
			{
				if (InputReceived != null)
					InputReceived(this, input);
				input = string.Empty;
			}
		}
	}
}
