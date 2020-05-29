using System.Collections.Generic;

namespace Anagramma
{
	interface IAnagramma
	{
		Dictionary<int, string>  GetCategory();
		IEnumerable<DICTSet> Anagramma(string word, int category);
		IEnumerable<DICTSet> Mask(string word, int category);
		IEnumerable<DICTSet> Generator(string word, int category);
		IEnumerable<DICTSet> Initialize();
	}
}
