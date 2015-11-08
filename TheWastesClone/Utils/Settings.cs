using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWastesClone.Utils
{
	class Settings
	{
		public float MusicVolume
		{
			get { return Program.SoundEngine.SoundVolume; }
			set { Program.SoundEngine.SoundVolume = value; }
		}

		public static Settings Load()
		{
			Settings settings = null;
			StreamReader reader = null;
			try
			{
				reader = new StreamReader("Settings.json");
				settings = JsonConvert.DeserializeObject<Settings>(reader.ReadToEnd());
			}
			catch
			{
			}
			if (reader != null)
				reader.Close();
			if (settings == null)
				settings = LoadDefault();
			return settings;
		}

		public static Settings LoadDefault()
		{
			Settings settings = new Settings();
			settings.MusicVolume = 0.5f;
			return settings;
		}

		public void Save()
		{
			StreamWriter writer = new StreamWriter("Settings.json");
			writer.Write(JsonConvert.SerializeObject(this));
			writer.Close();
		}
	}
}
