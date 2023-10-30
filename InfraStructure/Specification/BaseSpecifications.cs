using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Specification
{
    public class BaseSpecifications<T> : ISpecifications<T>
    {

        //what is criteria ? it's what we put inside where [condition]
        public BaseSpecifications(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
         }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; }=new List<Expression<Func<T, object>>>();

       

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }


        #region Ordering

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }



        protected void AddOrderBy(Expression<Func<T, object>> orderBy)
        {
            OrderBy = orderBy;
        }
        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescending)
        {
            OrderByDescending = orderByDescending;
        } 
        #endregion




        #region Pagination 
        public int Take { get; private set; }

    public int Skip { get; private set; }

        public bool IsPaginated { get; private set; }


        protected void ApplyPagination(int skip,int take)
        {
            Take = take;
            Skip = skip;
            IsPaginated = true;
        }
        #endregion




    }
}
