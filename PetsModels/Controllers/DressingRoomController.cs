using PetsModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetsModels.Controllers
{
	public class DressingRoomController : Controller
	{
		DressingRoom dbDR = new DressingRoom();
		DRPers pers = new DRPers();
		readonly int selectedIndex = 1;
		// GET: DessingRoom
		private void Create()
		{
			List<SelectListItem> lvls = new List<SelectListItem>();
			for (int i = 1; i <= 20; i++)
			{
				lvls.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
			}
			ViewBag.Lvl = lvls;

			SelectList ranks = new SelectList(dbDR.DRDobl.Where(c => c.Lvl <= selectedIndex), "Id", "Name");
			ViewBag.Rank = ranks;
		}

		public ViewResult Index()
		{
			Create();
			return View();
		}
		public ActionResult GetRank(int lvls)
		{
			return PartialView(dbDR.DRDobl.Where(r => r.Lvl <= lvls).ToList());
		}
		public ActionResult GetAW(int mWeapon)
		{
			pers = (DRPers)TempData.Peek("Pers");
			int mwW = (from DRItems in dbDR.DRItems
						where DRItems.Id == mWeapon
						select DRItems.Weight).SingleOrDefault();
			if ( mwW == 1)
			{
				return PartialView(dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 10 && c.Type <= 20 && c.Slot == 4 && c.Weight == 1 || c.Id == 1).ToList());
			}
			else
			{
				return PartialView(dbDR.DRItems.Where(c => c.Id == 1).ToList());
			}
		}
		public ActionResult Clothes(int lvl = 1, int rank = 1)
		{
			pers.Lvl = lvl;
			pers.Rank = rank;

			pers.TempClothes = new DRPers.CompareTemp
			{
				Armor = dbDR.DRItems.Where(c => c.Lvl <= lvl && c.Rank <= rank && c.Type > 10 && c.Type <= 20 && c.Slot == 1 || c.Id == 1).ToList(),
				Pants = dbDR.DRItems.Where(c => c.Lvl <= lvl && c.Rank <= rank && c.Type > 10 && c.Type <= 20 && c.Slot == 2 || c.Id == 1).ToList(),
				MWeapon = dbDR.DRItems.Where(c => c.Lvl <= lvl && c.Rank <= rank && c.Type > 10 && c.Type <= 20 && c.Slot == 3 || c.Id == 1).ToList(),
				AWeapon = dbDR.DRItems.Where(c => c.Id == 1).ToList(),
				Boots = dbDR.DRItems.Where(c => c.Lvl <= lvl && c.Rank <= rank && c.Type > 10 && c.Type <= 20 && c.Slot == 5 || c.Id == 1).ToList(),
				Hauberk = dbDR.DRItems.Where(c => c.Lvl <= lvl && c.Rank <= rank && c.Type > 10 && c.Type <= 20 && c.Slot == 6 || c.Id == 1).ToList(),
				Shoulders = dbDR.DRItems.Where(c => c.Lvl <= lvl && c.Rank <= rank && c.Type > 10 && c.Type <= 20 && c.Slot == 7 || c.Id == 1).ToList(),
				Bangle = dbDR.DRItems.Where(c => c.Lvl <= lvl && c.Rank <= rank && c.Type > 10 && c.Type <= 20 && c.Slot == 8 || c.Id == 1).ToList(),
				Helmet = dbDR.DRItems.Where(c => c.Lvl <= lvl && c.Rank <= rank && c.Type > 10 && c.Type <= 20 && c.Slot == 9 || c.Id == 1).ToList(),
				Bow = dbDR.DRItems.Where(c => c.Lvl <= lvl && c.Rank <= rank && c.Type > 10 && c.Type <= 20 && c.Slot == 10 || c.Id == 1).ToList()
			};
			Session["Pers"] = pers;
			return PartialView(pers);
		}
		
		public ActionResult Runes_Frames(int armor = 0, int pants = 0, int mWeapon = 0, int aWeapon = 0, int boots = 0, int hauberk = 0, int shoulders = 0, int bangle = 0, int helmet = 0, int bow = 0)
		{
			pers = (DRPers)Session["Pers"];

			pers.Clothes = new DRPers.DRClothes
			{
				Armor = new DRPers.DRItemView(),
				Pants = new DRPers.DRItemView(),
				MWeapon = new DRPers.DRItemView(),
				AWeapon = new DRPers.DRItemView(),
				Boots = new DRPers.DRItemView(),
				Hauberk = new DRPers.DRItemView(),
				Shoulders = new DRPers.DRItemView(),
				Bangle = new DRPers.DRItemView(),
				Helmet = new DRPers.DRItemView(),
				Bow = new DRPers.DRItemView()
			};

			//иконки доспехов
			{
				pers.Clothes.Armor = dbDR.DRItems.Where(c => c.Id == armor).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Clothes.Pants = dbDR.DRItems.Where(c => c.Id == pants).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Clothes.MWeapon = dbDR.DRItems.Where(c => c.Id == mWeapon).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Clothes.AWeapon = dbDR.DRItems.Where(c => c.Id == aWeapon).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Clothes.Boots = dbDR.DRItems.Where(c => c.Id == boots).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Clothes.Hauberk = dbDR.DRItems.Where(c => c.Id == hauberk).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Clothes.Shoulders = dbDR.DRItems.Where(c => c.Id == shoulders).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Clothes.Bangle = dbDR.DRItems.Where(c => c.Id == bangle).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Clothes.Helmet = dbDR.DRItems.Where(c => c.Id == helmet).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Clothes.Bow = dbDR.DRItems.Where(c => c.Id == bow).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
			}

			pers.TempRunes = new DRPers.CompareTemp
			{
				Armor = dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 20 && c.Type <= 30 && c.Slot == 1
					&& c.LvlSet <= dbDR.DRItems.Where(a => a.Id == armor).Select(a => a.LvlSet).FirstOrDefault()
					&& c.Style == dbDR.DRItems.Where(b => b.Id == armor).Select(b => b.Style).FirstOrDefault()
					|| c.Id == 1).ToList(),
				Pants = dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 20 && c.Type <= 30 && c.Slot == 2
					&& c.LvlSet <= dbDR.DRItems.Where(a => a.Id == pants).Select(a => a.LvlSet).FirstOrDefault()
					&& c.Style == dbDR.DRItems.Where(b => b.Id == pants).Select(b => b.Style).FirstOrDefault()
					|| c.Id == 1).ToList(),
				MWeapon = dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 20 && c.Type <= 30 && c.Slot == 3
					&& c.LvlSet <= dbDR.DRItems.Where(a => a.Id == mWeapon).Select(a => a.LvlSet).FirstOrDefault()
					&& c.Style == dbDR.DRItems.Where(b => b.Id == mWeapon).Select(b => b.Style).FirstOrDefault()
					|| c.Id == 1).ToList(),
				AWeapon = dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 20 && c.Type <= 30 && c.Slot == 4
					&& c.LvlSet <= dbDR.DRItems.Where(a => a.Id == aWeapon).Select(a => a.LvlSet).FirstOrDefault()
					&& c.Style == dbDR.DRItems.Where(b => b.Id == aWeapon).Select(b => b.Style).FirstOrDefault()
					|| c.Id == 1).ToList(),
				Boots = dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 20 && c.Type <= 30 && c.Slot == 5
					&& c.LvlSet <= dbDR.DRItems.Where(a => a.Id == boots).Select(a => a.LvlSet).FirstOrDefault()
					|| c.Id == 1).ToList(),
				Hauberk = dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 20 && c.Type <= 30 && c.Slot == 6
					&& c.LvlSet <= dbDR.DRItems.Where(a => a.Id == hauberk).Select(a => a.LvlSet).FirstOrDefault()
					&& c.Style == dbDR.DRItems.Where(b => b.Id == hauberk).Select(b => b.Style).FirstOrDefault()
					|| c.Id == 1).ToList(),
				Shoulders = dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 20 && c.Type <= 30 && c.Slot == 7
					&& c.LvlSet <= dbDR.DRItems.Where(a => a.Id == shoulders).Select(a => a.LvlSet).FirstOrDefault()
					&& c.Style == dbDR.DRItems.Where(b => b.Id == shoulders).Select(b => b.Style).FirstOrDefault()
					|| c.Id == 1).ToList(),
				Bangle = dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 20 && c.Type <= 30 && c.Slot == 8
					&& c.LvlSet <= dbDR.DRItems.Where(a => a.Id == bangle).Select(a => a.LvlSet).FirstOrDefault()
					&& c.Style == dbDR.DRItems.Where(b => b.Id == bangle).Select(b => b.Style).FirstOrDefault()
					|| c.Id == 1).ToList(),
				Helmet = dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 20 && c.Type <= 30 && c.Slot == 9
					&& c.LvlSet <= dbDR.DRItems.Where(a => a.Id == helmet).Select(a => a.LvlSet).FirstOrDefault()
					&& c.Style == dbDR.DRItems.Where(b => b.Id == helmet).Select(b => b.Style).FirstOrDefault()
					|| c.Id == 1).ToList(),
				Bow = dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 20 && c.Type <= 30 && c.Slot == 10
					&& c.LvlSet <= dbDR.DRItems.Where(a => a.Id == bow).Select(a => a.LvlSet).FirstOrDefault()
					&& c.Style == dbDR.DRItems.Where(b => b.Id == bow).Select(b => b.Style).FirstOrDefault()
					|| c.Id == 1).ToList()
			};

			pers.TempFrames = new DRPers.CompareTemp
			{
				Armor = dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 30 && c.Type <= 40 && c.Slot == 1 || c.Id == 1).ToList(),
				Pants = dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 30 && c.Type <= 40 && c.Slot == 2 || c.Id == 1).ToList(),
				MWeapon = dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 30 && c.Type <= 40 && c.Slot == 3
					&& c.LvlSet <= dbDR.DRItems.Where(a => a.Id == mWeapon).Select(a => a.LvlSet).FirstOrDefault()
					&& c.Style == dbDR.DRItems.Where(b => b.Id == mWeapon).Select(b => b.Style).FirstOrDefault()
					|| c.Id == 1).ToList(),
				AWeapon = dbDR.DRItems.Where(c => c.Id == 1).ToList(),
				Boots = dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 30 && c.Type <= 40 && c.Slot == 5
					&& c.LvlSet == dbDR.DRItems.Where(a => a.Id == boots).Select(a => a.LvlSet).FirstOrDefault()
					|| c.Id == 1).ToList(),
				Hauberk = dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 30 && c.Type <= 40 && c.Slot == 6
					|| c.Id == 1).ToList(),
				Shoulders = dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 30 && c.Type <= 40 && c.Slot == 7
					|| c.Id == 1).ToList(),
				Bangle = dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 30 && c.Type <= 40 && c.Slot == 8
					|| c.Id == 1).ToList(),
				Helmet = dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 30 && c.Type <= 40 && c.Slot == 9
					|| c.Id == 1).ToList(),
				Bow = dbDR.DRItems.Where(c => c.Id == 1).ToList()
			};
			Session["Pers"] = pers;
			return PartialView(pers);
		}

		public ActionResult ViewResult(
			int armorR = 0, int pantsR = 0, int mWeaponR = 0, int aWeaponR = 0, int bootsR = 0, int hauberkR = 0, int shouldersR = 0, int bangleR = 0, int helmetR = 0, int bowR = 0,
			int armorF = 0, int pantsF = 0, int mWeaponF = 0, int aWeaponF = 0, int bootsF = 0, int hauberkF = 0, int shouldersF = 0, int bangleF = 0, int helmetF = 0, int bowF = 0)
		{
			pers = (DRPers)Session["Pers"];

			pers.Runes = new DRPers.DRClothes
			{
				Armor = new DRPers.DRItemView(),
				Pants = new DRPers.DRItemView(),
				MWeapon = new DRPers.DRItemView(),
				AWeapon = new DRPers.DRItemView(),
				Boots = new DRPers.DRItemView(),
				Hauberk = new DRPers.DRItemView(),
				Shoulders = new DRPers.DRItemView(),
				Bangle = new DRPers.DRItemView(),
				Helmet = new DRPers.DRItemView(),
				Bow = new DRPers.DRItemView()
			};

			pers.Frames = new DRPers.DRClothes
			{
				Armor = new DRPers.DRItemView(),
				Pants = new DRPers.DRItemView(),
				MWeapon = new DRPers.DRItemView(),
				AWeapon = new DRPers.DRItemView(),
				Boots = new DRPers.DRItemView(),
				Hauberk = new DRPers.DRItemView(),
				Shoulders = new DRPers.DRItemView(),
				Bangle = new DRPers.DRItemView(),
				Helmet = new DRPers.DRItemView(),
				Bow = new DRPers.DRItemView()
			};

			//иконки на вьюхе
			{
				pers.Runes.Armor = dbDR.DRItems.Where(c => c.Id == armorR).Select(c => new DRPers.DRItemView
				{
					Id =c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Runes.Pants = dbDR.DRItems.Where(c => c.Id == pantsR).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Runes.MWeapon = dbDR.DRItems.Where(c => c.Id == mWeaponR).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Runes.AWeapon = dbDR.DRItems.Where(c => c.Id == aWeaponR).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Runes.Boots = dbDR.DRItems.Where(c => c.Id == bootsR).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Runes.Hauberk = dbDR.DRItems.Where(c => c.Id == hauberkR).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Runes.Shoulders = dbDR.DRItems.Where(c => c.Id == shouldersR).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Runes.Bangle = dbDR.DRItems.Where(c => c.Id == bangleR).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Runes.Helmet = dbDR.DRItems.Where(c => c.Id == helmetR).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Runes.Bow = dbDR.DRItems.Where(c => c.Id == bowR).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();

				pers.Frames.Armor = dbDR.DRItems.Where(c => c.Id == armorF).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Frames.Pants = dbDR.DRItems.Where(c => c.Id == pantsF).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Frames.MWeapon = dbDR.DRItems.Where(c => c.Id == mWeaponF).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Frames.AWeapon = dbDR.DRItems.Where(c => c.Id == aWeaponF).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Frames.Boots = dbDR.DRItems.Where(c => c.Id == bootsF).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Frames.Hauberk = dbDR.DRItems.Where(c => c.Id == hauberkF).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Frames.Shoulders = dbDR.DRItems.Where(c => c.Id == shouldersF).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Frames.Bangle = dbDR.DRItems.Where(c => c.Id == bangleF).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Frames.Helmet = dbDR.DRItems.Where(c => c.Id == helmetF).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
				pers.Frames.Bow = dbDR.DRItems.Where(c => c.Id == bowF).Select(c => new DRPers.DRItemView
				{
					Id = c.Id,
					NAME = c.NAME,
					ICON = c.ICON,
					LINK = c.LINK
				}).SingleOrDefault();
			}
			//бонус комплекта
			{
				var BL = new List<int>(dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id).Select(a => a.Suite));
				pers.BonusList = BL;
				IEnumerable<DRBonus> ListSuite;
				ListSuite = pers.BonusList.GroupBy(b => b).Select(c => new DRBonus
				{
					Suite = c.Key,
					Count = c.Count()
				});
				DRBonus Lb = ListSuite
					.OrderByDescending(d => d.Count)
					.Take(1)
					.FirstOrDefault();
				if (dbDR.DRItems.Where(i => i.Suite == Lb.Suite).Select(i => i.Style).Take(1).SingleOrDefault() == 2)
				{
					if (Lb.Count < 5)
					{
						pers.Clothes.Bonus = 1;
					}
					if (Lb.Count >= 5 && Lb.Count < 8)
					{
						pers.Clothes.Bonus = dbDR.DRItems.Where(a => a.Suite == Lb.Suite && a.Slot == 105).Select(a => a.Id).SingleOrDefault();
					}
					if (Lb.Count == 8)
					{
						pers.Clothes.Bonus = dbDR.DRItems.Where(a => a.Suite == Lb.Suite && a.Slot == 109).Select(a => a.Id).SingleOrDefault();
					}
				}
				else
				{
					if (Lb.Count < 5)
					{
						pers.Clothes.Bonus =1;
					}
					if (Lb.Count >= 5 && Lb.Count < 9)
					{
						pers.Clothes.Bonus = dbDR.DRItems.Where(a => a.Suite == Lb.Suite && a.Slot == 105).Select(a => a.Id).SingleOrDefault();
					}
					if (Lb.Count == 9)
					{
						pers.Clothes.Bonus = dbDR.DRItems.Where(a => a.Suite == Lb.Suite && a.Slot == 109).Select(a => a.Id).SingleOrDefault();
					}
				}
			}
			//Характеристики
			{
				pers.Stats = new DRPers.DRStats();
				var Agility = new List<int>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.Agility));
				pers.Stats.Agility = Agility.Sum();
				var Defense = new List<int>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id|| c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.Defense));
				pers.Stats.Defense = Defense.Sum();
				var Initiative = new List<int>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.Initiative));
				pers.Stats.Initiative = Initiative.Sum();
				var Intuition = new List<int>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.Intuition));
				pers.Stats.Intuition = Intuition.Sum();
				var Intelligence = new List<int>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id|| c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.Intelligence));
				pers.Stats.Intelligence = Intelligence.Sum();
				var Strength = new List<int>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.Strength));
				pers.Stats.Strength = Strength.Sum();
				var Vitality = new List<int>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id|| c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id|| c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.Vitality));
				pers.Stats.Vitality = Vitality.Sum();
				var Wisdom = new List<int>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.Wisdom));
				pers.Stats.Wisdom = Wisdom.Sum();
				var Health = new List<int>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.Health));
				pers.Stats.Health = Health.Sum();
				var Mana = new List<int>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.Mana));
				pers.Stats.Mana = Mana.Sum();
				var FAProt = new List<int>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.FAprot));
				pers.Stats.FAprot = FAProt.Sum();
				var LDProt = new List<int>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.LDprot));
				pers.Stats.LDprot = LDProt.Sum();
				var EWProt = new List<int>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.EWprot));
				pers.Stats.EWprot = EWProt.Sum();
				var MinMD = new List<double>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.MinMD));
				pers.Stats.MinMD = MinMD.Sum();
				var MaxMD = new List<double>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.MaxMD));
				pers.Stats.MaxMD = MaxMD.Sum();
				var MinPD = new List<double>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.MinPD));
				pers.Stats.MinPD = MinPD.Sum();
				var MaxPD = new List<double>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.MaxPD));
				pers.Stats.MaxPD = MaxPD.Sum();
				var Antitraumatism = new List<int>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.Antitraumatism));
				pers.Stats.Antitraumatism = Antitraumatism.Sum();
				var Traumatism = new List<int>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.Traumatism));
				pers.Stats.Traumatism = Traumatism.Sum();
				var Stamina = new List<int>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.Stamina));
				pers.Stats.Stamina = Stamina.Sum();
				var Insight = new List<int>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.Insight));
				pers.Stats.Insight = Insight.Sum();
				var Speed = new List<int>(
					dbDR.DRItems.Where(c => c.Id == pers.Clothes.Helmet.Id || c.Id == pers.Clothes.Bangle.Id || c.Id == pers.Clothes.Shoulders.Id || c.Id == pers.Clothes.Hauberk.Id
					|| c.Id == pers.Clothes.Boots.Id || c.Id == pers.Clothes.AWeapon.Id || c.Id == pers.Clothes.MWeapon.Id || c.Id == pers.Clothes.Pants.Id || c.Id == pers.Clothes.Armor.Id
					|| c.Id == pers.Clothes.Bow.Id
					|| c.Id == pers.Runes.Helmet.Id || c.Id == pers.Runes.Bangle.Id || c.Id == pers.Runes.Shoulders.Id || c.Id == pers.Runes.Hauberk.Id
					|| c.Id == pers.Runes.Boots.Id || c.Id == pers.Runes.AWeapon.Id || c.Id == pers.Runes.MWeapon.Id || c.Id == pers.Runes.Pants.Id || c.Id == pers.Runes.Armor.Id
					|| c.Id == pers.Runes.Bow.Id
					|| c.Id == pers.Frames.Helmet.Id || c.Id == pers.Frames.Bangle.Id || c.Id == pers.Frames.Shoulders.Id || c.Id == pers.Frames.Hauberk.Id
					|| c.Id == pers.Frames.Boots.Id || c.Id == pers.Frames.AWeapon.Id || c.Id == pers.Frames.MWeapon.Id || c.Id == pers.Frames.Pants.Id || c.Id == pers.Frames.Armor.Id
					|| c.Id == pers.Frames.Bow.Id
					|| c.Id == pers.Clothes.Bonus).Select(a => a.Speed));
				pers.Stats.Speed = Speed.Sum();
			}
			return PartialView(pers);
		}
	}
}