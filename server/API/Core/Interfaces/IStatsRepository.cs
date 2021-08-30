using System.Collections.Generic;
using System.Threading.Tasks;
using API.Core.Specifications;
using API.Models;

namespace API.Core.Interfaces
{
    public interface IStatsRepository
    {
        Task<IReadOnlyList<RushingStat>> GetStatsWithSpecificationAsync(ISpecification<RushingStat> spec);
        Task<int> CountAsync(ISpecification<RushingStat> spec);
    }
}