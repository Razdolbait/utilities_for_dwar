using Anagramma;
using System;
using System.Collections.Generic;

namespace AnagrammaTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Dict word = new Dict();
			Console.WriteLine("Введите строку:");
			string str = Console.ReadLine().ToUpper();
			Console.WriteLine("Выберите режим поиска:");
			Console.WriteLine("{0, -20} \t{1}", "Анаграмма", "1");
			Console.WriteLine("{0, -20} \t{1}", "Поиск по маске", "2");
			Console.WriteLine("{0, -20} \t{1}", "Генератор", "3");
			int mode = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Введите код категории из:");
			foreach(var i in word.GetCategory())
			{
				Console.WriteLine("{0, -30} \t{1}", i.Value, i.Key.ToString());
			}
			int category = Convert.ToInt32(Console.ReadLine());
			if (str.Length >0 & mode >= 1 & mode <= 3 & category >= 0 & category <= 3)
			{
				IEnumerable<DICTSet> dict;
				switch (mode)
				{
					case 2:
						str = str.Replace("*", ".");
						dict = word.Mask(str, category);
						break;
					case 3:
						dict = word.Generator(str, category);
						break;
					default:
						dict = word.Anagramma(str, category);
						break;
				}
				foreach(var i in dict)
				{
					Console.WriteLine("{0}", i.NAME);
				}
			}
			else
			{
				Console.WriteLine("Error!");
			}
			Console.ReadKey();
		}
	}
}
