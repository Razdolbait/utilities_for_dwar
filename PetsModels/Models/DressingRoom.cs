namespace PetsModels.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class DressingRoom : DbContext
	{
		public DressingRoom()
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
