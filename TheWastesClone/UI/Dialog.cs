using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWastesClone.UI
{
	class Dialog : Screen
	{
		public string Message { get; set; }

		public Dialog(string message)
		{
			Message = message;
		}

		public override void Update()
		{
			Console.Clear();
			Console.WriteLine(Message);
			Input.Update();
			Close();
		}
	}
}
