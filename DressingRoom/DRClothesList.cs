using System.Collections.Generic;
using System.Linq;

namespace DressingRoom
{
	public class DRClothesList
	{
		public List<DRItemView> Armor { get; private set; }
		public List<DRItemView> Pants { get; private set; }
		public List<DRItemView> MWeapon { get; private set; }
		public List<DRItemView> AWeapon { get; private set; }
		public List<DRItemView> Boots { get; private set; }
		public List<DRItemView> Hauberk { get; private set; }
		public List<DRItemView> Shoulders { get; private set; }
		public List<DRItemView> Bangle { get; private set; }
		public List<DRItemView> Helmet { get; private set; }
		public List<DRItemView> Bow { get; private set; }

		public DRClothesList (int _lvl, int _rank)
		{
			using (Model dbItems = new Model())
			{
				var CList = dbItems.DRItems.Where(c => c.Lvl <= _lvl && c.Rank <= _rank && c.Type > 10 && c.Type <= 20 || c.Id == 1).Select(c => new
				{
					c.Id,
					c.NAME,
					c.ICON,
					c.Color,
					c.Slot
				}).ToList();
				Armor = CList.Where(c => c.Slot == 1 || c.Id == 1).Select(c => new DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					Color = c.Color
				}).ToList();
				Pants = CList.Where(c => c.Slot == 2 || c.Id == 1).Select(c => new DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					Color = c.Color
				}).ToList();
				MWeapon = CList.Where(c => c.Slot == 3 || c.Id == 1).Select(c => new DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					Color = c.Color
				}).ToList();
				AWeapon = CList.Where(c => c.Id == 1).Select(c => new DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					Color = c.Color
				}).ToList();
				Boots = CList.Where(c => c.Slot == 5 || c.Id == 1).Select(c => new DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					Color = c.Color
				}).ToList();
				Hauberk = CList.Where(c => c.Slot == 6 || c.Id == 1).Select(c => new DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					Color = c.Color
				}).ToList();
				Shoulders = CList.Where(c => c.Slot == 7 || c.Id == 1).Select(c => new DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					Color = c.Color
				}).ToList();
				Bangle = CList.Where(c => c.Slot == 8 || c.Id == 1).Select(c => new DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					Color = c.Color
				}).ToList();
				Helmet = CList.Where(c => c.Slot == 9 || c.Id == 1).Select(c => new DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					Color = c.Color
				}).ToList();
				Bow = CList.Where(c => c.Slot == 10 || c.Id == 1).Select(c => new DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					Color = c.Color
				}).ToList();
				CList = null;
			}
		}
		public DRClothesList()
		{
		}
		public void Runes (DRClothes _clothes, int _lvl, int _rank)
		{
			using (Model dbItems = new Model())
			{
				List<DRItems> items = dbItems.DRItems.Where(c => c.Lvl <= _lvl && c.Rank <= _rank && c.Type > 20 && c.Type <= 30).ToList();
				Armor = items.Where(c => c.Slot == 1
					 && c.LvlSet <= dbItems.DRItems.Where(a => a.Id == _clothes.Armor.Id).Select(a => a.LvlSet).FirstOrDefault()
					 && c.Style == dbItems.DRItems.Where(b => b.Id == _clothes.Armor.Id).Select(b => b.Style).FirstOrDefault()
					 || c.Id == 1).Select(c => new DRItemView
					 {
						 Id = c.Id,
						 NAME = c.NAME,
						 ICON = c.ICON,
						 Color = c.Color
					 }).ToList();
				Pants = items.Where(c => c.Slot == 2
					&& c.LvlSet <= dbItems.DRItems.Where(a => a.Id == _clothes.Pants.Id).Select(a => a.LvlSet).FirstOrDefault()
					&& c.Style == dbItems.DRItems.Where(b => b.Id == _clothes.Pants.Id).Select(b => b.Style).FirstOrDefault()
					|| c.Id == 1).Select(c => new DRItemView
					{
						Id = c.Id,
						NAME = c.NAME,
						ICON = c.ICON,
						Color = c.Color
					}).ToList();
				MWeapon = items.Where(c => c.Slot == 3
					&& c.LvlSet <= dbItems.DRItems.Where(a => a.Id == _clothes.MWeapon.Id).Select(a => a.LvlSet).FirstOrDefault()
					&& c.Style == dbItems.DRItems.Where(b => b.Id == _clothes.MWeapon.Id).Select(b => b.Style).FirstOrDefault()
					|| c.Id == 1).Select(c => new DRItemView
					{
						Id = c.Id,
						NAME = c.NAME,
						ICON = c.ICON,
						Color = c.Color
					}).ToList();
				AWeapon = items.Where(c => c.Slot == 4
					&& c.LvlSet <= dbItems.DRItems.Where(a => a.Id == _clothes.AWeapon.Id).Select(a => a.LvlSet).FirstOrDefault()
					&& c.Style == dbItems.DRItems.Where(b => b.Id == _clothes.AWeapon.Id).Select(b => b.Style).FirstOrDefault()
					|| c.Id == 1).Select(c => new DRItemView
					{
						Id = c.Id,
						NAME = c.NAME,
						ICON = c.ICON,
						Color = c.Color
					}).ToList();
				if (_clothes.Boots.Id != 1)
				{
					Boots = items.Where(c => c.Slot == 5
						&& c.LvlSet <= dbItems.DRItems.Where(a => a.Id == _clothes.Boots.Id).Select(a => a.LvlSet).FirstOrDefault()
						|| c.Id == 1).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).ToList();
				}
				else Boots = items.Where(c => c.Id ==1).Select(c => new DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					Color = c.Color
				}).ToList();
				Hauberk = items.Where(c => c.Slot == 6
					&& c.LvlSet <= dbItems.DRItems.Where(a => a.Id == _clothes.Hauberk.Id).Select(a => a.LvlSet).FirstOrDefault()
					&& c.Style == dbItems.DRItems.Where(b => b.Id == _clothes.Hauberk.Id).Select(b => b.Style).FirstOrDefault()
					|| c.Id == 1).Select(c => new DRItemView
					{
						Id = c.Id,
						NAME = c.NAME,
						ICON = c.ICON,
						Color = c.Color
					}).ToList();
				Shoulders = items.Where(c => c.Slot == 7
					&& c.LvlSet <= dbItems.DRItems.Where(a => a.Id == _clothes.Shoulders.Id).Select(a => a.LvlSet).FirstOrDefault()
					&& c.Style == dbItems.DRItems.Where(b => b.Id == _clothes.Shoulders.Id).Select(b => b.Style).FirstOrDefault()
					|| c.Id == 1).Select(c => new DRItemView
					{
						Id = c.Id,
						NAME = c.NAME,
						ICON = c.ICON,
						Color = c.Color
					}).ToList();
				Bangle = items.Where(c => c.Slot == 8
					&& c.LvlSet <= dbItems.DRItems.Where(a => a.Id == _clothes.Bangle.Id).Select(a => a.LvlSet).FirstOrDefault()
					&& c.Style == dbItems.DRItems.Where(b => b.Id == _clothes.Bangle.Id).Select(b => b.Style).FirstOrDefault()
					|| c.Id == 1).Select(c => new DRItemView
					{
						Id = c.Id,
						NAME = c.NAME,
						ICON = c.ICON,
						Color = c.Color
					}).ToList();
				Helmet = items.Where(c => c.Slot == 9
					&& c.LvlSet <= dbItems.DRItems.Where(a => a.Id == _clothes.Helmet.Id).Select(a => a.LvlSet).FirstOrDefault()
					&& c.Style == dbItems.DRItems.Where(b => b.Id == _clothes.Helmet.Id).Select(b => b.Style).FirstOrDefault()
					|| c.Id == 1).Select(c => new DRItemView
					{
						Id = c.Id,
						NAME = c.NAME,
						ICON = c.ICON,
						Color = c.Color
					}).ToList();
				Bow = items.Where(c => c.Slot == 10
					&& c.LvlSet <= dbItems.DRItems.Where(a => a.Id == _clothes.Bow.Id).Select(a => a.LvlSet).FirstOrDefault()
					&& c.Style == dbItems.DRItems.Where(b => b.Id == _clothes.Bow.Id).Select(b => b.Style).FirstOrDefault()
					|| c.Id == 1).Select(c => new DRItemView
					{
						Id = c.Id,
						NAME = c.NAME,
						ICON = c.ICON,
						Color = c.Color
					}).ToList();
			}
		}
		public void Frames(DRClothes _clothes, int _lvl, int _rank)
		{
			using (Model dbItems = new Model())
			{
				List<DRItems> items = dbItems.DRItems.Where(c => c.Lvl <= _lvl && c.Rank <= _rank && c.Type > 30 && c.Type <= 40).ToList();
				List<DRItemView> emptyList = items.Where(c => c.Id == 1).Select(c => new DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					Color = c.Color
				}).ToList();
				if (_clothes.Armor.Id != 1)
				{
					Armor = items.Where(c => c.Slot == 1 || c.Id == 1).Select(c => new DRItemView
					{
						Id = c.Id,
						NAME = c.NAME,
						ICON = c.ICON,
						Color = c.Color
					}).ToList();
				}
				else Armor = emptyList;
				if (_clothes.Pants.Id != 1)
				{
					Pants = items.Where(c => c.Slot == 2 || c.Id == 1).Select(c => new DRItemView
					{
						Id = c.Id,
						NAME = c.NAME,
						ICON = c.ICON,
						Color = c.Color
					}).ToList();
				}
				else Pants = emptyList;
				MWeapon = items.Where(c => c.Slot == 3
					&& c.LvlSet <= dbItems.DRItems.Where(a => a.Id == _clothes.MWeapon.Id).Select(a => a.LvlSet).FirstOrDefault()
					&& c.Style == dbItems.DRItems.Where(b => b.Id == _clothes.MWeapon.Id).Select(b => b.Style).FirstOrDefault()
					|| c.Id == 1).Select(c => new DRItemView
					{
						Id = c.Id,
						NAME = c.NAME,
						ICON = c.ICON,
						Color = c.Color
					}).ToList();
				AWeapon = emptyList;
				Boots = items.Where(c => c.Slot == 5
					&& c.LvlSet <= dbItems.DRItems.Where(a => a.Id == _clothes.Boots.Id).Select(a => a.LvlSet).FirstOrDefault()
					|| c.Id == 1).Select(c => new DRItemView
					{
						Id = c.Id,
						NAME = c.NAME,
						ICON = c.ICON,
						Color = c.Color
					}).ToList();
				if (_clothes.Hauberk.Id != 1)
				{
					Hauberk = items.Where(c => c.Slot == 6 || c.Id == 1).Select(c => new DRItemView
					{
						Id = c.Id,
						NAME = c.NAME,
						ICON = c.ICON,
						Color = c.Color
					}).ToList();
				}
				else Hauberk = emptyList;
				if (_clothes.Shoulders.Id != 1)
				{
					Shoulders = items.Where(c => c.Slot == 7 || c.Id == 1).Select(c => new DRItemView
					{
						Id = c.Id,
						NAME = c.NAME,
						ICON = c.ICON,
						Color = c.Color
					}).ToList();
				}
				else Shoulders = emptyList;
				if (_clothes.Bangle.Id != 1)
				{
					Bangle = items.Where(c => c.Slot == 8 || c.Id == 1).Select(c => new DRItemView
					{
						Id = c.Id,
						NAME = c.NAME,
						ICON = c.ICON,
						Color = c.Color
					}).ToList();
				}
				else Bangle = emptyList;
				if (_clothes.Helmet.Id != 1)
				{
					Helmet = items.Where(c => c.Slot == 9 || c.Id == 1).Select(c => new DRItemView
					{
						Id = c.Id,
						NAME = c.NAME,
						ICON = c.ICON,
						Color = c.Color
					}).ToList();
				}
				else Helmet = emptyList;
				if (_clothes.Bow.Id != 1)
				{
					Bow = items.Where(c => c.Slot == 10 || c.Id == 1).Select(c => new DRItemView
					{
						Id = c.Id,
						NAME = c.NAME,
						ICON = c.ICON,
						Color = c.Color
					}).ToList();
				}
				else Bow = emptyList;
			}
		}
	}
}