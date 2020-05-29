namespace DressingRoom
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("DRDobl")]
    public partial class DRDobl
    {
        public int Id { get; set; }
        public int Lvl { get; set; }
        [StringLength(30)]
        public string NAME { get; set; }
    }
}
