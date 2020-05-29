using System.Collections.Generic;
using System.Linq;

namespace DressingRoom
{
	public class DRClothes
	{
		internal int armor { get; private set; }
		internal int pants { get; private set; }
		internal int mWeapon { get; private set; }
		internal int aWeapon { get; private set; }
		internal int boots { get; private set; }
		internal int hauberk { get; private set; }
		internal int shoulders { get; private set; }
		internal int bangle { get; private set; }
		internal int helmet { get; private set; }
		internal int bow { get; private set; }
		internal int bonus { get; private set; }

		public DRItemView Armor
		{
			get
			{
				using (Model dbItems = new Model())
				{
					DRItemView rez = new DRItemView();
					try
					{
						rez = dbItems.DRItems.Where(c => c.Id == armor && c.Slot == 1).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).Single();
					}
					catch (System.InvalidOperationException)
					{
						rez = dbItems.DRItems.Where(c => c.Id == 1).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).Single();
					}
					return rez;
				}
			}
		}
		public DRItemView Pants
		{
			get
			{
				using (Model dbItems = new Model())
				{
					DRItemView rez = new DRItemView();
					try
					{
						rez = dbItems.DRItems.Where(c => c.Id == pants && c.Slot == 2).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).Single();
					}
					catch (System.InvalidOperationException)
					{
						rez = dbItems.DRItems.Where(c => c.Id == 1).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).Single();
					}
					return rez;
				}
			}
		}
		public DRItemView MWeapon
		{
			get
			{
				using (Model dbItems = new Model())
				{
					DRItemView rez = new DRItemView();
					try
					{
						rez = dbItems.DRItems.Where(c => c.Id == mWeapon && c.Slot == 3).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).Single();
					}
					catch (System.InvalidOperationException)
					{
						rez = dbItems.DRItems.Where(c => c.Id == 1).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).Single();
					}
					return rez;
				}
			}
		}
		public DRItemView AWeapon
		{
			get
			{
				using (Model dbItems = new Model())
				{
					DRItemView rez = new DRItemView();
					try
					{
						rez = dbItems.DRItems.Where(c => c.Id == aWeapon && c.Slot == 4).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).Single();
					}
					catch (System.InvalidOperationException)
					{
						rez = dbItems.DRItems.Where(c => c.Id == 1).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).Single();
					}
					return rez;
				}
			}
		}
		public DRItemView Boots
		{
			get
			{
				using (Model dbItems = new Model())
				{
					DRItemView rez = new DRItemView();
					try
					{
						rez = dbItems.DRItems.Where(c => c.Id == boots && c.Slot == 5).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).Single();
					}
					catch (System.InvalidOperationException)
					{
						rez = dbItems.DRItems.Where(c => c.Id == 1).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).Single();
					}
					return rez;
				}
			}
		}
		public DRItemView Hauberk
		{
			get
			{
				using (Model dbItems = new Model())
				{
					DRItemView rez = new DRItemView();
					try
					{
						rez = dbItems.DRItems.Where(c => c.Id == hauberk && c.Slot == 6).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).Single();
					}
					catch (System.InvalidOperationException)
					{
						rez = dbItems.DRItems.Where(c => c.Id == 1).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).Single();
					}
					return rez;
				}
			}
		}
		public DRItemView Shoulders
		{
			get
			{
				using (Model dbItems = new Model())
				{
					DRItemView rez = new DRItemView();
					try
					{
						rez = dbItems.DRItems.Where(c => c.Id == shoulders && c.Slot == 7).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).Single();
					}
					catch (System.InvalidOperationException)
					{
						rez = dbItems.DRItems.Where(c => c.Id == 1).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).Single();
					}
					return rez;
				}
			}
		}
		public DRItemView Bangle
		{
			get
			{
				using (Model dbItems = new Model())
				{
					DRItemView rez = new DRItemView();
					try
					{
						rez = dbItems.DRItems.Where(c => c.Id == bangle && c.Slot == 8).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).Single();
					}
					catch (System.InvalidOperationException)
					{
						rez = dbItems.DRItems.Where(c => c.Id == 1).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).Single();
					}
					return rez;
				}
			}
		}
		public DRItemView Helmet
		{
			get
			{
				using (Model dbItems = new Model())
				{
					DRItemView rez = new DRItemView();
					try
					{
						rez = dbItems.DRItems.Where(c => c.Id == helmet && c.Slot == 9).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).Single();
					}
					catch (System.InvalidOperationException)
					{
						rez = dbItems.DRItems.Where(c => c.Id == 1).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).Single();
					}
					return rez;
				}
			}
		}
		public DRItemView Bow
		{
			get
			{
				using (Model dbItems = new Model())
				{
					DRItemView rez = new DRItemView();
					try
					{
						rez = dbItems.DRItems.Where(c => c.Id == bow && c.Slot == 10).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).Single();
					}
					catch (System.InvalidOperationException)
					{
						rez = dbItems.DRItems.Where(c => c.Id == 1).Select(c => new DRItemView
						{
							Id = c.Id,
							NAME = c.NAME,
							ICON = c.ICON,
							Color = c.Color
						}).Single();
					}
					return rez;
				}
			}
		}
		private void SetBonus()
		{
			using (Model dbItems = new Model())
			{
				List<int> BL = new List<int>(dbItems.DRItems.Where(c => c.Id == helmet || c.Id == bangle || c.Id == shoulders || c.Id == hauberk
					   || c.Id == boots || c.Id == aWeapon || c.Id == mWeapon || c.Id == pants || c.Id == armor
					   || c.Id == bow).Select(a => a.Suite));
				IEnumerable<DRBonus> ListSuite = BL.GroupBy(b => b).Select(c => new DRBonus
				{
					Suite = c.Key,
					Count = c.Count()
				});
				DRBonus Lb = ListSuite
					.OrderByDescending(d => d.Count)
					.Take(1)
					.FirstOrDefault();
				if (dbItems.DRItems.Where(i => i.Suite == Lb.Suite).Select(i => i.Style).Take(1).SingleOrDefault() == 2)
				{
					if (Lb.Count < 5)
					{
						bonus = 1;
					}
					if (Lb.Count >= 5 && Lb.Count < 8)
					{
						bonus = dbItems.DRItems.Where(a => a.Suite == Lb.Suite && a.Slot == 105).Select(a => a.Id).SingleOrDefault();
					}
					if (Lb.Count == 8)
					{
						bonus = dbItems.DRItems.Where(a => a.Suite == Lb.Suite && a.Slot == 109).Select(a => a.Id).SingleOrDefault();
					}
				}
				else
				{
					if (Lb.Count < 5)
					{
						bonus = 1;
					}
					if (Lb.Count >= 5 && Lb.Count < 9)
					{
						bonus = dbItems.DRItems.Where(a => a.Suite == Lb.Suite && a.Slot == 105).Select(a => a.Id).SingleOrDefault();
					}
					if (Lb.Count == 9)
					{
						bonus = dbItems.DRItems.Where(a => a.Suite == Lb.Suite && a.Slot == 109).Select(a => a.Id).SingleOrDefault();
					}
				}
			}
		}
		public DRClothes()
		{
		}
		public DRClothes(params int[] items)
		{
			armor = items[0];
			pants = items[1];
			mWeapon = items[2];
			aWeapon = items[3];
			boots = items[4];
			hauberk = items[5];
			shoulders = items[6];
			bangle = items[7];
			helmet = items[8];
			bow = items[9];
			SetBonus();
		}
		public void RFSet(params int[] items)
		{
			armor = items[0];
			pants = items[1];
			mWeapon = items[2];
			aWeapon = items[3];
			boots = items[4];
			hauberk = items[5];
			shoulders = items[6];
			bangle = items[7];
			helmet = items[8];
			bow = items[9];
		}
	}
}

