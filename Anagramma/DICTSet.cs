namespace Anagramma
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("DICTSet")]
    public partial class DICTSet
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string NAME { get; set; }

        [StringLength(30)]
        public string ABC { get; set; }

        public int? TYPE { get; set; }
    }
}
