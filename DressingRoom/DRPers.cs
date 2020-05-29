using System.Collections.Generic;
using System.Linq;

namespace DressingRoom
{
	public class DRPers
	{
		readonly int Lvl  = 0;
		readonly int Rank = 0;
		public DRClothes Clothes { get; private set; }
		public DRClothes Runes { get; private set; }
		public DRClothes Frames { get; set; }
		public DRStats Stats { get; private set; }
		public DRClothesList ClothesList { get; private set; }
		public DRClothesList RunesList { get; private set; }
		public DRClothesList FramesList { get; private set; }
		public DRPers (int _lvl, int _rank)
		{
			Lvl = _lvl;
			Rank = _rank;
			ClothesList = new DRClothesList(Lvl, Rank);
		}
		public void ClothesSet (int _armor = 0, int _pants = 0, int _mWeapon = 0, int _aWeapon = 0, int _boots = 0, 
			int _hauberk = 0, int _shoulders = 0, int _bangle = 0, int _helmet = 0, int _bow = 0)
		{
			int[] param = new int[10] { _armor, _pants, _mWeapon, _aWeapon, _boots, _hauberk, _shoulders, _bangle, _helmet, _bow };
			Clothes = new DRClothes(param);
			ClothesList = null;
			RunesList = new DRClothesList();
			RunesList.Runes(Clothes, Lvl, Rank);
			FramesList = new DRClothesList();
			FramesList.Frames(Clothes, Lvl, Rank);
		}
		public void RFSet(int _Rarmor = 0, int _Rpants = 0, int _RmWeapon = 0, int _RaWeapon = 0, int _Rboots = 0,
			int _Rhauberk = 0, int _Rshoulders = 0, int _Rbangle = 0, int _Rhelmet = 0, int _Rbow = 0, 
			int _Farmor = 0, int _Fpants = 0, int _FmWeapon = 0, int _FaWeapon = 0, int _Fboots = 0,
			int _Fhauberk = 0, int _Fshoulders = 0, int _Fbangle = 0, int _Fhelmet = 0, int _Fbow = 0)
		{
			int[] paramR = new int[10] { _Rarmor, _Rpants, _RmWeapon, _RaWeapon, _Rboots, _Rhauberk, _Rshoulders, _Rbangle, _Rhelmet, _Rbow };
			int[] paramF = new int[10] { _Farmor, _Fpants, _FmWeapon, _FaWeapon, _Fboots, _Fhauberk, _Fshoulders, _Fbangle, _Fhelmet, _Fbow };
			RunesList = null;
			FramesList = null;
			Runes = new DRClothes();
			Runes.RFSet(paramR);
			Frames = new DRClothes();
			Frames.RFSet(paramF);
			SetStats();
		}
		private void SetStats()
		{
			using (Model dbItems = new Model())
			{
				Stats = new DRStats();
				List<DRStats> _stats = dbItems.DRItems.Where(c =>
				c.Id == Clothes.helmet || c.Id == Clothes.bangle || c.Id == Clothes.shoulders || c.Id == Clothes.hauberk || c.Id == Clothes.boots
				|| c.Id == Clothes.aWeapon || c.Id == Clothes.mWeapon || c.Id == Clothes.pants || c.Id == Clothes.armor || c.Id == Clothes.bow
				|| c.Id == Runes.helmet || c.Id == Runes.bangle || c.Id == Runes.shoulders || c.Id == Runes.hauberk || c.Id == Runes.boots
				|| c.Id == Runes.aWeapon || c.Id == Runes.mWeapon || c.Id == Runes.pants || c.Id == Runes.armor || c.Id == Runes.bow
				|| c.Id == Frames.helmet || c.Id == Frames.bangle || c.Id == Frames.shoulders || c.Id == Frames.hauberk || c.Id == Frames.boots
				|| c.Id == Frames.aWeapon || c.Id == Frames.mWeapon || c.Id == Frames.pants || c.Id == Frames.armor || c.Id == Frames.bow
				|| c.Id == Clothes.bonus).Select(s => new DRStats
				{
					Agility = s.Agility,
					Defense = s.Defense,
					Initiative = s.Initiative,
					Intuition = s.Intuition,
					Intelligence = s.Intelligence,
					Strength = s.Strength,
					Vitality = s.Vitality,
					Wisdom = s.Wisdom,
					Health = s.Health,
					Mana = s.Mana,
					FAprot = s.FAprot,
					LDprot = s.LDprot,
					EWprot =s.EWprot,
					MinMD = s.MinMD,
					MaxMD = s.MaxMD,
					MinPD = s.MinPD,
					MaxPD = s.MaxPD,
					Antitraumatism = s.Antitraumatism,
					Traumatism =s.Traumatism,
					Stamina = s.Stamina,
					Insight = s.Insight,
					Speed = s.Speed
				}).ToList();
				Stats.Agility = _stats.Select(a => a.Agility).Sum();
				Stats.Defense = _stats.Select(a => a.Defense).Sum();
				Stats.Initiative = _stats.Select(a => a.Initiative).Sum();
				Stats.Intuition = _stats.Select(a => a.Intuition).Sum();
				Stats.Intelligence = _stats.Select(a => a.Intelligence).Sum();
				Stats.Strength = _stats.Select(a => a.Strength).Sum();
				Stats.Vitality = _stats.Select(a => a.Vitality).Sum();
				Stats.Wisdom = _stats.Select(a => a.Wisdom).Sum();
				Stats.Health = _stats.Select(a => a.Health).Sum();
				Stats.Mana = _stats.Select(a => a.Mana).Sum();
				Stats.FAprot = _stats.Select(a => a.FAprot).Sum();
				Stats.LDprot = _stats.Select(a => a.LDprot).Sum();
				Stats.EWprot = _stats.Select(a => a.EWprot).Sum();
				Stats.MinMD = _stats.Select(a => a.MinMD).Sum();
				Stats.MaxMD = _stats.Select(a => a.MaxMD).Sum();
				Stats.MinPD = _stats.Select(a => a.MinPD).Sum();
				Stats.MaxPD = _stats.Select(a => a.MaxPD).Sum();
				Stats.Antitraumatism = _stats.Select(a => a.Antitraumatism).Sum();
				Stats.Traumatism = _stats.Select(a => a.Traumatism).Sum();
				Stats.Stamina = _stats.Select(a => a.Stamina).Sum();
				Stats.Insight = _stats.Select(a => a.Insight).Sum();
				Stats.Speed = _stats.Select(a => a.Speed).Sum();
			}
		}
		public List<DRDobl> GetRank(int _lvl)
		{
			using (Model dbItems = new Model())
			{
				return dbItems.DRDobl.Where(r => r.Lvl <= _lvl).ToList();

			}
		}
		public List<DRItemView> GetAW (int _mw)
		{
			using (Model dbItems = new Model())
			{
				int mwWeight = dbItems.DRItems.Where(m => m.Id == _mw).Select(m => m.Weight).Single();
				List<DRItemView> rez;
				if (mwWeight == 1)
				{
					rez = dbItems.DRItems.Where(c => c.Lvl <= Lvl && c.Rank <= Rank && c.Type > 10 && c.Type <= 20 && c.Slot == 4 && c.Weight == 1 || c.Id == 1).
						Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).ToList();
				}
				else
				{
					rez = dbItems.DRItems.Where(c => c.Id == 1).Select(c => new DRItemView
					{
						Id = c.Id,
						NAME = c.NAME,
						ICON = c.ICON,
						Color = c.Color
					}).ToList();
				}
				return rez;
			}
		}
	}
}