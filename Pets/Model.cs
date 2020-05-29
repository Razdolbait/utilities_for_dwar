namespace Pets
{
	using System.Data.Entity;

	public partial class Model : DbContext
	{
		public Model()
			: base("name=ConnectionString")
		{
		}

		public virtual DbSet<PetReitElement> PetReitElement { get; set; }
		public virtual DbSet<PetReitElementColor> PetReitElementColor { get; set; }
		public virtual DbSet<PetReitPets> PetReitPets { get; set; }
		public virtual DbSet<PetReitTalismanSet> PetReitTalismanSet { get; set; }
		public virtual DbSet<PetReitTalismanType> PetReitTalismanType { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
