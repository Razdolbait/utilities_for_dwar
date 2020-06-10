using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetsModels.Models;

namespace PetsModels.Controllers
{
    public class compareController : Controller
    {
		// GET: compare
		DressingRoomOld dbDR = new DressingRoomOld();
		int selectedIndex = 1;
		ComparePerksView pers = new ComparePerksView();
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
		public ActionResult Index()
        {
			Create();
			return View();
		}
		public ActionResult GetRank(int lvls)
		{
			return PartialView(dbDR.DRDobl.Where(r => r.Lvl <= lvls).ToList());
		}
		public ActionResult GetAW1(int mWeapon)
		{
			pers = (ComparePerksView)TempData.Peek("Pers");
			CompareTempClothes TC = new CompareTempClothes();
			int mwW = (from DRItems in dbDR.DRItems
						where DRItems.Id == mWeapon
					   select DRItems.Weight).SingleOrDefault();
			if (mwW == 1)
			{
				TC.AWeapon = dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 10 && c.Type <= 20 && c.Slot == 4 && c.Weight == 1 || c.Id == 1).ToList();
			}
			else
			{
				TC.AWeapon = dbDR.DRItems.Where(c =>c.Id == 1).ToList();
			}
			return PartialView(TC.AWeapon);
		}
		public ActionResult GetAW2(int mWeapon)
		{
			pers = (ComparePerksView)TempData.Peek("Pers");
			CompareTempClothes TC = new CompareTempClothes();
			int mwW = (from DRItems in dbDR.DRItems
					   where DRItems.Id == mWeapon
					   select DRItems.Weight).SingleOrDefault();
			if (mwW == 1)
			{
				TC.AWeapon = dbDR.DRItems.Where(c => c.Lvl <= pers.Lvl && c.Rank <= pers.Rank && c.Type > 10 && c.Type <= 20 && c.Slot == 4 && c.Weight == 1 || c.Id == 1).ToList();
			}
			else
			{
				TC.AWeapon = dbDR.DRItems.Where(c => c.Id == 1).ToList();
			}
			return PartialView(TC.AWeapon);
		}
		public ActionResult compareClothes(int lvl = 1, int rank = 1)
		{
			pers.Lvl = lvl;
			pers.Rank = rank;
			TempData["Pers"] = pers;
			CompareTempClothes TC = new CompareTempClothes();
			TC.Armor = dbDR.DRItems.Where(c => c.Lvl <= lvl && c.Rank <= rank && c.Type > 10 && c.Type <= 20 && c.Slot == 1 || c.Id == 1).ToList();
			TC.Pants = dbDR.DRItems.Where(c => c.Lvl <= lvl && c.Rank <= rank && c.Type > 10 && c.Type <= 20 && c.Slot == 2 || c.Id == 1).ToList();
			TC.MWeapon = dbDR.DRItems.Where(c => c.Lvl <= lvl && c.Rank <= rank && c.Type > 10 && c.Type <= 20 && c.Slot == 3 || c.Id == 1).ToList();
			TC.AWeapon = dbDR.DRItems.Where(c => c.Id == 1).ToList();
			TC.Boots = dbDR.DRItems.Where(c => c.Lvl <= lvl && c.Rank <= rank && c.Type > 10 && c.Type <= 20 && c.Slot == 5 || c.Id == 1).ToList();
			TC.Hauberk = dbDR.DRItems.Where(c => c.Lvl <= lvl && c.Rank <= rank && c.Type > 10 && c.Type <= 20 && c.Slot == 6 || c.Id == 1).ToList();
			TC.Shoulders = dbDR.DRItems.Where(c => c.Lvl <= lvl && c.Rank <= rank && c.Type > 10 && c.Type <= 20 && c.Slot == 7 || c.Id == 1).ToList();
			TC.Bangle = dbDR.DRItems.Where(c => c.Lvl <= lvl && c.Rank <= rank && c.Type > 10 && c.Type <= 20 && c.Slot == 8 || c.Id == 1).ToList();
			TC.Helmet = dbDR.DRItems.Where(c => c.Lvl <= lvl && c.Rank <= rank && c.Type > 10 && c.Type <= 20 && c.Slot == 9 || c.Id == 1).ToList();
			TC.Bow = dbDR.DRItems.Where(c => c.Lvl <= lvl && c.Rank <= rank && c.Type > 10 && c.Type <= 20 && c.Slot == 10 || c.Id == 1).ToList();
			return PartialView(TC);
		}
		public ActionResult compare(int helmet1 = 1, int bangle1 = 1, int shoulders1 = 1, int hauberk1 = 1, int boots1 = 1, int aweapon1 = 1, int mweapon1 = 1, int pants1 = 1, 
			int armor1 = 1, int bow1 = 1,
			int helmet2 = 1, int bangle2 = 1, int shoulders2 = 1, int hauberk2 = 1, int boots2 = 1, int aweapon2 = 1, int mweapon2= 1, int pants2 = 1,
			int armor2 = 1, int bow2 = 1)
		{
			pers = (ComparePerksView)TempData.Peek("Pers");
			//Обсчет первого набора
			{
				pers.Perks1 = new ComparePerksView.CPerks();
				var BL1 = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.Suite));
				pers.BonusList1 = BL1;
				IEnumerable<DRBonus> ListSuite1;
				ListSuite1 = pers.BonusList1.GroupBy(b => b).Select(c => new DRBonus
				{
					Suite = c.Key,
					Count = c.Count()
				});
				DRBonus Lb1 = ListSuite1
					.OrderByDescending(d => d.Count)
					.Take(1)
					.FirstOrDefault();
				if (dbDR.DRItems.Where(i => i.Suite == Lb1.Suite).Select(i => i.Style).Take(1).SingleOrDefault() == 2)
				{
					if (Lb1.Count < 5)
					{
						pers.Bonus1 = dbDR.DRItems.Where(a => a.Id == 1).SingleOrDefault();
					}
					if (Lb1.Count >= 5 && Lb1.Count < 8)
					{
						pers.Bonus1 = dbDR.DRItems.Where(a => a.Suite == Lb1.Suite && a.Slot == 105).SingleOrDefault();
					}
					if (Lb1.Count == 8)
					{
						pers.Bonus1 = dbDR.DRItems.Where(a => a.Suite == Lb1.Suite && a.Slot == 109).SingleOrDefault();
					}
				}
				else
				{
					if (Lb1.Count < 5)
					{
						pers.Bonus1 = dbDR.DRItems.Where(a => a.Id == 1).SingleOrDefault();
					}
					if (Lb1.Count >= 5 && Lb1.Count < 9)
					{
						pers.Bonus1 = dbDR.DRItems.Where(a => a.Suite == Lb1.Suite && a.Slot == 105).SingleOrDefault();
					}
					if (Lb1.Count == 9)
					{
						pers.Bonus1 = dbDR.DRItems.Where(a => a.Suite == Lb1.Suite && a.Slot == 109).SingleOrDefault();
					}
				}
				var Agility = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.Agility));
				pers.Perks1.Agility = Agility.Sum() + pers.Bonus1.Agility;
				var Defense = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.Defense));
				pers.Perks1.Defense = Defense.Sum() + pers.Bonus1.Defense;
				var Initiative = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.Initiative));
				pers.Perks1.Initiative = Initiative.Sum() + pers.Bonus1.Initiative;
				var Intuition = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.Intuition));
				pers.Perks1.Intuition = Intuition.Sum() + pers.Bonus1.Intuition;
				var Intelligence = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.Intelligence));
				pers.Perks1.Intelligence = Intelligence.Sum() + pers.Bonus1.Intelligence;
				var Strength = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.Strength));
				pers.Perks1.Strength = Strength.Sum() + pers.Bonus1.Strength;
				var Vitality = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.Vitality));
				pers.Perks1.Vitality = Vitality.Sum() + pers.Bonus1.Vitality;
				var Wisdom = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.Wisdom));
				pers.Perks1.Wisdom = Wisdom.Sum() + pers.Bonus1.Wisdom;
				var Health = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.Health));
				pers.Perks1.Health = Health.Sum() + pers.Bonus1.Health;
				var Mana = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.Mana));
				pers.Perks1.Mana = Mana.Sum() + pers.Bonus1.Mana;
				var FAProt = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.FAprot));
				pers.Perks1.FAprot = FAProt.Sum() + pers.Bonus1.FAprot;
				var LDProt = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.LDprot));
				pers.Perks1.LDprot = LDProt.Sum() + pers.Bonus1.LDprot;
				var EWProt = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.EWprot));
				pers.Perks1.EWprot = EWProt.Sum() + pers.Bonus1.EWprot;
				var MinMD = new List<double>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.MinMD));
				pers.Perks1.MinMD = MinMD.Sum() + pers.Bonus1.MinMD;
				var MaxMD = new List<double>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.MaxMD));
				pers.Perks1.MaxMD = MaxMD.Sum() + pers.Bonus1.MaxMD;
				var MinPD = new List<double>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.MinPD));
				pers.Perks1.MinPD = MinPD.Sum() + pers.Bonus1.MinPD;
				var MaxPD = new List<double>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.MaxPD));
				pers.Perks1.MaxPD = MaxPD.Sum() + pers.Bonus1.MaxPD;
				var Antitraumatism = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.Antitraumatism));
				pers.Perks1.Antitraumatism = Antitraumatism.Sum() + pers.Bonus1.Antitraumatism;
				var Traumatism = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.Traumatism));
				pers.Perks1.Traumatism = Traumatism.Sum() + pers.Bonus1.Traumatism;
				var Stamina = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.Stamina));
				pers.Perks1.Stamina = Stamina.Sum() + pers.Bonus1.Stamina;
				var Insight = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.Insight));
				pers.Perks1.Insight = Insight.Sum() + pers.Bonus1.Insight;
				var Speed = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet1 || c.Id == bangle1 || c.Id == shoulders1 || c.Id == hauberk1 || c.Id == boots1 || c.Id == aweapon1 ||
							 c.Id == mweapon1 || c.Id == pants1 || c.Id == armor1 || c.Id == bow1).Select(a => a.Speed));
				pers.Perks1.Speed = Speed.Sum() + pers.Bonus1.Speed;
			}
			//Обсчет второго набора
			{
				pers.Perks2 = new ComparePerksView.CPerks();
				var BL2 = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.Suite));
				pers.BonusList2 = BL2;
				IEnumerable<DRBonus> ListSuite2;
				ListSuite2 = pers.BonusList2.GroupBy(b => b).Select(c => new DRBonus
				{
					Suite = c.Key,
					Count = c.Count()
				});
				DRBonus Lb2 = ListSuite2
					.OrderByDescending(d => d.Count)
					.Take(1)
					.FirstOrDefault();
				if (dbDR.DRItems.Where(i => i.Suite == Lb2.Suite).Select(i => i.Style).Take(1).SingleOrDefault() == 2)
				{
					if (Lb2.Count < 5)
					{
						pers.Bonus2 = dbDR.DRItems.Where(a => a.Id == 1).SingleOrDefault();
					}
					if (Lb2.Count >= 5 && Lb2.Count < 8)
					{
						pers.Bonus2 = dbDR.DRItems.Where(a => a.Suite == Lb2.Suite && a.Slot == 105).SingleOrDefault();
					}
					if (Lb2.Count == 8)
					{
						pers.Bonus2 = dbDR.DRItems.Where(a => a.Suite == Lb2.Suite && a.Slot == 109).SingleOrDefault();
					}
				}
				else
				{
					if (Lb2.Count < 5)
					{
						pers.Bonus2 = dbDR.DRItems.Where(a => a.Id == 1).SingleOrDefault();
					}
					if (Lb2.Count >= 5 && Lb2.Count < 9)
					{
						pers.Bonus2 = dbDR.DRItems.Where(a => a.Suite == Lb2.Suite && a.Slot == 105).SingleOrDefault();
					}
					if (Lb2.Count == 9)
					{
						pers.Bonus2 = dbDR.DRItems.Where(a => a.Suite == Lb2.Suite && a.Slot == 109).SingleOrDefault();
					}
				}
				var Agility2 = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.Agility));
				pers.Perks2.Agility = Agility2.Sum() + pers.Bonus2.Agility;
				var Defense2 = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.Defense));
				pers.Perks2.Defense = Defense2.Sum() + pers.Bonus2.Defense;
				var Initiative2 = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.Initiative));
				pers.Perks2.Initiative = Initiative2.Sum() + pers.Bonus2.Initiative;
				var Intuition2 = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.Intuition));
				pers.Perks2.Intuition = Intuition2.Sum() + pers.Bonus2.Intuition;
				var Intelligence2 = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.Intelligence));
				pers.Perks2.Intelligence = Intelligence2.Sum() + pers.Bonus2.Intelligence;
				var Strength2 = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.Strength));
				pers.Perks2.Strength = Strength2.Sum() + pers.Bonus2.Strength;
				var Vitality2 = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.Vitality));
				pers.Perks2.Vitality = Vitality2.Sum() + pers.Bonus2.Vitality;
				var Wisdom2 = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.Wisdom));
				pers.Perks2.Wisdom = Wisdom2.Sum() + pers.Bonus2.Wisdom;
				var Health2 = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.Health));
				pers.Perks2.Health = Health2.Sum() + pers.Bonus2.Health;
				var Mana2 = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.Mana));
				pers.Perks2.Mana = Mana2.Sum() + pers.Bonus2.Mana;
				var FAProt2 = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.FAprot));
				pers.Perks2.FAprot = FAProt2.Sum() + pers.Bonus2.FAprot;
				var LDProt2 = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.LDprot));
				pers.Perks2.LDprot = LDProt2.Sum() + pers.Bonus2.LDprot;
				var EWProt2 = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.EWprot));
				pers.Perks2.EWprot = EWProt2.Sum() + pers.Bonus2.EWprot;
				var MinMD2 = new List<double>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.MinMD));
				pers.Perks2.MinMD = MinMD2.Sum() + pers.Bonus2.MinMD;
				var MaxMD2 = new List<double>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.MaxMD));
				pers.Perks2.MaxMD = MaxMD2.Sum() + pers.Bonus2.MaxMD;
				var MinPD2 = new List<double>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.MinPD));
				pers.Perks2.MinPD = MinPD2.Sum() + pers.Bonus2.MinPD;
				var MaxPD2 = new List<double>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.MaxPD));
				pers.Perks2.MaxPD = MaxPD2.Sum() + pers.Bonus2.MaxPD;
				var Antitraumatism2 = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.Antitraumatism));
				pers.Perks2.Antitraumatism = Antitraumatism2.Sum() + pers.Bonus2.Antitraumatism;
				var Traumatism2 = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.Traumatism));
				pers.Perks2.Traumatism = Traumatism2.Sum() + pers.Bonus2.Traumatism;
				var Stamina2 = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.Stamina));
				pers.Perks2.Stamina = Stamina2.Sum() + pers.Bonus2.Stamina;
				var Insight2 = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.Insight));
				pers.Perks2.Insight = Insight2.Sum() + pers.Bonus2.Insight;
				var Speed2 = new List<int>(dbDR.DRItems.Where(c => c.Id == helmet2 || c.Id == bangle2 || c.Id == shoulders2 || c.Id == hauberk2 || c.Id == boots2 || c.Id == aweapon2 ||
							 c.Id == mweapon2 || c.Id == pants2 || c.Id == armor2 || c.Id == bow2).Select(a => a.Speed));
				pers.Perks2.Speed = Speed2.Sum() + pers.Bonus2.Speed;
			}
			//разница
			{
				pers.PerksRazn = new ComparePerksView.CPerks();
				pers.PerksRazn.Agility = pers.Perks1.Agility - pers.Perks2.Agility;
				pers.PerksRazn.Defense = pers.Perks1.Defense - pers.Perks2.Defense;
				pers.PerksRazn.Initiative = pers.Perks1.Initiative - pers.Perks2.Initiative;
				pers.PerksRazn.Intuition = pers.Perks1.Intuition - pers.Perks2.Intuition;
				pers.PerksRazn.Intelligence = pers.Perks1.Intelligence - pers.Perks2.Intelligence;
				pers.PerksRazn.Strength = pers.Perks1.Strength - pers.Perks2.Strength;
				pers.PerksRazn.Vitality = pers.Perks1.Vitality - pers.Perks2.Vitality;
				pers.PerksRazn.Wisdom = pers.Perks1.Wisdom - pers.Perks2.Wisdom;
				pers.PerksRazn.Health = pers.Perks1.Health - pers.Perks2.Health;
				pers.PerksRazn.Mana = pers.Perks1.Mana - pers.Perks2.Mana;
				pers.PerksRazn.FAprot = pers.Perks1.FAprot - pers.Perks2.FAprot;
				pers.PerksRazn.LDprot = pers.Perks1.LDprot - pers.Perks2.LDprot;
				pers.PerksRazn.EWprot = pers.Perks1.EWprot - pers.Perks2.EWprot;
				pers.PerksRazn.MinMD = Math.Round(pers.Perks1.MinMD - pers.Perks2.MinMD, 1);
				pers.PerksRazn.MaxMD = Math.Round(pers.Perks1.MaxMD - pers.Perks2.MaxMD, 1);
				pers.PerksRazn.MinPD = Math.Round(pers.Perks1.MinPD - pers.Perks2.MinPD, 1);
				pers.PerksRazn.MaxPD = Math.Round(pers.Perks1.MaxPD - pers.Perks2.MaxPD, 1);
				pers.PerksRazn.Antitraumatism = pers.Perks1.Antitraumatism - pers.Perks2.Antitraumatism;
				pers.PerksRazn.Traumatism = pers.Perks1.Traumatism - pers.Perks2.Traumatism;
				pers.PerksRazn.Stamina = pers.Perks1.Stamina - pers.Perks2.Stamina;
				pers.PerksRazn.Insight = pers.Perks1.Insight - pers.Perks2.Insight;
				pers.PerksRazn.Speed = pers.Perks1.Speed - pers.Perks2.Speed;
			}
			TempData["Pers"] = pers;
			return PartialView(pers);
		}
	}
}