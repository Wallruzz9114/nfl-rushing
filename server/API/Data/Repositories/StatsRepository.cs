using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Core.Interfaces;
using API.Core.Specifications;
using API.Models;

namespace API.Data.Repositories
{
    /// <summary>
    /// Represents the stats repository
    /// </summary>
    public class StatsRepository : IStatsRepository
    {
        private readonly List<RushingStat> _stats = Seed.SeedStats();

        public StatsRepository() { }

        public async Task<int> CountAsync(ISpecification<RushingStat> spec)
        {
            return await Task.Run(() => ApplySpecification(spec).Count());
        }

        public async Task<IReadOnlyList<RushingStat>> GetStatsWithSpecificationAsync(ISpecification<RushingStat> spec)
        {
            return await Task.Run(() => ApplySpecification(spec).ToList());
        }

        private IQueryable<RushingStat> ApplySpecification(ISpecification<RushingStat> spec)
        {
            return SpecificationEvaluator<RushingStat>.GetQuery(_stats.AsQueryable(), spec);
        }
    }
}