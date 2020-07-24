using System;
using System.Collections.Generic;

namespace CodeCamp2020.Data.Models
{
    public class Pokemon
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Category { get; set; }
        public string Height { get; set; }
        public decimal? Weight { get; set; }
        public int? CaptureRate { get; set; }
        public int? EggSteps { get; set; }
        public string ExpGroup { get; set; }
        public int? Total { get; set; }
        public int? HitPoints { get; set; }
        public int? Attack { get; set; }
        public int? Defense { get; set; }
        public int? SpecialAttack { get; set; }
        public int? SpecialDefense { get; set; }
        public int? Speed { get; set; }

        private List<string> _abilities;
        public List<string> Abilities
        {
            get
            {
                if (_abilities == null)
                    _abilities = new List<string>();

                return _abilities;
            }

            set { _abilities = value; }
        }
    }
}
