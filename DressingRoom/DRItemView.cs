using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;

namespace DressingRoom
{
	public class DRItemView
	{
		public int Id { get; internal set; } = 0;
		[StringLength(100)]
		public string NAME { get; internal set; } = "";
		public string Link { get; internal set; } = "";
		[StringLength(20)]
		private string iconPath;
		internal int IconSize { get; set; }
		public string IconPath
		{
			get { return iconPath; }
			internal set
			{
				try
				{
					iconPath = Path.Combine(@"/Images/" + IconSize.ToString() + "/", value);
					icon();
				}
				catch
				{}
			}
		}
		public string Icon { get; private set; }
		public int Color { get; internal set; } = 0;
		internal void icon()
		{
			if (IconSize == 16)
			{
				try
				{
					Icon = Convert.ToBase64String(File.ReadAllBytes(iconPath));
				}
				catch
				{
					Icon = "Invalid";
				}
			}
			else Icon = "Other Size: " + iconPath;
		}
	}
}
