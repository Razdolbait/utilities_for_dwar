using Pets;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PetsModels
{
	public class PetsController : Controller
    {
        private void Create()
        {
			List<SelectListItem> colors = new List<SelectListItem>
			{
				new SelectListItem { Text = "серый", Value = "1" },
				new SelectListItem { Text = "зеленый", Value = "2" },
				new SelectListItem { Text = "синий", Value = "3" },
				new SelectListItem { Text = "фиолетовый", Value = "4" },
				new SelectListItem { Text = "красный", Value = "5" }
			};
			ViewBag.Colors = colors;

            List<SelectListItem> lvls = new List<SelectListItem>();
            for (int i = 1; i <= 20; i++)
                {
                    lvls.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
                }
            ViewBag.Lvls = lvls;

			List<SelectListItem> sorts = new List<SelectListItem>
			{
				new SelectListItem { Text = "имени", Value = "1" },
				new SelectListItem { Text = "поиску травы", Value = "2" },
				new SelectListItem { Text = "поиску камней", Value = "3" },
				new SelectListItem { Text = "поиску рыбы", Value = "4" },
				new SelectListItem { Text = "поиску снаряжения", Value = "5" },
				new SelectListItem { Text = "поиску талисманов", Value = "6" },
				new SelectListItem { Text = "поиску ценностей", Value = "7" }
			};
			ViewBag.Sort = sorts;
        }
        public ViewResult Index(int sort=1, int lvl=1, int color=1)
        {
            if (lvl > 0 && lvl <= 20 && color > 0 && color <= 5)
            {
                Create();
				var pets = new PetsReitList().GetPetsReitList(lvl, color);
				switch (sort)
				{
					case 2:
						pets = pets.OrderByDescending(s => s.Grass).ToList();
						break;
					case 3:
						pets = pets.OrderByDescending(s => s.Stone).ToList();
						break;
					case 4:
						pets = pets.OrderByDescending(s => s.Fish).ToList();
						break;
					case 5:
						pets = pets.OrderByDescending(s => s.ESearch).ToList();
						break;
					case 6:
						pets = pets.OrderByDescending(s => s.TSearch).ToList();
						break;
					case 7:
						pets = pets.OrderByDescending(s => s.WSearch).ToList();
						break;
					default:
						pets = pets.OrderBy(s => s.Name).ToList();
						break;
				}
				return View(pets.ToList());
			}
            return View();
        }
    }
}