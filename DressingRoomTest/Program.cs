using DressingRoom;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DressingRoomTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("DressingRoomTest");
			DRPers testPers = new DRPers(11, 12);
			testPers.ClothesSet(307, 308, 245, 0, 246, 247, 248, 249, 250, 667);
			/*Random rnd = new Random();
			int[] rand = new int[10];
			for (int i = 0; i < 10; i++)
			{
				rand[i] = rnd.Next(1, 702);
			}
			Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4} \t{5} \t{6} \t{7} \t{8} \t{9}", rand[0], rand[1], rand[2], rand[3], rand[4], rand[5], rand[6], rand[7], rand[8], rand[9]);
			testPers.ClothesSet(rand[0], rand[1], rand[2], rand[3], rand[4], rand[5], rand[6], rand[7], rand[8], rand[9]);*/
			Random rnd = new Random();
			int[] randR = new int[10];
			for (int i = 0; i < 10; i++)
			{
				randR[i] = 0;// rnd.Next(703, 1448);
			}
			int[] randF = new int[10];
			for (int i = 0; i < 10; i++)
			{
				randF[i] = 0; // rnd.Next(1449, 1552);
			}
			Console.WriteLine("Runes \t{0} \t{1} \t{2} \t{3} \t{4} \t{5} \t{6} \t{7} \t{8} \t{9}", randR[0], randR[1], randR[2], randR[3], randR[4], randR[5], randR[6], randR[7], randR[8], randR[9]);
			Console.WriteLine("Frames \t{0} \t{1} \t{2} \t{3} \t{4} \t{5} \t{6} \t{7} \t{8} \t{9}", randF[0], randF[1], randF[2], randF[3], randF[4], randF[5], randF[6], randF[7], randF[8], randF[9]);
			testPers.RFSet(randR[0], randR[1], randR[2], randR[3], randR[4], randR[5], randR[6], randR[7], randR[8], randR[9],
				randF[0], randF[1], randF[2], randF[3], randF[4], randF[5], randF[6], randF[7], randF[8], randF[9]); 
			Console.WriteLine("---Доспехи---");
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Нагрудник:", testPers.Clothes.Armor.Id, testPers.Clothes.Armor.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Поножи:", testPers.Clothes.Pants.Id, testPers.Clothes.Pants.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Основное оружие:", testPers.Clothes.MWeapon.Id, testPers.Clothes.MWeapon.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Дополнительное оружие:", testPers.Clothes.AWeapon.Id, testPers.Clothes.AWeapon.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Сапоги:", testPers.Clothes.Boots.Id, testPers.Clothes.Boots.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Кольчуга:", testPers.Clothes.Hauberk.Id, testPers.Clothes.Hauberk.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Наплечники:", testPers.Clothes.Shoulders.Id, testPers.Clothes.Shoulders.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Наручи:", testPers.Clothes.Bangle.Id, testPers.Clothes.Bangle.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Шлем:", testPers.Clothes.Helmet.Id, testPers.Clothes.Helmet.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Лук:", testPers.Clothes.Bow.Id, testPers.Clothes.Bow.NAME);
			/*
			Console.WriteLine();
			Console.WriteLine("---Руны---");
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Нагрудник:", testPers.Runes.Armor.Id, testPers.Runes.Armor.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Поножи:", testPers.Runes.Pants.Id, testPers.Runes.Pants.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Основное оружие:", testPers.Runes.MWeapon.Id, testPers.Runes.MWeapon.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Дополнительное оружие:", testPers.Runes.AWeapon.Id, testPers.Runes.AWeapon.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Сапоги:", testPers.Runes.Boots.Id, testPers.Runes.Boots.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Кольчуга:", testPers.Runes.Hauberk.Id, testPers.Runes.Hauberk.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Наплечники:", testPers.Runes.Shoulders.Id, testPers.Runes.Shoulders.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Наручи:", testPers.Runes.Bangle.Id, testPers.Runes.Bangle.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Шлем:", testPers.Runes.Helmet.Id, testPers.Runes.Helmet.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Лук:", testPers.Runes.Bow.Id, testPers.Runes.Bow.NAME);

			Console.WriteLine();
			Console.WriteLine("---Оправы---");
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Нагрудник:", testPers.Frames.Armor.Id, testPers.Frames.Armor.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Поножи:", testPers.Frames.Pants.Id, testPers.Frames.Pants.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Основное оружие:", testPers.Frames.MWeapon.Id, testPers.Frames.MWeapon.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Дополнительное оружие:", testPers.Frames.AWeapon.Id, testPers.Frames.AWeapon.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Сапоги:", testPers.Frames.Boots.Id, testPers.Frames.Boots.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Кольчуга:", testPers.Frames.Hauberk.Id, testPers.Frames.Hauberk.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Наплечники:", testPers.Frames.Shoulders.Id, testPers.Frames.Shoulders.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Наручи:", testPers.Frames.Bangle.Id, testPers.Frames.Bangle.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Шлем:", testPers.Frames.Helmet.Id, testPers.Frames.Helmet.NAME);
			Console.WriteLine("{0, -25} \t{1} \t{2}", "Лук:", testPers.Frames.Bow.Id, testPers.Frames.Bow.NAME);
			*/
			Console.WriteLine();
			Console.WriteLine("---Характеристики---");
			Console.WriteLine("Ловкость: \t{0}", testPers.Stats.Agility);
			Console.WriteLine("Защита: \t{0}", testPers.Stats.Defense);
			Console.WriteLine("Инициатива: \t{0}", testPers.Stats.Initiative);
			Console.WriteLine("Интуиция: \t{0}", testPers.Stats.Intuition);
			Console.WriteLine("Интелект: \t{0}", testPers.Stats.Intelligence);
			Console.WriteLine("Сила: \t{0}", testPers.Stats.Strength);
			Console.WriteLine("Живучесть: \t{0}", testPers.Stats.Vitality);
			Console.WriteLine("Мудрость: \t{0}", testPers.Stats.Wisdom);
			Console.WriteLine("Уровень жизни: \t{0}", testPers.Stats.Health);
			Console.WriteLine("Уровень маны: \t{0}", testPers.Stats.Mana);
			Console.WriteLine("Защита огонь-воздух: \t{0}", testPers.Stats.FAprot);
			Console.WriteLine("Защита свет-тьма: \t{0}", testPers.Stats.LDprot);
			Console.WriteLine("Защита земля-вода: \t{0}", testPers.Stats.EWprot);
			Console.WriteLine("Мин маг урон: \t{0}", testPers.Stats.MinMD);
			Console.WriteLine("Макс маг урон: \t{0}", testPers.Stats.MaxMD);
			Console.WriteLine("Мин физ урон: \t{0}", testPers.Stats.MinPD);
			Console.WriteLine("Макс физ урон: \t{0}", testPers.Stats.MaxPD);
			Console.WriteLine("Антитравматизм: \t{0}", testPers.Stats.Antitraumatism);
			Console.WriteLine("Травматизм: \t{0}", testPers.Stats.Traumatism);
			Console.WriteLine("Стойкость: \t{0}", testPers.Stats.Stamina);
			Console.WriteLine("Проницание: \t{0}", testPers.Stats.Insight);
			Console.WriteLine("Скорость: \t{0}", testPers.Stats.Speed);
			/*
			Console.WriteLine("---Руны в нагрудник---");
			foreach(var item in testPers.FramesList.Armor)
			{
				Console.WriteLine(item.NAME);
			}
			Console.WriteLine("---Руны в поножи---");
			foreach (var item in testPers.FramesList.Pants)
			{
				Console.WriteLine(item.NAME);
			}
			Console.WriteLine("---Руны в основное оружие---");
			foreach (var item in testPers.FramesList.MWeapon)
			{
				Console.WriteLine(item.NAME);
			}
			Console.WriteLine("---Руны в дополнительное оружие---");
			foreach (var item in testPers.FramesList.AWeapon)
			{
				Console.WriteLine(item.NAME);
			}
			Console.WriteLine("---Руны в сапоги---");
			foreach (var item in testPers.FramesList.Boots)
			{
				Console.WriteLine(item.NAME);
			}
			Console.WriteLine("---Руны в кольчугу---");
			foreach (var item in testPers.FramesList.Hauberk)
			{
				Console.WriteLine(item.NAME);
			}
			Console.WriteLine("---Руны в наплечники---");
			foreach (var item in testPers.FramesList.Shoulders)
			{
				Console.WriteLine(item.NAME);
			}
			Console.WriteLine("---Руны в наручи---");
			foreach (var item in testPers.FramesList.Bangle)
			{
				Console.WriteLine(item.NAME);
			}
			Console.WriteLine("---Руны в шлем---");
			foreach (var item in testPers.FramesList.Helmet)
			{
				Console.WriteLine(item.NAME);
			}
			Console.WriteLine("---Руны в лук---");
			foreach (var item in testPers.FramesList.Bow)
			{
				Console.WriteLine(item.NAME);
			}
			*/
			Console.ReadKey();
		}
	}
}
