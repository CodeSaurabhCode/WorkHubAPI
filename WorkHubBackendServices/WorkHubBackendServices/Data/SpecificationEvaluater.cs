﻿using Microsoft.EntityFrameworkCore;
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

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }

    }
}
