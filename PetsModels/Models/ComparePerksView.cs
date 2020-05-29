using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsModels.Models
{
	public class ComparePerksView
	{
		public int Lvl { get; set; } = 0;
		public int Rank { get; set; } = 0;
		public virtual CPerks Perks1 { get; set; }
		public virtual CPerks Perks2 { get; set; }
		public List<int> BonusList1 { get; set; }
		public List<int> BonusList2 { get; set; }
		public DRItems Bonus1 { set; get; }
		public DRItems Bonus2 { set; get; }
		public virtual CPerks PerksRazn { get; set; }
		public class CPerks
		{
			public int Agility { get; set; } = 0;
			public int Defense { get; set; } = 0;
			public int Initiative { get; set; } = 0;
			public int Intuition { get; set; } = 0;
			public int Intelligence { get; set; } = 0;
			public int Strength { get; set; } = 0;
			public int Vitality { get; set; } = 0;
			public int Wisdom { get; set; } = 0;
			public int Health { get; set; } = 0;
			public int Mana { get; set; } = 0;
			public int FAprot { get; set; } = 0;
			public int LDprot { get; set; } = 0;
			public int EWprot { get; set; } = 0;
			public double MinMD { get; set; } = 0.0;
			public double MaxMD { get; set; } = 0.0;
			public double MinPD { get; set; } = 0.0;
			public double MaxPD { get; set; } = 0.0;
			public int Antitraumatism { get; set; } = 0;
			public int Traumatism { get; set; } = 0;
			public int Stamina { get; set; } = 0;
			public int Insight { get; set; } = 0;
			public int Speed { get; set; } = 0;
		}
	}
}