using System.Linq;
using API.Core.Specifications;

namespace API.Data
{
    public class SpecificationEvaluator<T> where T : class
    {
        /// <summary>
        /// Process query based on specifications
        /// </summary>
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null) query = query.Where(spec.Criteria);
            if (spec.OrderBy != null) query = query.OrderBy(spec.OrderBy);
            if (spec.OrderByDescending != null) query = query.OrderByDescending(spec.OrderByDescending);

            return query;
        }
    }
}