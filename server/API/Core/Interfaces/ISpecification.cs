using System;
using System.Linq.Expressions;

namespace API.Core.Specifications
{
    /// <summary>
    /// Represents a generic specification
    /// </summary>
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
    }
}