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
		}

		public void Close()
		{
			isOpen = false;
		}

		public void Open()
		{
			isOpen = true;
			while (isOpen)
			{
				Update();
			}
		}

		public abstract void Update();
	}
}
