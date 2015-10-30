using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWastesClone.UI.Menus
{
	class CombatMenu : Menu
	{
		private Creature ally = new Creature();
		private Creature enemy = new Creature();

		public CombatMenu()
		{
			ally.Skills.Agility = 5;
			ally.Skills.Intelligence = 5;
			ally.Skills.MaxHP = 100;
			ally.Skills.Strength = 5;
			Items.Add(new MenuItem("Attack", (sender, e) =>
			{
				AttackResult attack = ally.Attack(enemy);
				string message = "You attack";
				if (attack.Miss)
					message += ", but miss.";
				else if (attack.Critical)
					message += " and get a critical hit for " + attack.Damage.ToString() + " damage.";
				else
					message += " and hit for " + attack.Damage.ToString() + " damage.";
				new Dialog(message).Open();
			}));
			Items.Add(new MenuItem("Flee", (sender, e) =>
			{
				new Dialog("You manage to escape.").Open();
				Close();
			}));
		}
	}
}
