using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DressingRoom;

namespace PetsModels.Controllers
{
	public class DressingRoomController : Controller
	{
		
		// GET: DessingRoom
		private void Create()
		{
			DRPers pers = new DRPers();
			int selectedIndex = 1;
			List<SelectListItem> lvls = new List<SelectListItem>();
			for (int i = 1; i <= 20; i++)
			{
				lvls.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
			}
			ViewBag.Lvl = lvls;
			SelectList ranks = new SelectList(pers.GetRank(selectedIndex), "Id", "Name");
			Session["Pers"] = pers;
			ViewBag.Rank = ranks;
		}

		public ViewResult Index()
		{
			Create();
			return View();
		}
		public ActionResult GetRank(int lvls)
		{
			DRPers pers = (DRPers)Session["Pers"];
			return PartialView(pers.GetRank(lvls).ToList());
		}
		public ActionResult GetAW(int mWeapon)
		{
			DRPers pers = (DRPers)Session["Pers"];
			List<DRItemView> rez = pers.GetAW(mWeapon);
			return PartialView(rez);
		}
		public ActionResult Clothes(int lvl = 1, int rank = 1)
		{
			DRPers pers = (DRPers)Session["Pers"];
			pers.PersInitial(lvl, rank);
			Session["Pers"] = pers;
			return PartialView(pers);
		}
		
		public ActionResult Runes_Frames(int armor = 0, int pants = 0, int mWeapon = 0, int aWeapon = 0, int boots = 0, int hauberk = 0, int shoulders = 0, int bangle = 0, int helmet = 0, int bow = 0)
		{
			DRPers pers = (DRPers)Session["Pers"];
			pers.ClothesSet(armor, pants, mWeapon, aWeapon, boots, hauberk, shoulders, bangle, helmet, bow);
			Session["Pers"] = pers;
			return PartialView(pers);
		}

		public ActionResult ViewResult(
			int Rarmor = 0, int Rpants = 0, int RmWeapon = 0, int RaWeapon = 0, int Rboots = 0,
			int Rhauberk = 0, int Rshoulders = 0, int Rbangle = 0, int Rhelmet = 0, int Rbow = 0,
			int Farmor = 0, int Fpants = 0, int FmWeapon = 0, int FaWeapon = 0, int Fboots = 0,
			int Fhauberk = 0, int Fshoulders = 0, int Fbangle = 0, int Fhelmet = 0, int Fbow = 0)
		{
			DRPers pers = (DRPers)Session["Pers"];
			pers.RFSet(Rarmor, Rpants, RmWeapon, RaWeapon, Rboots, Rhauberk, Rshoulders, Rbangle, Rhelmet, Rbow,
				 Farmor, Fpants, FmWeapon, FaWeapon, Fboots, Fhauberk, Fshoulders, Fbangle, Fhelmet, Fbow);
			return PartialView(pers);
		}
	}
}