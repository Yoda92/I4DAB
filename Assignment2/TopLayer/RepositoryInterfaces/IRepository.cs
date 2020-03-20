using System;
using System.Collections;
using System.Linq.Expressions;

namespace Assignment2.TopLayer.RepositoryInterfaces
{
    public interface IRepository<EntityType> where EntityType : class
    {
        EntityType GetByIntegerID(uint ID);
        EntityType GetByStringID(uint ID);
        IEnumerable GetAll();
        IEnumerable Find(Expression<Func<EntityType,bool>> lambdaExpression);
        void Add(EntityType entity);
        void Remove(EntityType entity);
    }
}