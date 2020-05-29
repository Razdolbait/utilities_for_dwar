using Pets;
using System;
using System.Collections.Generic;

namespace PetsTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Введите уровень от 1 до 20 и код цвета:");
			Console.WriteLine("1 - серый");
			Console.WriteLine("2 - зеленый");
			Console.WriteLine("3 - синий");
			Console.WriteLine("4 - фиолетовый");
			Console.WriteLine("5 - красный");
			int lvl = Convert.ToInt32(Console.ReadLine());
			int color = Convert.ToInt32(Console.ReadLine());
			var pets = new PetsReitList();
			IEnumerable<PetsReit> Petslist = pets.GetPetsReitList(lvl, color);
			foreach (var item in Petslist)
			{
				Console.WriteLine("{0} \t{1, -20} \t{2, -10} \t{3, -20} \t{4, -20} \t{5, -20} \t{6, -20} \t{7} \t{8} \t{9} \t{10} \t{11} \t{12} ", 
					item.Id, item.Name, item.Elements.ElementName, item.Slot1.Name, item.Slot2.Name, item.Slot3.Name, item.Slot4.Name,
					item.Grass, item.Stone, item.Fish, item.ESearch, item.TSearch, item.WSearch
					);
			}
			Console.ReadKey();
		}
	}
}
