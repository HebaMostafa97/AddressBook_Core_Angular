using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace _3Pillars_Backend_BLL.Specifications.Interface
{
    public interface ISpecification<T> 
    {
        // Expression assigned to Delegate from type Func
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; }
    }
}
