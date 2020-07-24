using System;
using System.Collections.Generic;
using System.Text;

namespace CodeCamp2020.Shared.Pages.Pokedex
{
    public class ViewModelEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Category { get; set; }
        public int? HitPoints { get; set; }
        public int? Attack { get; set; }
        public int? Defense { get; set; }
        public int? SpecialAttack { get; set; }
        public int? SpecialDefense { get; set; }
        public int? Speed { get; set; }
    }
}
