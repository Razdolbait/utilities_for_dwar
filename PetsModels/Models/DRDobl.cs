namespace PetsModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DRDobl")]
    public partial class DRDobl
    {
        public int Id { get; set; }

        public int Lvl { get; set; }

        [StringLength(30)]
        public string NAME { get; set; }
    }
}
