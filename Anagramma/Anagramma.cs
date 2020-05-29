using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Anagramma
{
	public class Dict : IAnagramma
	{
		Model db = new Model();
		public IEnumerable<DICTSet> Initialize()
		{
			return db.DICTSet.Where(d => d.ABC == "");
		}
		public Dictionary<int, string> GetCategory()
		{
			Dictionary<int, string> category = new Dictionary<int, string>
			{
				{ 0, "Все категории" },
				{ 1, "Ресурсы добывающих профессий" },
				{ 2, "Квестовые ресурсы" },
				{ 3, "Разное" }
			};
			return category;
		}
		private IEnumerable<DICTSet> Categorize(IEnumerable<DICTSet> _dict, int category)
		{
			List<int> List;
			List<DICTSet> _list = new List<DICTSet>();
			switch (category)
			{
				case 1:
					List = _dict.Select(c => c.Id).ToList().Intersect(db.DictCatResSet.Select(d => (int)d.DictId).ToList()).ToList();
					break;
				case 2:
					List = _dict.Select(c => c.Id).ToList().Intersect(db.DictCatQRSet.Select(d => (int)d.DictId).ToList()).ToList();
					break;
				case 3:
					List = _dict.Select(c => c.Id).ToList().Intersect(db.DictCatVariaSet.Select(d => (int)d.DictId).ToList()).ToList();
					break;
				default:
					List = _dict.Select(c => c.Id).ToList();
					break;
			}
			foreach (var item in List)
			{
				_list.Add(db.DICTSet.Where(d => d.Id == item).Single());
			}
			IEnumerable<DICTSet> CategorizeList = _list;
			return CategorizeList;
		}
		private string SortAbc(string word)
		{
			string alf = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
			StringBuilder str = new StringBuilder(word);
			for (int i = 0; i < str.Length; i++)
			{
				for (int j = 0; j < str.Length - 1; j++)
				{
					if (alf.IndexOf(str[j]) > alf.IndexOf(str[j + 1]))
					{
						char Temp = str[j];
						str[j] = str[j + 1];
						str[j + 1] = Temp;
					}
				}
			}
			return str.ToString();
		}
		public IEnumerable<DICTSet> Anagramma(string word, int category)
		{
			word = SortAbc(word);
			IEnumerable<DICTSet> dict = db.DICTSet.Where(d => d.ABC == word).OrderBy(d => d.NAME);
			dict = Categorize(dict, category);
			return dict;
		}
		public IEnumerable<DICTSet> Mask(string word, int category)
		{
			List<DICTSet> _dict = new List<DICTSet>();
			Regex regex = new Regex(word);
			var dictRegex = db.DICTSet.Where(r => r.NAME.Length == word.Length).OrderBy(r => r.NAME);
			foreach (var item in dictRegex)
			{
				if (regex.IsMatch(item.NAME))
				{
					_dict.Add(item);
				}
			}
			IEnumerable<DICTSet> dict = Categorize(_dict, category);
			return dict;
		}
		public IEnumerable<DICTSet> Generator(string word, int category)
		{
			if (word.Length > 15)
			{
				word = SortAbc(word.Substring(0, 15));
			}
			else word = SortAbc(word);
			List<String> pattern = new List<String>();
			List<String> outStr = new List<String>();
			int kol = (int)Math.Pow(2, word.Length);
			int i = kol - 1;
			while (i > 0)
			{
				StringBuilder temp = new StringBuilder(Convert.ToString(i, 2));
				while (temp.Length < word.Length)
				{
					temp.Insert(0, "0");
				}
				pattern.Add(temp.ToString());
				i--;
			}
			pattern = pattern.Distinct().ToList();
			foreach (var item in pattern)
			{
				if (item.Split('1').Length > 2)
				{
					StringBuilder temp = new StringBuilder();
					for (int j = 0; j < word.Length; j++)
					{
						if (item[j] == '1')
						{
							temp.Append(word[j]);
						}
					}
					if (!outStr.Exists(f => f == temp.ToString()))
					{
						outStr.Add(temp.ToString());
					}
				}
			}
			pattern = null;
			outStr = outStr.Distinct().ToList();
			outStr = db.DICTSet.Select(o => o.ABC).ToList().Intersect(outStr).ToList();
			List<DICTSet> _dict = new List<DICTSet>();
			foreach(var item in outStr)
			{
				var temp = db.DICTSet.Where(d => d.ABC == item).ToList();
				foreach (var it in temp)
				{
					_dict.Add(it);
				}
			}
			IEnumerable<DICTSet> dict = Categorize(_dict, category);
			return dict.OrderByDescending(d => d.NAME.Length);
		}
	}
}