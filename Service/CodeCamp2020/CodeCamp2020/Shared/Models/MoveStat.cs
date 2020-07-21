using System;

using Newtonsoft.Json;

namespace CodeCamp2020.Shared.Models
{
    public class MoveStat
    {
        [JsonProperty(PropertyName = "Tackle")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "Level")]
        public string Level { get; set; }

        [JsonProperty(PropertyName = "Power")]
        public string Power { get; set; }

        [JsonProperty(PropertyName = "Accuracy")]
        public string Accuracy { get; set; }

        [JsonProperty(PropertyName = "PP")]
        public string PP { get; set; }

        [JsonProperty(PropertyName = "Effect %")]
        public string EffectPercent { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }
    }
}
