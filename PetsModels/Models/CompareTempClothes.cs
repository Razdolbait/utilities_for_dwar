using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsModels.Models
{
	public class CompareTempClothes
	{
		public ICollection<DRItems> Armor { get; set; }
		public ICollection<DRItems> Pants { get; set; }
		public ICollection<DRItems> MWeapon { get; set; }
		public ICollection<DRItems> AWeapon { get; set; }
		public ICollection<DRItems> Boots { get; set; }
		public ICollection<DRItems> Hauberk { get; set; }
		public ICollection<DRItems> Shoulders { get; set; }
		public ICollection<DRItems> Bangle { get; set; }
		public ICollection<DRItems> Helmet { get; set; }
		public ICollection<DRItems> Bow { get; set; }
	}
}