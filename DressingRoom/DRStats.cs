using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressingRoom
{
	public class DRStats
	{
		public int Agility { get; internal set; } = 0;
		public int Defense { get; internal set; } = 0;
		public int Initiative { get; internal set; } = 0;
		public int Intuition { get; internal set; } = 0;
		public int Intelligence { get; internal set; } = 0;
		public int Strength { get; internal set; } = 0;
		public int Vitality { get; internal set; } = 0;
		public int Wisdom { get; internal set; } = 0;
		public int Health { get; internal set; } = 0;
		public int Mana { get; internal set; } = 0;
		public int FAprot { get; internal set; } = 0;
		public int LDprot { get; internal set; } = 0;
		public int EWprot { get; internal set; } = 0;
		public double MinMD { get; internal set; } = 0.0;
		public double MaxMD { get; internal set; } = 0.0;
		public double MinPD { get; internal set; } = 0.0;
		public double MaxPD { get; internal set; } = 0.0;
		public int Antitraumatism { get; internal set; } = 0;
		public int Traumatism { get; internal set; } = 0;
		public int Stamina { get; internal set; } = 0;
		public int Insight { get; internal set; } = 0;
		public int Speed { get; internal set; } = 0;
	}
}
