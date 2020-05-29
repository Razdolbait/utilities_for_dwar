using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsModels.Models
{
    public class PerksVM
    {
        public int Id { get; set; }
        public int Grass { get; set; }
        public int Stone { get; set; }
        public int Fish { get; set; }
        public int ESearch { get; set; }
        public int TSearch { get; set; }
        public int WSearch { get; set; }
    }
}