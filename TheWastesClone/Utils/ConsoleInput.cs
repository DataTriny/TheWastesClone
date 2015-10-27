using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWastesClone.Utils
{
	class ConsoleInput
	{
		public static int ReadInt()
		{
			int result = 0;
			ConsoleKeyInfo keyInfo;
			do
			{
				keyInfo = Console.ReadKey(true);
				if (char.IsDigit(keyInfo.KeyChar))
				{
					result *= 10;
					result += int.Parse(keyInfo.KeyChar.ToString());
					Console.Write(keyInfo.KeyChar);
				}
			} while (keyInfo.Key != ConsoleKey.Enter);
			return result;
		}
	}
}
