namespace Anagramma
{
	using System.Data.Entity;

	public partial class Model : DbContext
	{
		public Model()
			: base("name=ConnectionString")
		{
		}

		public virtual DbSet<DictCatQRSet> DictCatQRSet { get; set; }
		public virtual DbSet<DictCatResSet> DictCatResSet { get; set; }
		public virtual DbSet<DictCatVariaSet> DictCatVariaSet { get; set; }
		public virtual DbSet<DICTSet> DICTSet { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
