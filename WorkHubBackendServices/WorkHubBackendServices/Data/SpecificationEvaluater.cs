using Microsoft.EntityFrameworkCore;
using WorkHubBackEndServices.Interfaces;
using WorkHubBackEndServices.Models;

namespace WorkHubBackEndServices.Data
{
    public class SpecificationEvaluater<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> InputQuery , ISpecifications<TEntity> spec) 
        { 
            var query = InputQuery;
            if (spec.Criteria != null) 
            { 
                query = query.Where(spec.Criteria);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }

    }
}
