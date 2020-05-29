namespace DressingRoom
{
	using System.Data.Entity;

	public partial class Model : DbContext
	{
		public Model()
			: base("name=ConnectionString")
		{
		}

		public virtual DbSet<DRDobl> DRDobl { get; set; }
		public virtual DbSet<DRItems> DRItems { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
