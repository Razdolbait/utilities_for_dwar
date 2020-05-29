using System.Collections.Generic;
using System.Linq;

namespace Pets
{
	public class PetsReitList
	{
		public IEnumerable<PetsReit> GetPetsReitList(int _lvl = 1, int _color = 1)
		{
			using (Model dbPets = new Model())
			{
				var pets = new List<PetsReit>();
				List<PetReitPets> petList = dbPets.PetReitPets.ToList();
				List<PetReitElement> elementsList = dbPets.PetReitElement.ToList();
				List<PetReitTalismanType> talismanList = dbPets.PetReitTalismanType.ToList();
				List<PetReitTalismanSet> talismanSetList = dbPets.PetReitTalismanSet.Where(t => t.Lvl >= _lvl - 3 && t.Lvl <= _lvl).ToList();
				List<PetReitElementColor> elementColorsList = dbPets.PetReitElementColor.Where(e => e.ColorId == _color).ToList();
				foreach (var item in petList)
				{
					pets.Add(new PetsReit(
						item.Id,
						item.Name,
						item.LINK,
						item.ICON,
						new Element(
							elementsList.Where(e => e.Id == item.ElementId).Select(e => e.Name).DefaultIfEmpty("").Single().ToString(),
							elementColorsList.Where(c => c.ElementId == item.ElementId).Select(c => c.LINK).DefaultIfEmpty("").Single().ToString(),
							elementColorsList.Where(c => c.ElementId == item.ElementId).Select(c => c.ICON).DefaultIfEmpty("").Single().ToString()
							),
						new Slot(
							talismanList.Where(t => t.Id == item.Slot1).Select(t => t.Name).DefaultIfEmpty("").Single().ToString(),
							talismanSetList.Where(t => t.TalismanTypeId == item.Slot1).Select(t => t.LINK).DefaultIfEmpty("").Single().ToString(),
							talismanSetList.Where(t => t.TalismanTypeId == item.Slot1).Select(t => t.ICON).DefaultIfEmpty("").Single().ToString()
							),
						new Slot(
							talismanList.Where(t => t.Id == item.Slot2).Select(t => t.Name).DefaultIfEmpty("").Single().ToString(),
							talismanSetList.Where(t => t.TalismanTypeId == item.Slot2).Select(t => t.LINK).DefaultIfEmpty("").Single().ToString(),
							talismanSetList.Where(t => t.TalismanTypeId == item.Slot2).Select(t => t.ICON).DefaultIfEmpty("").Single().ToString()
							),
						new Slot(
							talismanList.Where(t => t.Id == item.Slot3).Select(t => t.Name).DefaultIfEmpty("").Single().ToString(),
							talismanSetList.Where(t => t.TalismanTypeId == item.Slot3).Select(t => t.LINK).DefaultIfEmpty("").Single().ToString(),
							talismanSetList.Where(t => t.TalismanTypeId == item.Slot3).Select(t => t.ICON).DefaultIfEmpty("").Single().ToString()
							),
						new Slot(
							talismanList.Where(t => t.Id == item.Slot4).Select(t => t.Name).DefaultIfEmpty("").Single().ToString(),
							talismanSetList.Where(t => t.TalismanTypeId == item.Slot4).Select(t => t.LINK).DefaultIfEmpty("").Single().ToString(),
							talismanSetList.Where(t => t.TalismanTypeId == item.Slot4).Select(t => t.ICON).DefaultIfEmpty("").Single().ToString()
							),
						elementColorsList.Where(g => g.ElementId == item.ElementId).Select(g => g.Grass).Single() +
							talismanSetList.Where(t => t.TalismanTypeId == item.Slot1 || t.TalismanTypeId == item.Slot2 || t.TalismanTypeId == item.Slot3 ||
							t.TalismanTypeId == item.Slot4).Select(g => g.Grass).Sum(),
						elementColorsList.Where(g => g.ElementId == item.ElementId).Select(g => g.Stone).Single() +
							talismanSetList.Where(t => t.TalismanTypeId == item.Slot1 || t.TalismanTypeId == item.Slot2 || t.TalismanTypeId == item.Slot3 ||
							t.TalismanTypeId == item.Slot4).Select(g => g.Stone).Sum(),
						elementColorsList.Where(g => g.ElementId == item.ElementId).Select(g => g.Fish).Single() +
							talismanSetList.Where(t => t.TalismanTypeId == item.Slot1 || t.TalismanTypeId == item.Slot2 || t.TalismanTypeId == item.Slot3 ||
							t.TalismanTypeId == item.Slot4).Select(g => g.Fish).Sum(),
						elementColorsList.Where(g => g.ElementId == item.ElementId).Select(g => g.ESearch).Single() +
							talismanSetList.Where(t => t.TalismanTypeId == item.Slot1 || t.TalismanTypeId == item.Slot2 || t.TalismanTypeId == item.Slot3 ||
							t.TalismanTypeId == item.Slot4).Select(g => g.ESearch).Sum(),
						elementColorsList.Where(g => g.ElementId == item.ElementId).Select(g => g.TSearch).Single() +
							talismanSetList.Where(t => t.TalismanTypeId == item.Slot1 || t.TalismanTypeId == item.Slot2 || t.TalismanTypeId == item.Slot3 ||
							t.TalismanTypeId == item.Slot4).Select(g => g.TSearch).Sum(),
						elementColorsList.Where(g => g.ElementId == item.ElementId).Select(g => g.WSearch).Single() +
							talismanSetList.Where(t => t.TalismanTypeId == item.Slot1 || t.TalismanTypeId == item.Slot2 || t.TalismanTypeId == item.Slot3 ||
							t.TalismanTypeId == item.Slot4).Select(g => g.WSearch).Sum(),
						item.DESCRIPTION
						));
				}
				IEnumerable<PetsReit> PetsList = pets.AsEnumerable<PetsReit>();
				return PetsList;
			}
		}

	}
}
