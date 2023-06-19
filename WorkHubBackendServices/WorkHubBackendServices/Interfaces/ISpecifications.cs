using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace WorkHubBackEndServices.Interfaces
{
    public interface ISpecifications<T>
    {
        Expression<Func<T, bool>> Criteria { get; }

        List<Expression<Func<T, object>>> Includes { get; }

    }
}
