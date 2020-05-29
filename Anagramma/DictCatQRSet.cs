namespace Anagramma
{
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("DictCatQRSet")]
    public partial class DictCatQRSet
    {
        public int Id { get; set; }

        public int? DictId { get; set; }
    }
}
