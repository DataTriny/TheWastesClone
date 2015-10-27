using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWastesClone.UI
{
	abstract class Screen
	{
		private bool isOpen;

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
