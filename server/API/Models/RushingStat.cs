using Newtonsoft.Json;

namespace API.Models
{
    /// <summary>
    /// Represents a RushingStat
    /// </summary>
    public class RushingStat
    {
        [JsonProperty("Player")]
        public string PlayerName { get; set; }

        [JsonProperty("Team")]
        public string PlayerTeam { get; set; }

        [JsonProperty("Pos")]
        public string PlayerPosition { get; set; }

        [JsonProperty("Att")]
        public int RushingAttemps { get; set; }

        [JsonProperty("Att/G")]
        public decimal RushingAttempsPerGameAverage { get; set; }

        [JsonProperty("Yds")]
        public dynamic TotalRushingYards { get; set; }

        [JsonProperty("Avg")]
        public decimal RushingAverageYardsPerAttempt { get; set; }

        [JsonProperty("Yds/G")]
        public decimal RushingYardsPerGame { get; set; }

        [JsonProperty("TD")]
        public int TotalRushingTouchdowns { get; set; }

        [JsonProperty("Lng")]
        public dynamic LongestRush { get; set; }

        [JsonProperty("1st")]
        public decimal RushingFirstDowns { get; set; }

        [JsonProperty("1st%")]
        public decimal RushingFirstDownsPercent { get; set; }

        [JsonProperty("20+")]
        public int Rushing20Yards { get; set; }

        [JsonProperty("40+")]
        public int Rushing40Yards { get; set; }

        [JsonProperty("FUM")]
        public int RushingFumbles { get; set; }

        // Represents if a touchdown occurred from a Longest Rush (Lng/T)
        public bool LongestRushTouchdown { get; set; } = false;
    }
}