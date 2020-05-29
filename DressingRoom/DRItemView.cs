using System.ComponentModel.DataAnnotations;

namespace DressingRoom
{
	public class DRItemView
	{
		public int Id { get; internal set; } = 0;
		[StringLength(100)]
		public string NAME { get; internal set; } = "";
		[StringLength(20)]
		public string ICON { get; internal set; } = "";
		public int Color { get; internal set; } = 0;
	}
}
