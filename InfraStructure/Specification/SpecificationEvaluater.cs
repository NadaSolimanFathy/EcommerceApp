using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Specification
{
    public class SpecificationEvaluater<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery,ISpecifications<T> specifications) {
            var query = inputQuery;

            if(specifications.Criteria is not null)
                query=query.Where(specifications.Criteria);

            query = specifications.Includes.Aggregate(query, (current, include) =>
            current.Include(include));

            return query;
        }
    }
}
