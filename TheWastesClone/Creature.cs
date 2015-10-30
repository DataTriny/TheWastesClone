using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWastesClone
{
	class Creature
	{
		public int HP { get; set; }
		public bool IsDead { get; private set; }
		public bool IsMutant { get; private set; }
		public int Level { get; set; }
		public double Money { get; set; }
		private Random rand = new Random(System.Environment.TickCount);
		public Skills Skills { get; private set; }
		public int XP { get; set; }

		public Creature()
		{
			Skills = new Skills();
		}

		public AttackResult Attack(Creature target)
		{
			AttackResult result = new AttackResult();
			double chance = 1 / Math.Log(Skills.Agility * 1.25);
			double percentage = rand.NextDouble();
			result.Critical = percentage > 0.99;
			result.Miss = percentage >= chance;
			if (!result.Miss)
			{
				result.Damage = rand.Next(1, Skills.Strength + 1);
				if (result.Critical)
					result.Damage *= 2;
				target.HP = result.Damage;
				target.IsDead = target.HP <= 0;
			}
			return result;
		}
	}
}
