using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace CodeCamp2020.Data.Json.Pokemons
{
    public class PokemonJson
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Type 1")]
        public string Type1 { get; set; }

        [JsonProperty(PropertyName = "Type 2")]
        public string Type2 { get; set; }

        [JsonProperty(PropertyName = "Category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "Height (ft)")]
        public string Height { get; set; }

        [JsonProperty(PropertyName = "Weight (lbs)")]
        public decimal? Weight { get; set; }

        [JsonProperty(PropertyName = "Capture Rate")]
        public int? CaptureRate { get; set; }

        [JsonProperty(PropertyName = "Egg Steps")]
        public int? EggSteps { get; set; }

        [JsonProperty(PropertyName = "Exp Group")]
        public string ExpGroup { get; set; }

        [JsonProperty(PropertyName = "Total")]
        public int? Total { get; set; }

        [JsonProperty(PropertyName = "HP")]
        public int? HitPoints { get; set; }

        [JsonProperty(PropertyName = "Attack")]
        public int? Attack { get; set; }

        [JsonProperty(PropertyName = "Defense")]
        public int? Defense { get; set; }

        [JsonProperty(PropertyName = "Sp. Attack")]
        public int? SpecialAttack { get; set; }

        [JsonProperty(PropertyName = "Sp. Defense")]
        public int? SpecialDefense { get; set; }

        [JsonProperty(PropertyName = "Speed")]
        public int? Speed { get; set; }

        private List<string> _abilities;
        [JsonProperty(PropertyName = "Abilities")]
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
