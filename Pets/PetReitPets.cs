namespace Pets
{
	using System.ComponentModel.DataAnnotations;

	public partial class PetReitPets
    {
		public PetReitPets()
		{
		}

		public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public int ElementId { get; set; }

        public int Slot1 { get; set; }

        public int Slot2 { get; set; }

        public int Slot3 { get; set; }

        public int Slot4 { get; set; }

        [StringLength(100)]
        public string LINK { get; set; }

        [StringLength(100)]
        public string ICON { get; set; }

        [StringLength(100)]
        public string DESCRIPTION { get; set; }
    }
}
