
using API.Core.Implementations;
using API.Data.ViewModels;
using API.Models;

namespace Data.Specifications
{
    public class FilteredStatsCountSpecificication : BaseSpecification<RushingStat>
    {
        /// <summary>
        /// Returns the stats count based on the params
        /// </summary>
        public FilteredStatsCountSpecificication(StatsParams statsParams)
            : base(x => string.IsNullOrEmpty(statsParams.Search) || x.PlayerName.ToLower().Contains(statsParams.Search))
        { }
    }
}