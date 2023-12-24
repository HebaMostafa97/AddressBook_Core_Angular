using _3Pillars_Backend_BLL.Specifications.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace _3Pillars_Backend_BLL.Specifications.Class
{
    // this class implement from Interface ISpecification 
    public class BaseSpecification<T> : ISpecification<T>
    {
        // Default Constructor 
        public BaseSpecification(){}
        // Parameter Constructor with Expression unc and Criteria as a parameters 
        public BaseSpecification(Expression<Func<T, bool>> Criteria)
        {
            this.Criteria = Criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; }
        // Function GeneralAddInclude take ExpressFunc and Includes as a parameter to Add Include object to Includes List 
        public void AddInclude(Expression<Func<T, object>> Include)
        {
            Includes.Add(Include);
        }

    }
}
