namespace PetsModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DRItems
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int Color { get; set; }
        public int LvlSet { get; set; }
        public int Style { get; set; }
        public int Slot { get; set; }
        public int Lvl { get; set; }
        public int Rank { get; set; }
        public int Up { get; set; }
        public int Suite { get; set; }
        public int Weight { get; set; }
        [StringLength(100)]
        public string NAME { get; set; }
        [StringLength(100)]
        public string LINK { get; set; }
        [StringLength(100)]
        public string ICON { get; set; }
        public int Agility { get; set; }
        public int Defense { get; set; }
        public int Initiative { get; set; }
        public int Intuition { get; set; }
        public int Intelligence { get; set; }
        public int Strength { get; set; }
        public int Vitality { get; set; }
        public int Wisdom { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int FAprot { get; set; }
        public int LDprot { get; set; }
        public int EWprot { get; set; }
        public double MinMD { get; set; }
        public double MaxMD { get; set; }
        public double MinPD { get; set; }
        public double MaxPD { get; set; }
        public int Antitraumatism { get; set; }
        public int Traumatism { get; set; }
        public int Stamina { get; set; }
        public int Insight { get; set; }
        public int Speed { get; set; }
    }
}
