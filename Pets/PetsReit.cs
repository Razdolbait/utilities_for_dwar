namespace Pets
{
	[System.ComponentModel.DataAnnotations.Schema.NotMapped]
	public class PetsReit: PetReitPets
	{
		public Element Elements { get; set; }
		public new Slot Slot1 { get; set; }
		public new Slot Slot2 { get; set; }
		public new Slot Slot3 { get; set; }
		public new Slot Slot4 { get; set; }
		public int Grass { get; set; }
		public int Stone { get; set; }
		public int Fish { get; set; }
		public int ESearch { get; set; }
		public int TSearch { get; set; }
		public int WSearch { get; set; }
		public PetsReit(int _id, string _name, string _link, string _icon,
			Element _e,
			Slot _s1, Slot _s2, Slot _s3, Slot _s4,
			int _grass, int _stone, int _fish, int _esearch, int _tsearch, int _wsearch,
			string _desc
			)
		{
			Id = _id;
			Name = _name;
			LINK = _link;
			ICON = _icon;
			Elements = new Element(_e);
			Slot1 = new Slot(_s1);
			Slot2 = new Slot(_s2);
			Slot3 = new Slot(_s3);
			Slot4 = new Slot(_s4);
			Grass = _grass;
			Stone = _stone;
			Fish = _fish;
			ESearch = _esearch;
			TSearch = _tsearch;
			WSearch = _wsearch;
			DESCRIPTION = _desc;
		}
		public PetsReit()
		{
		
		}
	}
	public class Element
	{
		public string ElementName { get; set; }
		public string ElementLink { get; set; }
		public string ElementIcon { get; set; }
		public Element(string _name, string _link, string _icon)
		{
			ElementName = _name;
			ElementLink = _link;
			ElementIcon = _icon;
		}
		public Element(Element e)
		{
			ElementName = e.ElementName;
			ElementLink = e.ElementLink;
			ElementIcon = e.ElementIcon;
		}
		public Element()
		{
		}
	}
	public class Slot
	{
		public string Name { get; set; }
		public string Link { get; set; }
		public string Icon { get; set; }
		public Slot(string _name, string _link, string _icon)
		{
			Name = _name;
			Link = _link;
			Icon = _icon;
		}
		public Slot(Slot _s)
		{
			Name = _s.Name;
			Link = _s.Link;
			Icon = _s.Icon;
		}
	}

}