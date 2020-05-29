namespace Anagramma
{
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("DictCatResSet")]
    public partial class DictCatResSet
    {
        public int Id { get; set; }

        public int? DictId { get; set; }
    }
}
