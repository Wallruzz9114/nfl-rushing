using API.Core.Implementations;
using API.Data.ViewModels;
using API.Models;

namespace API.Data.Specifications
{
    public class RushingStatsSpecification : BaseSpecification<RushingStat>
    {
        /// <summary>
        /// Returns the stats query based on the params
        /// </summary>
        public RushingStatsSpecification(StatsParams statsParams)
            : base(x => string.IsNullOrEmpty(statsParams.Search) || x.PlayerName.ToLower().Contains(statsParams.Search))
        {
            AddOrderBy(x => x.PlayerName);

            if (!string.IsNullOrEmpty(statsParams.Sort))
            {
                switch (statsParams.Sort)
                {
                    case "try":
                        AddOrderByDescending(p => p.TotalRushingYards);
                        break;
                    case "lr":
                        AddOrderByDescending(p => p.LongestRush);
                        break;
                    case "trt":
                        AddOrderByDescending(p => p.TotalRushingTouchdowns);
                        break;
                    default:
                        AddOrderBy(p => p.PlayerName);
                        break;
                }
            }
        }
    }
}