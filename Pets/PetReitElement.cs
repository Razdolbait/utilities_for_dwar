namespace Pets
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PetReitElement")]
    public partial class PetReitElement
    {
        public int Id { get; set; }

        [StringLength(25)]
        public string Name { get; set; }
    }
}
