using Anagramma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PetsModels
{
	public class AnagrammaController : Controller
    {
		Dict word = new Dict();
		private void Create()
		{
			List<SelectListItem> cat = new List<SelectListItem>();
			foreach (var i in word.GetCategory())
			{
				cat.Add(new SelectListItem { Text = i.Value, Value = i.Key.ToString() });
			}
			ViewBag.Cat = cat;
		}
		public ActionResult Index(string SearchString="", int mode = 1, int category=0)
        {
			Create();
			var dict = word.Initialize();
			if (!String.IsNullOrEmpty(SearchString))
			{
				SearchString = SearchString.ToUpper();
				switch (mode)
				{
					case 2:
						SearchString = SearchString.Replace("*", ".");
						dict = word.Mask(SearchString, category);
						break;
					case 3:
						dict = word.Generator(SearchString, category);
						break;
					default:
						dict = word.Anagramma(SearchString, category);
						break;
				}
			}
			return View(dict.ToList());
        }
    }
}