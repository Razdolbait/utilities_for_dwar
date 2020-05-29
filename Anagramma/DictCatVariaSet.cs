namespace Anagramma
{
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("DictCatVariaSet")]
    public partial class DictCatVariaSet
    {
        public int Id { get; set; }

        public int? DictId { get; set; }
    }
}
