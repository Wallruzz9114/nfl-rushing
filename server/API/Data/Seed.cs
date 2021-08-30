using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using API.Models;
using Newtonsoft.Json;

namespace API.Data
{
    public class Seed
    {
        /// <summary>
        /// This method returns a list of all stats
        /// </summary>
        public static List<RushingStat> SeedStats()
        {
            using var streamReader = File.OpenText("Data/rushing.json");
            var serializer = new JsonSerializer();
            var stats = (List<RushingStat>)serializer.Deserialize(streamReader, typeof(List<RushingStat>));

            // Mapping/updating some strings to numbers
            foreach (var stat in stats)
            {
                if (stat.TotalRushingYards is string)
                    stat.TotalRushingYards = long.Parse(stat.TotalRushingYards, NumberStyles.AllowThousands, CultureInfo.InvariantCulture);

                if (stat.LongestRush is string longestRush)
                {
                    stat.LongestRushTouchdown = longestRush.Contains("T");
                    var cleanValue = Regex.Replace(longestRush, "[^0-9.]", "");
                    stat.LongestRush = long.Parse(cleanValue, NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
                }
            }

            return stats;
        }
    }
}