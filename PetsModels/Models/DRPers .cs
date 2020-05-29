using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetsModels.Models
{
	public class DRPers
	{
		public int Lvl { get; set; } = 0;
		public int Rank { get; set; } = 0;

		public virtual DRClothes Clothes { get; set; }
		public virtual DRClothes Runes { get; set; }
		public virtual DRClothes Frames { get; set; }
		public class DRClothes
		{
			public virtual DRItemView Armor { get; set; }
			public virtual DRItemView Pants { get; set; }
			public virtual DRItemView MWeapon { get; set; }
			public virtual DRItemView AWeapon { get; set; }
			public virtual DRItemView Boots { get; set; }
			public virtual DRItemView Hauberk { get; set; }
			public virtual DRItemView Shoulders { get; set; }
			public virtual DRItemView Bangle { get; set; }
			public virtual DRItemView Helmet { get; set; }
			public virtual DRItemView Bow { get; set; }
			public int Bonus { set; get; } = 0;
		}
		public class DRItemView
		{
			public int Id { get; set; } = 0;
			[StringLength(100)]
			public string NAME { get; set; } = "";
			[StringLength(100)]
			public string LINK { get; set; } = "";
			[StringLength(100)]
			public string ICON { get; set; } = "";
		}
		public virtual DRStats Stats { get; set; }
		public class DRStats
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
		public List<int> BonusList { get; set; }
		public virtual CompareTemp TempClothes { get; set; }
		public virtual CompareTemp TempRunes { get; set; }
		public virtual CompareTemp TempFrames { get; set; }
		public class CompareTemp
			{
				public ICollection<DRItems> Armor { get; set; }
				public ICollection<DRItems> Pants { get; set; }
				public ICollection<DRItems> MWeapon { get; set; }
				public ICollection<DRItems> AWeapon { get; set; }
				public ICollection<DRItems> Boots { get; set; }
				public ICollection<DRItems> Hauberk { get; set; }
				public ICollection<DRItems> Shoulders { get; set; }
				public ICollection<DRItems> Bangle { get; set; }
				public ICollection<DRItems> Helmet { get; set; }
				public ICollection<DRItems> Bow { get; set; }
			}

	}
}