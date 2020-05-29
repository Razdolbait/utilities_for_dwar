namespace Pets
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PetReitElementColor")]
    public partial class PetReitElementColor
    {
        public int Id { get; set; }

        public int ElementId { get; set; }

        public int ColorId { get; set; }

        [StringLength(100)]
        public string LINK { get; set; }

        [StringLength(100)]
        public string ICON { get; set; }

        public int Grass { get; set; }

        public int Stone { get; set; }

        public int Fish { get; set; }

        public int ESearch { get; set; }

        public int TSearch { get; set; }

        public int WSearch { get; set; }
    }
}
